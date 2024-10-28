# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo .sln e os arquivos de projeto para o diretório de build
COPY GerenciamentoAPI.sln ./
COPY Api/Api.csproj ./Api/
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Infra.Data/Infra.Data.csproj ./Infra.Data/
COPY Infra.Repositories/Infra.Repositories.csproj ./Infra.Repositories/

# Restaurar dependências
RUN dotnet restore

# Copiar todo o código do projeto
COPY . .

# Compilar a aplicação
RUN dotnet build --configuration Release --no-restore

# Publicar a aplicação (gera o código compilado para ser executado)
RUN dotnet publish --configuration Release --output /app/publish

# Stage 2: Criar a imagem para execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados do stage de build para o contêiner de runtime
COPY --from=build /app/publish .

# Definir o comando de entrada da aplicação (o que será executado ao iniciar o contêiner)
ENTRYPOINT ["dotnet", "Api.dll"]
