FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY . ./
RUN dotnet publish ChatApi.csproj -c Release -o out
ENTRYPOINT ["dotnet", "out/ChatApi.dll"]
