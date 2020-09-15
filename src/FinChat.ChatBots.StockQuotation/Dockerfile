#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./FinChat.ChatBots.StockQuotation/FinChat.ChatBots.StockQuotation.csproj", "FinChat.ChatBots.StockQuotation/"]
COPY ["./FinChat.Infra.Core.IoC/FinChat.Infra.Core.IoC.csproj", "FinChat.Infra.Core.IoC/"]
COPY ["./FinChat.Domain.Core/FinChat.Domain.Core.csproj", "FinChat.Domain.Core/"]
COPY ["./FinChat.Infra.Core.Bus/FinChat.Infra.Core.Bus.csproj", "FinChat.Infra.Core.Bus/"]
RUN dotnet restore "FinChat.ChatBots.StockQuotation/FinChat.ChatBots.StockQuotation.csproj"
COPY . .
WORKDIR "FinChat.ChatBots.StockQuotation"
RUN dotnet build "FinChat.ChatBots.StockQuotation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinChat.ChatBots.StockQuotation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinChat.ChatBots.StockQuotation.dll"]