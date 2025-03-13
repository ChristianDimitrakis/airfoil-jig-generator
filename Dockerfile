# Use .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /app

# Copy project files
COPY . .

# List contents of the directory for debugging
RUN ls -la /app

# Restore dependencies and build
RUN dotnet restore ./AirfoilJigTool/AirfoilJigTool.csproj
RUN dotnet publish ./AirfoilJigTool/AirfoilJigTool.csproj -c Release -o /app/publish

# Use .NET runtime image for execution
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Set working directory
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish /app/publish

# Set entry point to run the application
ENTRYPOINT ["dotnet", "/app/publish/AirfoilJigTool.dll"]