# guia-2-crud

Este proyecto es una aplicación CRUD (Create, Read, Update, Delete) que se conecta a una base de datos MySQL.

## Requisitos

- .NET Core SDK
- MySQL

## Configuración

1. Clonar el repositorio.
2. Asegúrese de tener MySQL en ejecución en su máquina local.
3. Actualice la cadena de conexión en `appsettings.json` con sus credenciales de MySQL.

## Comandos

Para construir la aplicación, navegue hasta el directorio del proyecto y ejecute:

```bash
dotnet build
```
## Migraciones de la base de datos

Este proyecto utiliza Entity Framework Core para manejar las migraciones de la base de datos. Para aplicar las migraciones a su base de datos, use el siguiente comando:

```bash
dotnet ef database update

dotnet ef migrations add [NombreDeLaMigracion]
```

Para ejecutar la aplicación, use:

```bash
dotnet run
```

