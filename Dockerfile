# Bước 1: Dùng bản SDK của Microsoft để biên dịch code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy file project và khôi phục thư viện
COPY ["QLBanHangAPI.csproj", "./"]
RUN dotnet restore "./QLBanHangAPI.csproj"

# Copy toàn bộ code và publish
COPY . .
RUN dotnet publish "QLBanHangAPI.csproj" -c Release -o /app/publish

# Bước 2: Dùng bản Runtime siêu nhẹ để chạy API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# 🚨 ĐOẠN SỬA LỖI: Hạ chuẩn mã hóa OpenSSL để sửa lỗi Pre-login Handshake
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1.0/g' /etc/ssl/openssl.cnf
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

# Mở cổng mặc định của Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "QLBanHangAPI.dll"]
