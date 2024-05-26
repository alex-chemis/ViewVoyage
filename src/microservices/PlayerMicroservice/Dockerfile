# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/microservices/PlayerMicroservice/PlayerMicroservice.csproj", "microservices/PlayerMicroservice/"]
COPY src/middlewares middlewares/
RUN dotnet restore "microservices/PlayerMicroservice/PlayerMicroservice.csproj"

WORKDIR "/src/microservices/PlayerMicroservice"
COPY src/microservices/PlayerMicroservice .
RUN dotnet build "PlayerMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlayerMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
RUN mkdir -p /root/.aws
COPY .aws/config /root/.aws
COPY .aws/credentials /root/.aws
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlayerMicroservice.dll"]