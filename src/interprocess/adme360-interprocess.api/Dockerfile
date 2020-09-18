FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 6300
ENV ASPNETCORE_URLS=http://+:6300

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /magic-button-collector.api
COPY . .
RUN dotnet restore "magic-button-collector.api.csproj"
RUN dotnet build "magic-button-collector.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "magic-button-collector.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "magic-button-collector.api.dll", "--server.urls", "http://0.0.0.0:6300"]