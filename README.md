# NotIMDB backend

The application services for the NotIBDM project

## Index
- [NotIMDB backend](#notimdb-backend)
  - [Index](#index)
  - [Development](#development)
    - [Visual stusio](#visual-studio)
    - [Dotnet core](#dotnet-core)
      - [First time run](#first-time-run)
      - [Actions for updating the project](#actions-for-updating-the-project)
      - [Actions for saving changes to the db schema](#actions-for-saving-changes-to-the-db-schema)
      - [Install a new package](#install-a-new-package)
    - [Front end](#frontend-dev)

## Development

### Visual studio
   - Install visual studio
   - Install nodejs (we build against v12, but any modern version should work)
   - (optional) Copy ./src/appsettings.json ./src/appsettings.Development.json` to generate the development configuration
   - Open the solution file and click "debug" and then "Start debugging" (It runs `npm install`, so it will take a while)
   - Open http://localhost:5000

### Dotnet core

#### First time run
- Install the dotnet SDK v5
- Install nodejs (we build against v12, but any modern version should work)
- Install `make`
- Run `cp ./src/appsettings.json ./src/appsettings.Development.json` to generate the development configuration

#### Actions for updating the project
- Run `make restore`to install dependencies
- Run `make migrate` to get the latest schema changes
- Run `make build` to generate the frontend app (It runs `npm install`, so it will take a while)
- Run `make dev` to start the development server and navigate to http://localhost:5000

#### Actions for saving changes to the db schema
- Run `cd src` to use the src project
- Run `dotnet ef migrations add <YOUR_MIGRATION_NAME>`

#### Install a new package
- Run `cd src` to use the src project
- Run `dotnet add package <package_name>` to add the new package

### Frontend devs
- Run `npm i` to install dependencies
- Follow the backend development server [instuctions](#first-time-run)
- Run `npm run dev` to start the front end development server and navigate to http://localhost:3000
- (optional) Run `npm run storybook` to start the storybook server and navigate to http://localhost:3003
