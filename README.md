# Digitalized Fabrication Business

A .NET application with a GraphQL API for managing a digitalized fabrication business.

## Project Status

This project is currently in development.

## Getting Started

### Prerequisites

- .NET 9 SDK
- PostgreSQL

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```bash
   cd DigitalizedFabricationBusiness
   ```
3. Restore the .NET packages:
   ```bash
   dotnet restore
   ```
4. Configure the database connection string in `appsettings.json`.

## Usage

To run the application, execute the following command:

```bash
dotnet run
```

The GraphQL API will be available at `https://localhost:5001/graphql`.

## API

This project uses a GraphQL API for all data operations. The schema is defined in the `GraphQL` directory.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
