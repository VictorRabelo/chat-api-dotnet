# Chat API

This project provides a simple chat backend built with **ASP.NET Core** following clean architecture principles. It exposes JWT-protected endpoints for user registration, login, chatting and messaging. SQLite is used for persistence via Entity Framework Core.

## Running locally

1. Ensure the .NET 8 SDK is installed.
2. Restore and build the project:
   ```bash
   dotnet build
   ```
3. Run database migrations and start the API:
   ```bash
   dotnet run --project ChatApi
   ```
   By default the API listens on `http://localhost:5000` and uses a SQLite database file `chat.db`.

Swagger UI is available at `/swagger` for interactive exploration of all endpoints.

## Configuration

Configuration values can be provided via `appsettings.json` or environment variables. Important keys:

- `ConnectionStrings:DefaultConnection` – SQLite connection string (default `Data Source=chat.db`).
- `JwtKey` – secret key used for JWT token generation.

## Docker

The project is ready to be dockerized. A basic Dockerfile can be:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY . ./
RUN dotnet publish ChatApi.csproj -c Release -o out
ENTRYPOINT ["dotnet", "out/ChatApi.dll"]
```

This will build and run the API inside a container.
