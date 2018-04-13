EpicoinGraphics=EpicoinGraphics/EpicoinGraphics/EpicoinGraphics
EpicoinTerm=blockchain/blockchain/blockchain
Release=Release/Epicoin
CURRENT_DIR=$(shell pwd)

.PHONY: check clean
.SILENT: clean update clean-release clean-build

update:
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
	echo "ok"
