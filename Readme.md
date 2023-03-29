
# Recipe Manager
Created a recipe manager web application that can be used as a starter template for some of our personal projects, or enhance our portfolio to increase your chances of getting into a better job!

## Setting Up the Service and UI
- Insert recipes into SqlServer Database
- Add a Recipe page folder
- Access Database Recipes
– Setup NavigationManager

1. Insert recipes into SqlServer Database

- Adding data to the database using *Migration*. Write migration code in **Package Manager Console**:
```Add-Migration RecipesInsert```

In ```RecipeInsert.cs``` update
```c#
protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT Recipes ON;
INSERT INTO Recipes
	(   Id, Title,		[Description],																																																DateCreated,				DateUpdated)
(SELECT	1, 'Burger',	'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',																				'2021-09-04 12:03:00.000', '2021-09-05 18:30:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 1)) UNION ALL
(SELECT	2, 'Pizza',		'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.',												'2021-09-02 14:58:00.000', '2021-09-03 08:12:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 2)) UNION ALL
(SELECT	3, 'Lasagne',	'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.',		'2021-08-31 11:39:00.000', '2021-09-01 09:40:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 3));
SET IDENTITY_INSERT Recipes OFF;
");

        }
```

2. Add a Recipe Page Folder
Create Recipe folder under Pages and shift **RecipeList.razor** to it

3. Access Database Recipes
In **RescipeService.cs**

```c#
private readonly ApplicationDbContext _db;

        public RecipeService(ApplicationDbContext db)
        {
            _db = db;
        }
```

4. Setup Navigation Manager
**RecipeList.razor**
```c#
@code {
    List<Recipe> Recipes = new List<Recipe>();

    protected override async Task OnInitializedAsync()
    {
        Recipes = RecipeService.List();
    }

    private void RedirectTo(int recipeId)
    {
        NavigationManager.NavigateTo("/");
    }
}
```
