FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Reservation/Business.WebApi/Business.WebApi.csproj Sample/Reservation/Business.WebApi/
COPY Sample/Reservation/Business.Application/Business.Application.csproj Sample/Reservation/Business.Application/
COPY Sample/Reservation/Business.Domain/Business.Domain.csproj Sample/Reservation/Business.Domain/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Sample/Infrastructure/Infrastructure.csproj Sample/Infrastructure/
COPY Sample/SaaSEqt/Common/SaaSEqt.Common.csproj Sample/SaaSEqt/Common/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess/SaaSEqt.IdentityAccess.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess/
COPY Sample/SaaSEqt/IdentityAccess/Application/SaaSEqt.Application.csproj Sample/SaaSEqt/IdentityAccess/Application/
COPY Framework/CqrsFramework.EventStore.MongoDB/CqrsFramework.EventStore.MongoDB.csproj Framework/CqrsFramework.EventStore.MongoDB/
COPY Sample/Reservation/Business.Infra.Data/Business.Infra.Data.csproj Sample/Reservation/Business.Infra.Data/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/SaaSEqt.IdentityAccess.Infra.Data.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Reservation/Business.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Business.WebApi.dll"]
