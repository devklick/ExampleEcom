# ExampleEcom.Infrastructure
## The infrastructure layer

As per [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice#layers-in-ddd-microservices), examples of what should be stored in the infrastructure layer are:
- Data persistance infrastructure
  - Repository implementation
- Use of ORMs or data access API:
  - Entity Framework Core or any ORM
  - ADO.Net
  - Any NoSQL database API
- Other Infrastructure implementation used from the [application layer](../ExampleEcom.Api/../README.md)
  - Logging, cryptography, search engine, etc.