FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Reservation/Registration.ClientWebApi/Registration.ClientWebApi.csproj Sample/Reservation/Registration.ClientWebApi/
COPY Sample/Reservation/Registration.Application/Registration.Application.csproj Sample/Reservation/Registration.Application/
COPY Sample/SaaSEqt/IdentityAccess/Application/SaaSEqt.Application.csproj Sample/SaaSEqt/IdentityAccess/Application/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess/SaaSEqt.IdentityAccess.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess/
COPY Sample/SaaSEqt/Common/SaaSEqt.Common.csproj Sample/SaaSEqt/Common/
COPY Sample/Reservation/Registration.Infra.Data/Registration.Infra.Data.csproj Sample/Reservation/Registration.Infra.Data/
COPY Sample/Reservation/Registration.Domain/Registration.Domain.csproj Sample/Reservation/Registration.Domain/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Sample/Reservation/Business.Contracts/Business.Contracts.csproj Sample/Reservation/Business.Contracts/
COPY Sample/Infrastructure/Infrastructure.csproj Sample/Infrastructure/
COPY Sample/Reservation/Registration.Contracts/Registration.Contracts.csproj Sample/Reservation/Registration.Contracts/
COPY Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/SaaSEqt.IdentityAccess.Infra.Data.csproj Sample/SaaSEqt/IdentityAccess/IdentityAccess.Infra.Data/
COPY Framework/CqrsFramework.Bus.RabbitMQ/CqrsFramework.Bus.RabbitMQ.csproj Framework/CqrsFramework.Bus.RabbitMQ/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Reservation/Registration.ClientWebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Registration.ClientWebApi.dll"]
