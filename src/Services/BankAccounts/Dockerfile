# Pulling a base Docker image which has .NET 8.0 and ASP.NET 8.0 installed
# This base image will be the one where the build publish the bundle
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

WORKDIR /app

# Expose the port where the API resides (inside the container)
EXPOSE 80

# Starting a new build stage named build, which uses a Docker image with the .NET 8.0 SDK installed. 
# This SDK is needed to build the .NET project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# These are copying the .csproj files from your local machine to the Docker container
COPY ["src/Services/BankAccounts/BankAccounts.API/BankAccounts.API.csproj", "src/Services/BankAccounts/BankAccounts.API/"]
COPY ["src/Services/BankAccounts/BankAccounts.Application/BankAccounts.Application.csproj", "src/Services/BankAccounts/BankAccounts.Application/"]
COPY ["src/Services/BankAccounts/BankAccounts.Domain/BankAccounts.Domain.csproj", "src/Services/BankAccounts/BankAccounts.Domain/"]
COPY ["src/Services/BankAccounts/BankAccounts.InfraRead/BankAccounts.InfraRead.csproj", "src/Services/BankAccounts/BankAccounts.InfraRead/"]

# Nuget packages
RUN dotnet restore "src/Services/BankAccounts/BankAccounts.API/BankAccounts.API.csproj"
# Copying the rest of the files from the API
COPY . .
WORKDIR "src/Services/BankAccounts/BankAccounts.API"
# Builds the project in the Release configuration and outputs the build to the /app/build directory in the Docker container
RUN dotnet build "BankAccounts.API.csproj" -c Release -o /app/build

FROM build AS publish
# Publishes the project, which compiles the application
RUN dotnet publish "BankAccounts.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage using the base image as the start point
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=America/Sao_Paulo

# Run the project when the docker container spins up
ENTRYPOINT ["dotnet", "BankAccounts.API.dll"]