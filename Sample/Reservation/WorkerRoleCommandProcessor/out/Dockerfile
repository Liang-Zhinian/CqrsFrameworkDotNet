FROM microsoft/dotnet:2.0-runtime AS base

RUN mkdir /book2workerrole/
WORKDIR ./book2workerrole

COPY . /book2workerrole/
ENTRYPOINT ["dotnet", "WorkerRoleCommandProcessor.dll"]
