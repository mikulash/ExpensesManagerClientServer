# Architecture

MVC architecture with a layered architecture pattern. Frontend is set up to be React, however not implemented.

Uses controller -> facade -> service -> repository pattern.

1. Controller:
   Manages the HTTP request and response lifecycle.
2. Facade:
   Simplifies the interaction with the service layer. Validations, error handling to correct http status codes.
   Provides a unified interface for the controller, aggregating calls to multiple services.
3. Service:
   business logic. talks to local and cloud repositories.
4. Repository:
   Manages data access and persistence.
   Encapsulates the logic required to query, save, and update data.
   Abstracts the data access details, easier to swap out data storage implementations if necessary.

## DB seeding

on first run, the db will be seeded with one user, his default categories, some incomes and expenses
username: 'seededUser'
password: 'SeededUser123!'
for more info see [Data/DbInitializer.cs](./Data/DbInitializer.cs)

## how to run tests

in ExpensesManager folder run `dotnet test`
test coverage of ExpensesManager.Server project: **81%** 

## frontend data fetching

for data fetching code I used OpenApi generator. It used swagger.json generated from controllers with
Swashbuckle.AspNetCore.
