﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestWebAPI/TestWebAPI.csproj", "TestWebAPI/"]
RUN dotnet restore "TestWebAPI/TestWebAPI.csproj"
COPY . .
WORKDIR "/src/TestWebAPI"
RUN dotnet build "TestWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebAPI.dll"]