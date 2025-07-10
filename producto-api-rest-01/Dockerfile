FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY producto-api-rest-01.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /appcls
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "producto-api-rest-01.dll"]