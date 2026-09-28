# JWT Authentication API

A simple ASP.NET Core Web API project demonstrating JWT-based authentication and authorization with SQL Server.

## Features

* User Registration
* User Login
* BCrypt Password Hashing
* JWT Token Generation
* JWT Token Validation
* Claims
* Protected API using `[Authorize]`
* Swagger Bearer Authentication
* SQL Server with Entity Framework Core
* 401 Unauthorized handling
* Role information in JWT claims

## Technologies Used

* C#
* ASP.NET Core Web API
* .NET 10
* Entity Framework Core
* SQL Server
* JWT
* BCrypt
* Swagger / OpenAPI

## API Flow

```text
Register
   ↓
Password Hashing
   ↓
User Stored in SQL Server
   ↓
Login
   ↓
JWT Token Generated
   ↓
Swagger Authorization
   ↓
Protected API
   ↓
JWT Validation
   ↓
Access Granted
```

## API Endpoints

### Authentication

**Register**

```text
POST /api/Auth/Register
```

Used to register a new user.

**Login**

```text
POST /api/Auth/Login
```

Used to authenticate a user and generate a JWT token.

### Protected API

```text
GET /api/Test/protected
```

Requires a valid JWT token.

## Testing with Swagger

1. Register a user.
2. Login using the registered credentials.
3. Copy the generated JWT token.
4. Click **Authorize** in Swagger.
5. Enter the JWT token.
6. Execute the protected API.
7. A valid token returns:

```text
200 OK
You have access to protected API
```

## Configuration

Database connection and JWT configuration are stored in `appsettings.json`.

For security reasons, sensitive configuration such as database passwords and JWT secret keys should not be committed to GitHub.

## Project Status

This project is currently focused on implementing the core JWT authentication and protected API workflow.
