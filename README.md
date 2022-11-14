# SessionServiceAPI
This git repo is for made for the Session Management for [CardGames](https://github.com/Fontys-Brett-Mulder/CardGames)

# Dependencies
- [GamesService](https://github.com/Fontys-Brett-Mulder/GamesServiceAPI)
- [CardGames Frontend](https://github.com/Fontys-Brett-Mulder/CardGamesFrontend)
- [Documentation](https://github.com/Fontys-Brett-Mulder/CardGames)

# Setup for new ASP Net Core API

1. Create new `ASP Net Core Web API` add solution in same folder
2. Add folders
* Controllers
* Migrations
* Models
* DataContext
3. Add connectionstring to appsettings.json

```C#
"ConnectionStrings": {
    "DefaultConnection": "Server=MSI;Database=CardGames;Trusted_Connection=True;"
}
```
4. Create models / controllers
5. Download Nuget Packages
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.design
* Microsoft.EntityFrameworkCore.SqlServer

6. In the DataContext folder create a class named `DatabaseContext.cs`
7. Add this code to `DatabaseContext.cs`
```C#
using YourService.Models;
using Microsoft.EntityFrameworkCore;
namespace YourService.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        // Add new models here
        public DbSet<YourModel> Games { get; set; }
    }
}
```

8. In `program.cs` add these lines on top
```C#
using YourService.DataContext;
using Microsoft.EntityFrameworkCore;
```
and before the line `var app = builder.Build();` add
```C#
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

9. If you added models and setup your connection string run this command
```console
dotnet ef migrations add "nameOfYourMigration"
```
(Make sure you have your model added to the `DatabaseContext.cs` file)
This creates a file in your migrations folder

10. After that run this command to update your database
```console
dotnet ef database update
```
