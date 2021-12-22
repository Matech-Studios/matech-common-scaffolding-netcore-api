FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

LABEL maintainer="info@matechstudios.com"

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Matech.Common.Scaffolding.Api/Matech.Common.Scaffolding.Api.csproj", "Matech.Common.Scaffolding.Api/"]

# Copy all your projects before running a restore command
# COPY ["Matech.Common.Scaffolding.Core/Matech.Common.Scaffolding.Core.csproj", "Matech.Common.Scaffolding.Core/"]
# COPY ["Matech.Common.Scaffolding.Repository ...
# COPY ["Matech.Common.Scaffolding.Service ...

RUN dotnet restore "Matech.Common.Scaffolding.Api/Matech.Common.Scaffolding.Api.csproj"

COPY . .
WORKDIR "/src/Matech.Common.Scaffolding.Api"
RUN dotnet build "Matech.Common.Scaffolding.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Matech.Common.Scaffolding.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matech.Common.Scaffolding.Api.dll"]