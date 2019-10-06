FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["VersioningDemoCore/VersioningDemoCore.csproj", "VersioningDemoCore/"]
RUN dotnet restore "VersioningDemoCore/VersioningDemoCore.csproj"
COPY . .
WORKDIR "/src/VersioningDemoCore"
RUN dotnet build "VersioningDemoCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VersioningDemoCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Set password for the certificate as 1234
# I'm using Environment Variable here to simplify the .NET Core sample.
ENV certPassword 1234

# Use opnssl to generate a self signed certificate cert.pfx with password $env:certPassword
RUN openssl genrsa -des3 -passout pass:${certPassword} -out server.key 2048
RUN openssl rsa -passin pass:${certPassword} -in server.key -out server.key
RUN openssl req -sha256 -new -key server.key -out server.csr -subj '/CN=localhost'
RUN openssl x509 -req -sha256 -days 365 -in server.csr -signkey server.key -out server.crt
RUN openssl pkcs12 -export -out cert.pfx -inkey server.key -in server.crt -certfile server.crt -passout pass:${certPassword}

ENTRYPOINT ["dotnet", "VersioningDemoCore.dll"]