#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Cargo/DrakeShop.Cargo.WebApi/DrakeShop.Cargo.WebApi.csproj", "Services/Cargo/DrakeShop.Cargo.WebApi/"]
COPY ["Services/Cargo/DrakeShop.Cargo.BusinessLayer/DrakeShop.Cargo.BusinessLayer.csproj", "Services/Cargo/DrakeShop.Cargo.BusinessLayer/"]
COPY ["Services/Cargo/DrakeShop.Cargo.DataAccessLayer/DrakeShop.Cargo.DataAccessLayer.csproj", "Services/Cargo/DrakeShop.Cargo.DataAccessLayer/"]
COPY ["Services/Cargo/DrakeShop.Cargo.EntityLayer/DrakeShop.Cargo.EntityLayer.csproj", "Services/Cargo/DrakeShop.Cargo.EntityLayer/"]
COPY ["Services/Cargo/DrakeShop.Cargo.DtoLayer/DrakeShop.Cargo.DtoLayer.csproj", "Services/Cargo/DrakeShop.Cargo.DtoLayer/"]
RUN dotnet restore "./Services/Cargo/DrakeShop.Cargo.WebApi/DrakeShop.Cargo.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Cargo/DrakeShop.Cargo.WebApi"
RUN dotnet build "./DrakeShop.Cargo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DrakeShop.Cargo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrakeShop.Cargo.WebApi.dll"]