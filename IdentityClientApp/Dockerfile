FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /client-app

COPY IdentityClientApp.sln ./
COPY IdentityClientApp/*.csproj ./IdentityClientApp/

RUN dotnet restore

COPY . ./
RUN dotnet publish IdentityClientApp.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:5030
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /client-app
COPY --from=build-env /client-app/out .

EXPOSE 7141
EXPOSE 7030
EXPOSE 7184
ENTRYPOINT ["dotnet", "IdentityClientApp.dll"]