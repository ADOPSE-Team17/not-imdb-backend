# NotIMDB backend

The application services for the NotIBDM project

## Index
- [NotIMDB backend](#notimdb-backend)
  - [Index](#index)
  - [Development](#development)
    - [First time run](#first-time-run)
    - [Actions for updating the project](#actions-for-updating-the-project)
    - [Actions for saving changes to the db schema](#actions-for-saving-changes-to-the-db-schema)
    - [Install a new package](#install-a-new-package)

## Development

### First time run
- Install the dotnet SDK
- Install `make`
- Run `cp ./src/appsettings.json appsettings.Development.json` to generate the development configuration

### Actions for updating the project
- Run `make restore` to install dependencies
- Run `make migrate` to get the latest schema changes
- Run `make dev` to start the development server

### Actions for saving changes to the db schema
- Run `cd src` to use the src project
- Run `dotnet ef migrations add <YOUR_MIGRATION_NAME>`

### Install a new package
- Run `cd src` to use the src project
- Run `dotnet add package <package_name>` to add the new package
