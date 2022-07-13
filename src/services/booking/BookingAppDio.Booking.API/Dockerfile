FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/booking/BookingAppDio.Booking.API/BookingAppDio.Booking.API.csproj", "BookingAppDio.Booking.API/"]
RUN dotnet restore "src/services/booking/BookingAppDio.Booking.API/BookingAppDio.Booking.API.csproj"
COPY . .
WORKDIR "/src/BookingAppDio.Booking.API"
RUN dotnet build "BookingAppDio.Booking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingAppDio.Booking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingAppDio.Booking.API.dll"]
