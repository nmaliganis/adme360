FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-stretch-slim
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-stretch
WORKDIR /app
COPY /app .
ENTRYPOINT ["dotnet", "./adme360-auth.api.dll"]