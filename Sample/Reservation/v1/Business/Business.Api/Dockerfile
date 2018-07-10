FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Reservation/v1/Business/Business.Api/Business.Api.csproj Sample/Reservation/v1/Business/Business.Api/
COPY Sample/Reservation/v1/Infrastructure.IoC/Infrastructure.IoC.csproj Sample/Reservation/v1/Infrastructure.IoC/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Framework/CqrsFramework.Bus.RabbitMQ/CqrsFramework.Bus.RabbitMQ.csproj Framework/CqrsFramework.Bus.RabbitMQ/
COPY Sample/Reservation/v1/Business/Business.Application/Business.Application.csproj Sample/Reservation/v1/Business/Business.Application/
COPY Sample/Reservation/v1/Business/Business.Domain/Business.Domain.csproj Sample/Reservation/v1/Business/Business.Domain/
COPY Sample/Reservation/v1/Business/Business.Contracts/Business.Contracts.csproj Sample/Reservation/v1/Business/Business.Contracts/
COPY Sample/SaaSEqt/Common/SaaSEqt.Common.csproj Sample/SaaSEqt/Common/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess/SaaSEqt.IdentityAccess.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Framework/CqrsFramework.EventStore.IntegrationEventLogEF/CqrsFramework.EventStore.IntegrationEventLogEF.csproj Framework/CqrsFramework.EventStore.IntegrationEventLogEF/
COPY Sample/SaaSEqt/IdentityAccess/Application/SaaSEqt.Application.csproj Sample/SaaSEqt/IdentityAccess/Application/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/SaaSEqt.IdentityAccess.Infra.Data.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/
COPY Sample/Reservation/v1/Business/Business.Infra.Data/Business.Infra.Data.csproj Sample/Reservation/v1/Business/Business.Infra.Data/
COPY Framework/CqrsFramework.EventStore.MongoDB/CqrsFramework.EventStore.MongoDB.csproj Framework/CqrsFramework.EventStore.MongoDB/
COPY Sample/Infrastructure/HealthChecks/src/Microsoft.AspNetCore.HealthChecks/Microsoft.AspNetCore.HealthChecks.csproj Sample/Infrastructure/HealthChecks/src/Microsoft.AspNetCore.HealthChecks/
COPY Sample/Infrastructure/HealthChecks/src/Microsoft.Extensions.HealthChecks/Microsoft.Extensions.HealthChecks.csproj Sample/Infrastructure/HealthChecks/src/Microsoft.Extensions.HealthChecks/
COPY Sample/Infrastructure/HealthChecks/src/Microsoft.Extensions.HealthChecks.SqlServer/Microsoft.Extensions.HealthChecks.SqlServer.csproj Sample/Infrastructure/HealthChecks/src/Microsoft.Extensions.HealthChecks.SqlServer/
COPY Sample/Infrastructure/WebHostCustomization/WebHost.Customization/WebHost.Customization.csproj Sample/Infrastructure/WebHostCustomization/WebHost.Customization/
COPY Sample/Infrastructure/HealthChecks/src/HealthChecks.MySQL/HealthChecks.MySQL.csproj Sample/Infrastructure/HealthChecks/src/HealthChecks.MySQL/
COPY Sample/SaaSEqt/SaaSEqt.IdentityAccess.Infra.Services/SaaSEqt.IdentityAccess.Infra.Services.csproj Sample/SaaSEqt/SaaSEqt.IdentityAccess.Infra.Services/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Reservation/v1/Business/Business.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Business.Api.dll"]
