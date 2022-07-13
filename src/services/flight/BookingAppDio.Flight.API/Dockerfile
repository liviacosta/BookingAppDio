FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/flight/BookingAppDio.Flight.API/BookingAppDio.Flight.API.csproj", "BookingAppDio.Flight.API/"]
RUN dotnet restore "src/services/flight/BookingAppDio.Flight.API/BookingAppDio.Flight.API.csproj"
COPY . .
WORKDIR "/src/BookingAppDio.Flight.API"
RUN dotnet build "BookingAppDio.Flight.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingAppDio.Flight.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingAppDio.Flight.API.dll"]
