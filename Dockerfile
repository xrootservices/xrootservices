# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o out

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the build output from the first stage
COPY --from=build /app/out .

# Start the app (replace MyWebApp.dll with your actual DLL name)
ENTRYPOINT ["dotnet", "xRootServices.dll"]
