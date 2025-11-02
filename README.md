
# Digitalized Fabrication Business

This project is a .NET Core application for managing a digitalized fabrication business. It provides a GraphQL API for managing users, products, orders, and more.

## Overview

The project is built with a clean architecture, separating concerns into different layers:

-   **API (GraphQL):** Exposes the application's functionality through a GraphQL API.
-   **Services:** Contains the business logic of the application.
-   **Repositories:** Handles data access and persistence.
-   **Models:** Defines the data structures of the application.
-   **Data:** Manages the database connection and context.

## Features

*   **User Management:**
    *   User registration and login
    *   JWT-based authentication and authorization
    *   Role-based access control
*   **Product Management:**
    *   Create, read, update, and delete products
    *   Product filtering and pagination
*   **Order Management:**
    *   Create and manage orders
*   **Quotation Management:**
    *   Create and manage quotations
*   **Payment Management:**
    *   Process and track payments

## Technologies Used

*   **.NET 9:** The core framework for building the application.
*   **Entity Framework Core:** For data access and object-relational mapping (ORM).
*   **PostgreSQL:** The database used to store the application's data.
*   **GraphQL (Hot Chocolate):** For building the application's API.
*   **AutoMapper:** For object-to-object mapping.
*   **JWT (JSON Web Tokens):** For authentication and authorization.

## Getting Started

### Prerequisites

*   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
*   [PostgreSQL](https://www.postgresql.org/download/)
*   A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Installation

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/digitalized-fabrication-business.git
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd digitalized-fabrication-business
    ```
3.  **Configure the database connection:**
    *   Open the `appsettings.json` file.
    *   Update the `DefaultConnection` string with your PostgreSQL connection details.
4.  **Apply database migrations:**
    ```bash
    dotnet ef database update
    ```
5.  **Run the application:**
    ```bash
    dotnet run
    ```

The application will be running at `http://localhost:5000`.

## API Endpoints

The GraphQL API is available at `/graphql`. You can use a GraphQL client like [Banana Cake Pop](https://chillicream.com/docs/hotchocolate/v13/integrations/banana-cake-pop) to interact with the API.

## Project Structure

The project is organized into the following folders:

*   **ApplicationDbContext:** Contains the database context.
*   **DTOs:** Contains data transfer objects for transferring data between layers.
*   **GraphQL:** Contains the GraphQL schema, queries, mutations, and types.
*   **Mappers:** Contains AutoMapper profiles for object mapping.
*   **Middlewares:** Contains custom middleware for handling exceptions and errors.
*   **Models:** Contains the data models for the application.
*   **Properties:** Contains project configuration files.
*   **Repositories:** Contains the repositories for accessing data.
*   **Services:** Contains the business logic of the application.
*   **Utilities:** Contains utility classes and enums.

----
