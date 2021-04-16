default:
	make dev

restore:
	dotnet restore src && dotnet tool restore --tool-manifest ./src/.config/dotnet-tools.json

build:
	dotnet build src

run:
	dotnet run --project src

start:
	make build && make run	

dev:
	npm run generate
	dotnet watch run --project src

migrate:
	cd src && dotnet ef database update && cd ..
