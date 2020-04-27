FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["A2v10.Core.Site/A2v10.Core.Site.csproj", "A2v10.Core.Site/"]
RUN dotnet restore "A2v10.Core.Site/A2v10.Core.Site.csproj"
COPY . .
WORKDIR "/src/A2v10.Core.Site"
RUN dotnet build "A2v10.Core.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A2v10.Core.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A2v10.Core.Site.dll"]