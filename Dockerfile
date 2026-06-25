# Bước 1: Biên dịch code dùng SDK 8.0 buster (Linux cũ hơn)
FROM mcr.microsoft.com/dotnet/sdk:8.0-buster-slim AS build
WORKDIR /src
COPY ["QLBanHangAPI.csproj", "./"]
RUN dotnet restore "./QLBanHangAPI.csproj"
COPY . .
RUN dotnet publish "QLBanHangAPI.csproj" -c Release -o /app/publish

# Bước 2: Chạy API dùng Runtime buster để hạ chuẩn bảo mật OpenSSL hệ thống xuống
FROM mcr.microsoft.com/dotnet/aspnet:8.0-buster-slim AS final
WORKDIR /app
COPY --from=build /app/publish .

# Thiết lập cổng chạy cho Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "QLBanHangAPI.dll"]
