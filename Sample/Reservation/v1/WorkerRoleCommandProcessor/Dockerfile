FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Reservation/v1/WorkerRoleCommandProcessor/WorkerRoleCommandProcessor.csproj Sample/Reservation/v1/WorkerRoleCommandProcessor/
COPY Framework/CqrsFramework.Bus.RabbitMQ/CqrsFramework.Bus.RabbitMQ.csproj Framework/CqrsFramework.Bus.RabbitMQ/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Sample/Reservation/v1/Business/Business.Contracts/Business.Contracts.csproj Sample/Reservation/v1/Business/Business.Contracts/
COPY Sample/SaaSEqt/Common/SaaSEqt.Common.csproj Sample/SaaSEqt/Common/
COPY Sample/Reservation/v1/Registration/Registration.Infra.Data/Registration.Infra.Data.csproj Sample/Reservation/v1/Registration/Registration.Infra.Data/
COPY Sample/Reservation/v1/Registration/Registration.Domain/Registration.Domain.csproj Sample/Reservation/v1/Registration/Registration.Domain/
COPY Sample/Reservation/v1/Registration/Registration.Contracts/Registration.Contracts.csproj Sample/Reservation/v1/Registration/Registration.Contracts/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Sample/Reservation/v1/Infrastructure.IoC/Infrastructure.IoC.csproj Sample/Reservation/v1/Infrastructure.IoC/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Reservation/v1/WorkerRoleCommandProcessor
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WorkerRoleCommandProcessor.dll"]
