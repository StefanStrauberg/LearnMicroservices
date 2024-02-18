FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=5000

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["Services/Catalog/Catalog.API/Catalog.API.csproj", "Services/Catalog/Catalog.API/"]
RUN dotnet restore "Services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]