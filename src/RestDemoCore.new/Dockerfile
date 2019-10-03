FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RestDemoCore/RestDemoCore.csproj", "RestDemoCore/"]
RUN dotnet restore "RestDemoCore/RestDemoCore.csproj"
COPY . .
WORKDIR "/src/RestDemoCore"
RUN dotnet build "RestDemoCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestDemoCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestDemoCore.dll"]