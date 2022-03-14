# Entity Framework Core

---
## Reference
1. [Entity Framework Core | Microsoft Docs](https://docs.microsoft.com/zh-cn/ef/core/)
2. [Entity Framework Core 101 | Microsoft Docs](https://docs.microsoft.com/zh-cn/shows/Entity-Framework-Core-101/)
    - [repository](https://github.com/CamSoper/ef-core-101/tree/master/data)
3. [Entity Framework Core - Learn | Microsoft Docs](https://docs.microsoft.com/zh-cn/learn/browse/?expanded=dotnet&products=ef-core)
4. [Entity Framework Core | Github](https://github.com/dotnet/efcore)
---
## Packages
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Design
3. Microsoft.EntityFrameworkCore.Tools
---
## Database
1. Database → + → Data Source → Microsoft SQL Server LocalDB
2. Instance: MSSQLLocalDB
3. Authentication: Windows credentials
4. Database: ContosoPets
---
## [Migrations](https://docs.microsoft.com/zh-cn/ef/ef6/modeling/code-first/migrations/)
1. Add-Migration
2. Update-database
---
## [Reverse Engineering](https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)
- Scaffold-DbContext
```
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPets;Integrated Security=True;ConnectRetryCount=0" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ContosoPetsContext

Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPets;Integrated Security=True;ConnectRetryCount=0" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ContosoPetsContext -DataAnnotations 
```
---