# CleanArchitectureNetApp

This project is a C# application implementing Clean Architecture, based on the course [ASP.NET Core Clean Architecture](https://www.udemy.com/course/aspnet-clean-architecture) by Udemy. The goal is to provide a modular, scalable, and maintainable code structure.

## Project Structure

The project is organized into the following modules:

- **CleanArchitecture.API**: Contains the controllers and API configuration.
- **CleanArchitecture.Application**: Includes business logic and use case interfaces.
- **CleanArchitecture.ConsoleApp**: Provides a console application to interact with the system.
- **CleanArchitecture.Data**: Manages data access and repository implementations.
- **CleanArchitecture.Domain**: Defines the domain entities and interfaces.
- **CleanArchitecture.Identity**: Handles user authentication and authorization.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later.
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended for development).
- Microsoft SQL Server Management Studio (for the database).
- Postman

## Architecture Used

The project is built using **Clean Architecture** (also known as Hexagonal Architecture or Onion Architecture). This architecture ensures:

1. Separation of concerns by dividing the application into independent layers.
2. Independence from external frameworks.
3. Easy testability and maintainability.

Additionally, the project uses **CQRS** (Command Query Responsibility Segregation), **Mediator Pattern**, and **Unit of Work Pattern** to improve scalability, separation of concerns, and maintainability.

### What is CQRS?

**CQRS** is a pattern that separates the reading (querying) and writing (commanding) operations of the application. Instead of using the same data model for both reading and writing, it creates separate models for each, which can help optimize and scale the application more efficiently.

- **Commands**: These are actions that change the state of the system (e.g., creating, updating, or deleting data).
- **Queries**: These are actions that only read the data without changing the system's state.

By using CQRS, the system can scale more effectively, improve performance, and make it easier to maintain, especially in more complex applications.
### What is the Mediator Pattern?

The **Mediator Pattern** is a behavioral design pattern that restricts direct communication between components and forces them to communicate via a mediator object. The pattern promotes loose coupling, as components don't need to be aware of each other and can interact through the mediator instead.

In this project:

- **MediatR** is used to implement the **Mediator Pattern**.
- Commands and Queries are handled by their respective handlers, which are mediated by **MediatR**.
- The **Application Layer** defines request handlers that process specific commands or queries without having direct knowledge of each other. This reduces dependencies and simplifies maintenance.

For example:
- **Commands** (e.g., `CreateUserCommand`) are handled by a specific command handler.
- **Queries** (e.g., `GetUserByIdQuery`) are handled by a different query handler.

### What is the Unit of Work Pattern?

The **Unit of Work Pattern** is used to manage transactions in a way that ensures that all operations within a business transaction are either fully completed or fully rolled back. It provides a mechanism to track changes and coordinate the writing of changes to the database, ensuring consistency and atomicity.

In this project:

- The **Unit of Work Pattern** is implemented in the **Data Layer** through the `IUnitOfWork` interface.
- The **Unit of Work** manages the repositories and ensures that database operations are committed as a single unit.
- This ensures that any changes made in multiple repositories are saved or rolled back together, preventing partial updates that could lead to data inconsistency.

### How is CQRS, Mediator, and Unit of Work Used in This Project?

- **CQRS**: Commands and Queries are defined and handled separately in the `CleanArchitecture.Application` layer. **MediatR** is used to mediate the requests and execute the handlers.
- **Mediator**: The **MediatR** library handles the routing of commands and queries to their respective handlers, ensuring that the application components are decoupled.
- **Unit of Work**: The `IUnitOfWork` interface is used in the **CleanArchitecture.Data** layer to coordinate repository actions and ensure that database operations are executed in a consistent and atomic manner.

## External Packages Used

The following NuGet packages are used in this project:

- **Entity Framework Core**: For database access and ORM functionality.
- **MediatR**: For implementing the mediator pattern.
- **AutoMapper**: For object-to-object mapping.
- **FluentValidation**: For validating user input.
- **Microsoft.IdentityModel.Tokens**: For handling JWT-based authentication.

## Setup

### 1. Clone this repository

```bash
git clone https://github.com/alvaral/CleanArchitectureNetApp.git
```

### 2. Navigate to the project directory

```bash
cd CleanArchitectureNetApp
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Set up the SQL Server Database

The application requires a SQL Server database to store data. Follow these steps to create the database:

1. Open SQL Server Management Studio (SSMS) or any SQL management tool.
2. Connect to your SQL Server instance.
3. Create a new database by executing the following command:

   ```sql
   CREATE DATABASE CleanArchitectureDb;
   ```

4. Update the `appsettings.json` file in the **CleanArchitecture.API** project to include your connection string. Replace `YourServerName` with your SQL Server instance name:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YourServerName;Database=CleanArchitectureDb;Trusted_Connection=True;"
     }
   }
   ```

5. Apply migrations to initialize the database schema. Run the following command in the terminal:

   ```bash
   dotnet ef database update --project CleanArchitecture.Data
   ```

### 5. Run the Application

#### To run the console application:

```bash
dotnet run --project CleanArchitecture.ConsoleApp
```

#### To run the API:

```bash
dotnet run --project CleanArchitecture.API
```

### 6. Test the API

Once the API is running, you can test its endpoints using tools like [Postman](https://www.postman.com/) or [Swagger UI](https://swagger.io/tools/swagger-ui/), which is automatically available when the API is started.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`feature/new-feature`).
3. Make your changes and commit them (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.