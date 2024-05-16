FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Books.Api/Books.Api.csproj", "Books.Api/"]
COPY ["Books.Service/Books.Service.csproj", "Books.Service/"]
COPY ["Books.Domain/Books.Domain.csproj", "Books.Domain/"]
COPY ["Books.Infrastructure/Books.Infrastructure.csproj", "Books.Infrastructure/"]
RUN dotnet restore "Books.Api/Books.Api.csproj"
COPY . .
WORKDIR "/src/Books.Api"
RUN dotnet build "Books.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Books.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.Api.dll"]
