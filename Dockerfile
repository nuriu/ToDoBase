FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 5000
ENV ASPNETCORE_URLS http://+:5000

COPY *.sln .
COPY ToDoBase.Api/* ./ToDoBase.Api/
COPY ToDoBase.Application/* ./ToDoBase.Application/
COPY ToDoBase.Core/* ./ToDoBase.Core/
COPY ToDoBase.Persistence/* ./ToDoBase.Persistence/
COPY ToDoBase.Tests/* ./ToDoBase.Tests/
RUN dotnet restore

RUN dotnet publish -o ToDoBase

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/ToDoBase .
ENTRYPOINT ["dotnet", "ToDoBase.Api.dll"]
