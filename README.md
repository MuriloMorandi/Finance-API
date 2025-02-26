# 📘 Projeto Finance

Sistema de gestão financeira

## 🏗️ Estrutura do Projeto

- **Finance.Application**: Regras de negócio, serviços e DTOs.
- **Finance.Domain**: Entidades e interfaces.
- **Finance.Infra**: Acesso a dados, configurações do EF Core e migrations.
- **Finance.Web**: API, incluindo controllers e configuração do `Program.cs`.

## 🛠️ Comandos do Projeto

### 🔧 Iniciar o Projeto
```bash
  dotnet run
```

### 📦 Build do Projeto
```bash
  dotnet build
```

### 🏗️ Gerar uma Migration
```bash
  dotnet ef migrations add NomeDaMigration --project Finance.Infra --startup-project Finance.Web 
```

### 📂 Atualizar o Banco de Dados
```bash
  dotnet ef database update --project Finance.Infra  --startup-project Finance.Web
```


## Requisitos

### Entity Framework CLI
```bash 
  dotnet tool install --global dotnet-ef
```

```bash 
  dotnet ef --version
```


