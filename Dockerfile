#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5142

ENV DOTNET_URLS=http://+:5142

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ParcelTrackingRUs/ParcelTrackingRUs.csproj", "ParcelTrackingRUs/"]
RUN dotnet restore "ParcelTrackingRUs/ParcelTrackingRUs.csproj"
COPY . .
WORKDIR "/src/ParcelTrackingRUs"
RUN dotnet build "ParcelTrackingRUs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParcelTrackingRUs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParcelTrackingRUs.dll"]