#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityServer/DrakeShop.IdentityServer/DrakeShop.IdentityServer.csproj", "IdentityServer/DrakeShop.IdentityServer/"]
RUN dotnet restore "./IdentityServer/DrakeShop.IdentityServer/DrakeShop.IdentityServer.csproj"
COPY . .
WORKDIR "/src/IdentityServer/DrakeShop.IdentityServer"
RUN dotnet build "./DrakeShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DrakeShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrakeShop.IdentityServer.dll"]