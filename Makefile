default:
	make dev

start:
	dotnet run --project src

run:
	make dev

dev:
	dotnet watch run --project src

restore:
	dotnet restore src
