FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/passenger/BookingAppDio.Passenger/BookingAppDio.Passenger.csproj", "BookingAppDio.Passenger/"]
RUN dotnet restore "src/services/passenger/BookingAppDio.Passenger/BookingAppDio.Passenger.csproj"
COPY . .
WORKDIR "/src/BookingAppDio.Passenger"
RUN dotnet build "BookingAppDio.Passenger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingAppDio.Passenger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingAppDio.Passenger.dll"]
