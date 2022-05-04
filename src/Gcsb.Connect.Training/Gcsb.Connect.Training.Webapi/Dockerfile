#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Gcsb.Connect.Training.Webapi/Gcsb.Connect.Training.Webapi.csproj", "Gcsb.Connect.Training.Webapi/"]
COPY ["Gcsb.Connect.Training.Domain/Gcsb.Connect.Training.Domain.csproj", "Gcsb.Connect.Training.Domain/"]
COPY ["Gcsb.Connect.Training.Infrastructure/Gcsb.Connect.Training.Infrastructure.csproj", "Gcsb.Connect.Training.Infrastructure/"]
COPY ["Gcsb.Connect.Training.Application/Gcsb.Connect.Training.Application.csproj", "Gcsb.Connect.Training.Application/"]
RUN dotnet restore "Gcsb.Connect.Training.Webapi/Gcsb.Connect.Training.Webapi.csproj"
COPY . .
WORKDIR "/src/Gcsb.Connect.Training.Webapi"
RUN dotnet build "Gcsb.Connect.Training.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gcsb.Connect.Training.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gcsb.Connect.Training.Webapi.dll"]