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
ENTRYPOINT ["dotnet", "VersioningDemoCore.dll"]