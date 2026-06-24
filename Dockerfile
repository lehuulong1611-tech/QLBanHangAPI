# Bước 1: Biên dịch code (Giữ nguyên)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["QLBanHangAPI.csproj", "./"]
RUN dotnet restore "./QLBanHangAPI.csproj"
COPY . .
RUN dotnet publish "QLBanHangAPI.csproj" -c Release -o /app/publish

# Bước 2: Chạy API với cấu hình hạ chuẩn bảo mật hệ điều hành Linux
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# 🚨 ĐẶC TRỊ: Ghi đè file cấu hình OpenSSL của Linux để chấp nhận kết nối cũ
RUN echo "[openssl_init]\nproviders = provider_sect\nssl_conf = ssl_sect\n\n[provider_sect]\ndefault = default_sect\n\n[default_sect]\nactivate = 1\n\n[ssl_sect]\nsystem_default = system_default_sect\n\n[system_default_sect]\nMinProtocol = TLSv1\nCipherString = DEFAULT@SECLEVEL=0" > /etc/ssl/openssl.cnf

# Thiết lập cổng chạy cho Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "QLBanHangAPI.dll"]
