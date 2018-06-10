FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CqrsFramework.sln ./
COPY Sample/Make_a_Reservation/Business.Api/Business.Api.csproj Sample/Make_a_Reservation/Business.Api/
COPY Framework/CqrsFramework/CqrsFramework.csproj Framework/CqrsFramework/
COPY Framework/CqrsFramework.Extensions/CqrsFramework.Extensions.csproj Framework/CqrsFramework.Extensions/
COPY Framework/CqrsFramework.EventStore.MongoDB/CqrsFramework.EventStore.MongoDB.csproj Framework/CqrsFramework.EventStore.MongoDB/
COPY Sample/Make_a_Reservation/Business.Domain/Business.Domain.csproj Sample/Make_a_Reservation/Business.Domain/
COPY Sample/Make_a_Reservation/Registration.Infra.Data/Registration.Infra.Data.csproj Sample/Make_a_Reservation/Registration.Infra.Data/
COPY Sample/Make_a_Reservation/Registration.Domain/Registration.Domain.csproj Sample/Make_a_Reservation/Registration.Domain/
COPY Sample/Make_a_Reservation/Business.Application/Business.Application.csproj Sample/Make_a_Reservation/Business.Application/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Sample/Make_a_Reservation/Business.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Business.Api.dll"]
