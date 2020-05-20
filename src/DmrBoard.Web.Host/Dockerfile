#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/DmrBoard.Host/DmrBoard.Host.csproj", "src/DmrBoard.Host/"]
RUN dotnet restore "src/DmrBoard.Host/DmrBoard.Host.csproj"
COPY . .
WORKDIR "/src/src/DmrBoard.Host"
RUN dotnet build "DmrBoard.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DmrBoard.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DmrBoard.Host.dll"]