# 1. Imagem de Execução (.NET Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

# 2. Imagem de Construção (.NET SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["locacaoEquipamentos.csproj", "./"]
RUN dotnet restore "locacaoEquipamentos.csproj"

COPY . .
RUN dotnet build "locacaoEquipamentos.csproj" -c Release -o /app/build

# 3. Publicação do Projeto
FROM build AS publish
RUN dotnet publish "locacaoEquipamentos.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Imagem Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "locacaoEquipamentos.dll"]