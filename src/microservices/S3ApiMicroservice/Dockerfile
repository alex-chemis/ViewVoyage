# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/microservices/S3ApiMicroservice/S3ApiMicroservice.csproj", "microservices/S3ApiMicroservice/"]
COPY src/middlewares middlewares/
RUN dotnet restore "microservices/S3ApiMicroservice/S3ApiMicroservice.csproj"

WORKDIR "/src/microservices/S3ApiMicroservice"
COPY src/microservices/S3ApiMicroservice .
RUN dotnet build "S3ApiMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S3ApiMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
RUN mkdir -p /root/.aws
COPY .aws/config /root/.aws
COPY .aws/credentials /root/.aws
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S3ApiMicroservice.dll"]