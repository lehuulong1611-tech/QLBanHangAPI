# Bước 1: Biên dịch code C#
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["QLBanHangAPI.csproj", "./"]
RUN dotnet restore "./QLBanHangAPI.csproj"
COPY . .
RUN dotnet publish "QLBanHangAPI.csproj" -c Release -o /app/publish

# Bước 2: Môi trường chạy chuẩn, cài thêm Node.js để chạy file proxy
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY proxy.js .

# Cài Node.js siêu tốc vào môi trường chạy
RUN apt-get update && apt-get install -y nodejs && rm -rf /var/lib/apt/lists/*

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Lệnh khởi chạy: Bật proxy ngầm trước, sau đó bật API C#
ENTRYPOINT node proxy.js & dotnet QLBanHangAPI.dll
