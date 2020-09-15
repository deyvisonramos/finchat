#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000/tcp
EXPOSE 5001/tcp

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./FinChat.Chat.Web/FinChat.Chat.Web.csproj", "FinChat.Chat.Web/"]
COPY ["./FinChat.Chat.IoC/FinChat.Chat.IoC.csproj", "FinChat.Chat.IoC/"]
COPY ["./FinChat.Chat.Application/FinChat.Chat.Application.csproj", "FinChat.Chat.Application/"]
COPY ["./FinChat.Domain.Core/FinChat.Domain.Core.csproj", "FinChat.Domain.Core/"]
COPY ["./FinChat.Chat.Domain/FinChat.Chat.Domain.csproj", "FinChat.Chat.Domain/"]
COPY ["./FinChat.Chat.Data/FinChat.Chat.Data.csproj", "FinChat.Chat.Data/"]
COPY ["./FinChat.Chat.WebSocket/FinChat.Chat.WebSocket.csproj", "FinChat.Chat.WebSocket/"]
COPY ["./FinChat.Infra.Core.IoC/FinChat.Infra.Core.IoC.csproj", "FinChat.Infra.Core.IoC/"]
COPY ["./FinChat.Infra.Core.Bus/FinChat.Infra.Core.Bus.csproj", "FinChat.Infra.Core.Bus/"]
RUN dotnet restore "FinChat.Chat.Web/FinChat.Chat.Web.csproj"
COPY . .
WORKDIR "FinChat.Chat.Web"
RUN dotnet build "FinChat.Chat.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinChat.Chat.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinChat.Chat.Web.dll"]