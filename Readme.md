
# Recipe Manager
Created a recipe manager web application that can be used as a starter template for some of our personal projects, or enhance our portfolio to increase your chances of getting into a better job!

## Setting Up the Service and UI
- Project cleanup
- Add a new Razor Component
- Add thr Recipes Services and Interface
- Mock a recipe list from service
- Access the mock list on initiatized
- Show the recipes with in the table

1. Project Clean up
- Remove Unwanted files like: Counter.razor, _layout.cshtml, weather_forcast.razor etc.
- Remove HTTP client dependency from Startup.cs and it's package

2. Add new Razor Component **Pages/RecipesList.razor**
```html
@page "/recipes"

<h3>RecipeList</h3>

@code {

}
```
- Adding new nav bar component to **Shared/NavMenu.razor**
```html
<div class="nav-item px-3">
            <NavLink class="nav-link" href="recipes">
                <span class="oi oi-home" aria-hidden="true"></span> Recipes
            </NavLink>
</div>
```
3. Adding a basic bootstrap table
```html
@page "/recipes"

@using DataAccess.Models;

<h3>Recipes</h3>

<table class="table table-striped">
    <thead>
        <tr>
            <th scope="col">#</th>
            <th scope="col">Title</th>
            <th scope="col">Description</th>
            <th scope="col">Date Created</th>
            <th scope="col">Date Updated</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

@code {
}
```

4. Adding Recipes Services and Interface
- Performing CRUD operation through interface ```Services/IRecipeService.cs``` and Implementing interface in ```Services/RecipeService.cs```
```c#
using DataAccess.Models;

namespace RecipeManager.Services
{
    public interface IRecipeService
    {
        //Create
        Recipe Create(Recipe recipe);
        //Get
        Recipe Get(int id);
        //List
        List<Recipe> List();
        //Update
        Recipe Update(Recipe recipe);
        //Delete
        void Delete(int id);
    }
}
```
- Add scope of service in Startup class
```c#
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IRecipeService, RecipeService>();
        }
```
- Accessing it in ```RecipeList.razor```
```css
@using DataAccess.Models;
@using Services;

@inject IRecipeService RecipeService
```

5. Mock a recipe list from service in ```Services/RecipeService.cs```
```c#
public List<Recipe> List()
        {
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Id = 1,
                    Title = "Burger",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    DateCreated = DateTime.Now.AddDays(-2),
                    DateUpdated = DateTime.Now.AddDays(-1)
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Pizza",
                    Description = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                    DateCreated = DateTime.Now.AddDays(-4),
                    DateUpdated = DateTime.Now.AddDays(-3)
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Lasagne",
                    Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                    DateCreated = DateTime.Now.AddDays(-6),
                    DateUpdated = DateTime.Now.AddDays(-5)
                },
            };

            return recipes;
        }
```
6. Access the mock list on initiatized ```RecipeList.razor```
```css
@code {
    List<Recipe> Recipes = new List<Recipe>();

    protected override async Task OnInitializedAsync()
    {
        Recipes = RecipeService.List();
    }
}
```
7. Show the recipes with in the table  ```RecipeList.razor```
```html
<tbody>
        @if (!Recipes.Any())
        {
            <tr>
                <th scope="row" colspan="5">No recipes available</th>
            </tr>
        }
        else
        {
            @foreach (var recipe in Recipes)
            {
                <tr>
                    <th scope="row">@recipe.Id</th>
                    <td>@recipe.Title</td>
                    <td>@recipe.Description.Substring(0, 50) ...</td>
                    <td>@recipe.DateCreated</td>
                    <td>@recipe.DateUpdated</td>
                </tr>
            }
        }
</tbody>
```

## End Result
<img width="957" alt="image" src="https://user-images.githubusercontent.com/55933789/228513650-0552a706-fa04-4773-bcaf-28e084fb3423.png">
