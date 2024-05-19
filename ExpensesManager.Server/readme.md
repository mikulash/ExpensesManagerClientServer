# Architecture
Uses controller -> facade -> service -> repository pattern.

1. Controller:
Manages the HTTP request and response lifecycle.
Orchestrates the flow of data to and from the client.
Delegates business logic processing to the service layer.
2. Facade:
Simplifies the interaction with the service layer.
Provides a unified interface for the controller, often aggregating calls to multiple services.
Helps in managing complex workflows and business processes.
3. Service:
Contains business logic.
Acts as an intermediary between the controller and the repository.
May interact with multiple repositories and other services to fulfill business requirements.
4. Repository:
Manages data access and persistence.
Encapsulates the logic required to query, save, and update data.
Abstracts the data access details, making it easier to swap out data storage implementations if needed.
