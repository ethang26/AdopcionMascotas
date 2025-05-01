# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY AdopcionMascotas/*.csproj ./AdopcionMascotas/
RUN dotnet restore

COPY AdopcionMascotas/. ./AdopcionMascotas/
WORKDIR /app/AdopcionMascotas
RUN dotnet publish -c Release -o out

# Etapa 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/AdopcionMascotas/out ./
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "AdopcionMascotas.dll"]
