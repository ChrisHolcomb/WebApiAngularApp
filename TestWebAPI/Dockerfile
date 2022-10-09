FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestWebAPI.csproj", "TestWebAPI/"]
RUN dotnet restore "TestWebAPI/TestWebAPI.csproj"
WORKDIR "/src/TestWebAPI"
COPY . .
RUN dotnet build "TestWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://+:7000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebAPI.dll"]
