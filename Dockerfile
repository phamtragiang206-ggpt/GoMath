# Sử dụng SDK .NET để build dự án
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Sao chép file csproj và restore các thư viện
COPY *.csproj ./
RUN dotnet restore

# Sao chép toàn bộ code và build bản phát hành (Release)
COPY . ./
RUN dotnet publish -c Release -o out

# Sử dụng ASP.NET Runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Cấu hình cổng (Port) theo biến môi trường của Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "GoMath.dll"]