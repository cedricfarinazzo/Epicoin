InstallDir=/usr/local/bin/epicoin
Blockchain=blockchain/blockchain/blockchain
EpicoinGraphics=EpicoinGraphics/EpicoinGraphics/EpicoinGraphics
EpicoinTerm=EpicoinTerm/EpicoinTerm/EpicoinTerm
Release=Release/Epicoin
CURRENT_DIR=$(shell pwd)

OK=yes

.PHONY: check clean build buildTerm buildGraphics clean-build clean-release release release-zip release-tar.gz update
.SILENT: clean update clean-release clean-build

define install-dep
@if [ $(shell uname) != 'Linux' ];then echo 'Platform unsupported, only available for linux. Please install mono' && exit 1; fi
@if which "apt-get" &> /dev/null ; then $(MAKE) install-dep-apt && exit 0; fi
if which "pacman" &> /dev/null ; then $(MAKE) install-dep-arch && exit 0; fi
echo "Please install mono "
endef


update: check
	git pull

buildLibrairy:
	msbuild /p:Configuration=Debug /verbosity:quiet $(Blockchain)/blockchain.csproj
	msbuild /p:Configuration=Release /verbosity:quiet $(Blockchain)/blockchain.csproj

buildGraphics: 
	msbuild /p:Configuration=Debug /verbosity:quiet $(EpicoinGraphics)/EpicoinGraphics.csproj
	msbuild /p:Configuration=Release /verbosity:quiet $(EpicoinGraphics)/EpicoinGraphics.csproj

buildTerm: 
	msbuild /p:Configuration=Debug /verbosity:quiet $(EpicoinTerm)/EpicoinTerm.csproj
	msbuild /p:Configuration=Release /verbosity:quiet $(EpicoinTerm)/EpicoinTerm.csproj

build: buildLibrairy buildTerm buildGraphics
	
clean-build:
	rm -rf $(Blockchain)/bin
	rm -rf $(Blockchain)/obj
	rm -rf $(EpicoinGraphics)/bin
	rm -rf $(EpicoinGraphics)/obj
	rm -rf $(EpicoinTerm)/bin
	rm -rf $(EpicoinTerm)/obj

clean-release:
	rm -rf $(Release)/EpicoinGraphics/*
	rm -rf $(Release)/EpicoinTerm/*

clean: clean-build clean-release

release: clean build
	cp $(EpicoinGraphics)/bin/Release/* $(Release)/EpicoinGraphics/
	cp $(EpicoinTerm)/bin/Release/* $(Release)/EpicoinTerm/

release-zip: release
	rm -f Epicoin.zip
	zip -r Epicoin.zip $(Release)	

release-tar.gz: release
	rm -f Epicoin.tar.gz
	tar -zcvf Epicoin.tar.gz $(Release)

check:
	@type mono > /dev/null 2>&1 || (OK=no; echo "mono not found. Please install mono-complete or mono")	
	@type msbuild > /dev/null 2>&1 || (OK=no; echo msbuild not found. Please install mono-complete or mono")
	@echo "Check dependency: "
	@if [ "$(OK)" = "yes" ]; then echo "    success"; else echo "    failed. Run make install-dependency" && exit 1 ; fi

install-dependency: 
	$(install-dep)


install-dep-apt:
	sudo apt-get update
	sudo apt-get install build-essential
	sudo apt-get install mono-complete

install-dep-arch:
	sudo pacman -S mono

install: check release
	@if [ ! -d $(InstallDir) ]; then sudo mkdir $(InstallDir); fi
	@sudo cp $(Release)/EpicoinTerm/* $(InstallDir)
	@sudo cp install/epicoin $(InstallDir)
	@sudo chmod 755 $(InstallDir)/epicoin
	@sudo cp install/epicoin.service /etc/systemd/system/epicoin.service
	

