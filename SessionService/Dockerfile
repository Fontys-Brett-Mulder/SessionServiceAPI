FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY SessionService.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish "SessionService.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "./SessionService.dll"]
