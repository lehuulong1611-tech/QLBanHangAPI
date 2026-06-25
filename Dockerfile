# Bước 1: Biên dịch code (Dùng bản chuẩn 8.0)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["QLBanHangAPI.csproj", "./"]
RUN dotnet restore "./QLBanHangAPI.csproj"
COPY . .
RUN dotnet publish "QLBanHangAPI.csproj" -c Release -o /app/publish

# Bước 2: Chạy API với Runtime chuẩn
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Thiết lập cổng chạy cho Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "QLBanHangAPI.dll"]
