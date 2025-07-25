# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (default for debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# Installs necessary dependencies for Node.js and Angular CLI
RUN apt-get update \
    && apt-get install -y curl \
    && curl -sL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g @angular/cli
# Sets the working directory for the build
WORKDIR /src
# Copies the project files to restore .NET dependencies
COPY ["WebApp.Server/WebApp.Server.csproj", "WebApp.Server/"]
COPY ["webapp.client/webapp.client.esproj", "webapp.client/"]
# Restores .NET dependencies
RUN dotnet restore "./WebApp.Server/WebApp.Server.csproj"
# Copies the rest of the source code to the container
COPY . .
# (Optional) Creates the folder that some scripts expect for the Angular build
RUN mkdir -p /src/webapp.client/obj/Release
# Builds the .NET project (this also runs the Angular build if configured in the .csproj)
RUN dotnet build "./WebApp.Server/WebApp.Server.csproj" -c Release -o /app/build
# Sets the working directory for publishing
WORKDIR "/src/WebApp.Server"
# Publishes the .NET application in Release mode
RUN dotnet publish "./WebApp.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: lightweight image with only runtime and published files
FROM base AS final
WORKDIR /app
# Copies the published files from the build stage
COPY --from=build /app/publish .
# Sets the entrypoint to run the ASP.NET Core application
ENTRYPOINT ["dotnet", "WebApp.Server.dll"]
