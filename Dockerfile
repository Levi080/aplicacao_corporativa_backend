# Estágio 1: Build (.NET SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia os arquivos da pasta atual para dentro do container
COPY . ./

# Restaura dependências e publica
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Estágio 2: Runtime (Ambiente de Execução)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Define a porta dinâmica exigida pelo Render
ENV ASPNETCORE_URLS=http://*:$PORT

# Executa a API
ENTRYPOINT ["dotnet", "Aplicacao_Corporativa.API.dll"]