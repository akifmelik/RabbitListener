FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /var/docker/apps/rabbitListener

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RabbitListener/RabbitListener.csproj", "RabbitListener/"]
RUN dotnet restore "RabbitListener/RabbitListener.csproj"
COPY . .
WORKDIR "/src/RabbitListener"
RUN dotnet build "RabbitListener.csproj" -c Release -o /var/docker/apps/rabbitListener/build

FROM build AS publish
RUN dotnet publish "RabbitListener.csproj" -c Release -o /var/docker/apps/rabbitListener/publish

FROM base AS final
WORKDIR /var/docker/apps/rabbitListener
COPY --from=publish /var/docker/apps/rabbitListener/publish .
ENTRYPOINT ["dotnet", "RabbitListener.dll"]
