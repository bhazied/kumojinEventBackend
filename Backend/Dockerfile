#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Generate a self-signed certificate
# RUN mkdir -p /app/https && \
#     openssl req -x509 -newkey rsa:4096 -sha256 -days 3650 -nodes \
#     -keyout /app/https/private.key -out /app/https/certificate.crt \
#     -subj "/C=CA/ST=QC/L=City/O=Kumojin/CN=localhost" && \
#     openssl pkcs12 -export -out /app/https/aspnetapp.pfx \
#     -inkey /app/https/private.key -in /app/https/certificate.crt \
#     -password pass:kumojin2024


# Setup environment variables for the application to find the certificate
# ENV ASPNETCORE_URLS=http://+:80;https://+:443
# ENV ASPNETCORE_Kestrel__Certificates__Default__Password="kumojin2024"
# ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/https/aspnetapp.pfx"
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KumojinEvents.sln", "KumojinEvents.sln"]
COPY ["Kumojin.Events.Migrator/Kumojin.Events.Migrator.csproj", "Kumojin.Events.Migrator/"]

COPY ["Kumojin.Events.Api/Kumojin.Events.Api.csproj", "Kumojin.Events.Api/"]
COPY ["Kumojin.Events.Model/Kumojin.Events.Model.csproj", "Kumojin.Events.Model/"]
COPY ["Kumojin.Events.Application/Kumojin.Events.Application.csproj", "Kumojin.Events.Application/"]
COPY ["Kumojin.Events.Infrastructure/Kumojin.Events.Infrastructure.csproj", "Kumojin.Events.Infrastructure/"]
COPY ./Nuget.Config .
RUN dotnet nuget locals all --clear
RUN dotnet restore "Kumojin.Events.Api/Kumojin.Events.Api.csproj"
COPY . .
WORKDIR /src/Kumojin.Events.Api

RUN dotnet build "Kumojin.Events.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Kumojin.Events.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Kumojin.Events.Api.dll"]