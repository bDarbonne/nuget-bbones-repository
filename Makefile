
STARTUP-PROJECT := ./BBones.Repository.Interfaces


all: build

clean:
	dotnet clean

true-clean:
	find -type d -name bin | xargs rm -rf
	find -type d -name obj | xargs rm -rf

build:
	dotnet build

test:
	dotnet test

pack:
	dotnet pack -o .