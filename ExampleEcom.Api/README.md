# ExampleEcom.API
## The application layer

As per [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice#layers-in-ddd-microservices), examples of what should be stored in the application layer are:
- ASP.NET Web API
- Network access to microservice
- API contracts/implementation
- Commands and command handlers
- Queries (when using a CQS approach):
  - Micro ORM's like Dapper