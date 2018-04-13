EpicoinGraphics=EpicoinGraphics/EpicoinGraphics/EpicoinGraphics
EpicoinTerm=blockchain/blockchain/blockchain
Release=Release/Epicoin
CURRENT_DIR=$(shell pwd)

OK=yes

.PHONY: check clean build buildTerm buildGraphics clean-build clean-release release release-zip release-tar.gz update
.SILENT: clean update clean-release clean-build

update: check
	git pull

buildGraphics: 
	xbuild /p:Configuration=Debug /verbosity:quiet $(EpicoinGraphics)/EpicoinGraphics.csproj
	xbuild /p:Configuration=Release /verbosity:quiet $(EpicoinGraphics)/EpicoinGraphics.csproj

buildTerm: 
	xbuild /p:Configuration=Debug /verbosity:quiet $(EpicoinTerm)/blockchain.csproj
	xbuild /p:Configuration=Release /verbosity:quiet $(EpicoinTerm)/blockchain.csproj

build: buildGraphics buildTerm
	
clean-build:
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
	@type xbuild > /dev/null 2>&1 || (OK=no; echo "xbuild not found. Please install mono-complete or mono")
	@echo "Check dependency: "
	@if [ "$(OK)" = "yes" ]; then echo "    success"; else echo "    failed"; fi

