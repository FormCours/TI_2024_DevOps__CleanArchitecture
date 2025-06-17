# Note pour EFCore

## Utilisation de EFCore pour générer les migrations

### Ajouter du Design dans le projet "WebAPI"
Installation le terminal dans le pojet "WebAPI" ou via le Nugget Package.
```
dotnet add package Microsoft.EntityFrameworkCore.Design -v 8.0.17
```

### Générer les migrations avec les tools EFCore
Depuis le terminal dans le projet "Database"
```
dotnet ef migrations add migration_name --startup-project ../DemoCleanArchitecture.Presentation.WebAPI
```
Depuis le terminal dans le projet "WebAPI"
```
dotnet ef migrations add migration_name --project ../DemoCleanArchitecture.Infrastructure.Database
```