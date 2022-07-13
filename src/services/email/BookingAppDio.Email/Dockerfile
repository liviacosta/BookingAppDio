FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/email/BookingAppDio.Email/BookingAppDio.Email.csproj", "BookingAppDio.Email/"]
RUN dotnet restore "src/services/email/BookingAppDio.Email/BookingAppDio.Email.csproj"
COPY . .
WORKDIR "/src/BookingAppDio.Email"
RUN dotnet build "BookingAppDio.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingAppDio.Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingAppDio.Email.dll"]
