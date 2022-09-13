FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClientService.csproj", "."]
RUN dotnet restore "ClientService.csproj"
COPY . .
RUN dotnet build "ClientService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientService.dll"]
