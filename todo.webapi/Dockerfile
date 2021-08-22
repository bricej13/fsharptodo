FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["todo.webapi/todo.webapi.fsproj", "todo.webapi/"]
RUN dotnet restore "todo.webapi/todo.webapi.fsproj"
COPY . .
WORKDIR "/src/todo.webapi"
RUN dotnet build "todo.webapi.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "todo.webapi.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "todo.webapi.dll"]
