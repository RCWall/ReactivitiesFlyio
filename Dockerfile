FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# copy .csproj and restore as distinct layers

COPY "Reactivities.sln" "Reactivities.sln"
COPY "API/API.csproj" "API/API.csproj"
COPY "Application/Application.csproj" "Application/Application.csproj"
COPY "Domain/Domain.csproj" "Domain/Domain.csproj"
COPY "Persistence/Persistence.csproj" "Persistence/Persistence.csproj"

RUN dotnet restore "Reactivities.sln"

# copy everything else and build app
COPY . .
WORKDIR /app
RUN dotnet publish  -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR  /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "API.dll" ]
