#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Sets the user context to a non-root user named app. Running as a non-root user enhances security.
USER app

# Sets the working directory inside the container to /app. 
# All subsequent commands in this stage will be executed within this directory.
WORKDIR /app

# Thee application will listen on ports 8080 and 8081
EXPOSE 8080
EXPOSE 8081

# Builder stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web_API_V1.csproj", "."]
RUN dotnet restore "./Web_API_V1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Web_API_V1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web_API_V1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Alpine Linux version of the ASP.NET Core runtime image, which is minimal
# This helps reduce the overall size of the container.
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_API_V1.dll"]