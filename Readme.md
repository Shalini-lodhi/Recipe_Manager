
# Recipe Manager
Created a recipe manager web application that can be used as a starter template for some of our personal projects or enhance our portfolio. Using **Blazor Server** in ASP.NET Core (C#), Entity Framework Core and SQL Server database. 

## Setting up project with database
- Setup the project
- Add Database Project
- Setup appsettings.json
- Install dependencies
- Setup the Database Context
- Setup the Startup class
- Create the Recipe Model
- Create and run the initial migration

1. Add Class Library for Data Access (**DataAccess**)

2. Set up connection string in **appsettings.json**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=RecipeManager;Trusted_Connection=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
3. Setup Files and Folder
- Add **Data** and **Model** to the DataAccess Library folder
    - Data Folder : contains application DB-context
    - ApplicationDbContext.cs
Model Folder : Entity/Database (Recipe models)
4. Install Dependencies
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- System.Net.Http.Json (Help to get JSON data)
5. Setup ```ApplicationDbContext.cs```
```c#
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
         public DbSet<Recipe> Recipes { get; set; }
    }
}
```
6. Setup ```Startup.cs``
- Add HTTP client in ConfigureServices
- Add Database Connection String to ConfigurationService
```c#
public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }
```
7. Create **Recipe Model** - ```Recipe.cs```
```c#
namespace DataAccess.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataUpated { get; set; }
    }
}
```
8. Create Initial Migration
In *Package Manager Console*, set Default Project as **DataAccess**. 
Run ```Add-Migration InitialCreate```; for adding entity model to (RecipeManager)database to create Table (Recipes) , through *Migrations*. 
Run ```Update-Database``` for updating databse if the same table exits.

    This will create the requires table in the database for us; with same fields as table columns.
    
```sql
    CREATE TABLE [dbo].[Recipes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [DateCreated] DATETIME2 (7)  NOT NULL,
    [DateUpated]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
```

