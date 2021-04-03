default:
	make dev

restore:
	dotnet restore src

build:
	dotnet build src

run:
	dotnet run --project src

start:
	make build && make run	

dev:
	dotnet watch run --project src

migrate:
	cd src && dotnet ef database update && cd ..
