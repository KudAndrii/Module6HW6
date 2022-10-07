FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /api-app

COPY IdentityApiApp.sln ./
COPY IdentityApiApp/*.csproj ./IdentityApiApp/

RUN dotnet restore

COPY . ./
RUN dotnet publish IdentityApiApp.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:5141
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /api-app
COPY --from=build-env /api-app/out .

EXPOSE 7141
EXPOSE 7030
EXPOSE 7184
ENTRYPOINT ["dotnet", "IdentityApiApp.dll"]