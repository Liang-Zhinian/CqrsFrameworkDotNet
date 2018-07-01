FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Reservation/WorkerRoleCommandProcessor/WorkerRoleCommandProcessor.csproj Sample/Reservation/WorkerRoleCommandProcessor/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Sample/Reservation/Registration.Domain/Registration.Domain.csproj Sample/Reservation/Registration.Domain/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Sample/Reservation/Business.Contracts/Business.Contracts.csproj Sample/Reservation/Business.Contracts/
COPY Sample/SaaSEqt/Common/SaaSEqt.Common.csproj Sample/SaaSEqt/Common/
COPY Sample/Infrastructure/Infrastructure.csproj Sample/Infrastructure/
COPY Sample/Reservation/Registration.Contracts/Registration.Contracts.csproj Sample/Reservation/Registration.Contracts/
COPY Sample/Reservation/Registration.Infra.Data/Registration.Infra.Data.csproj Sample/Reservation/Registration.Infra.Data/
COPY Framework/CqrsFramework.Bus.RabbitMQ/CqrsFramework.Bus.RabbitMQ.csproj Framework/CqrsFramework.Bus.RabbitMQ/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Reservation/WorkerRoleCommandProcessor
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WorkerRoleCommandProcessor.dll"]
