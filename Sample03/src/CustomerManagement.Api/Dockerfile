FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
WORKDIR /src
RUN dotnet build "CustomerManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "CustomerManagement.Api.dll"]