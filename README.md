# BoletoApi

## Requisitos
> .NET 6 SDK
> 
> PostgreSQL

## Configuração do Banco de Dados

Antes de rodar a api, edite o arquivo appsettings.Development.json para configurar a conexão com o banco de dados PostgreSQL:
```
{
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=SEU_HOST;Port=SUA_PORTA;Database=SEU_BANCO_DADOS;User Id=SEU_USER;Password=SUA_SENHA;"
  },
}
```

## Configuração .env

A api usa um .env para armazenar variáveis para utilização de Bearer token. Exemplo em uso:
```
JWT_KEY=obOWKxoXQk3rfAD0usR8T6LUUDyHLWF32507OmZljDc
JWT_ISSUER=BoletoApi
JWT_AUDIENCE=BoletoApiClientes
JWT_EXPIRE_MINUTES=60
CLIENT_ID=client1
CLIENT_SECRET=secret1
```

## Executando

Instale as dependências, adicione as migrações ao banco de dados e rode a api.

```
dotnet restore

dotnet ef database update

dotnet run
```

