FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /ids-app

COPY IdentityServerApp.sln ./
COPY *.csproj ./

RUN dotnet restore

COPY . ./
RUN dotnet publish IdentityServerApp.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:5221
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /ids-app
COPY --from=build-env /ids-app/out .

EXPOSE 7141
EXPOSE 7030
EXPOSE 7184
ENTRYPOINT ["dotnet", "IdentityServerApp.dll"]