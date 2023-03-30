
# Recipe Manager
Created a recipe manager web application that can be used as a starter template for some of our personal projects, or enhance our portfolio to increase your chances of getting into a better job!

## Retrieve Data using EntityFramework Core
- Create a new Recipe Details Razor Component
- Get a recipe by its ID(Recipe Service)
- Show the Recipe Details on page load
- Redirect to a recipe when seleted

### 1. Create a new Recipe Details Razor Component

```Pages/Recipe/RecipeDetails.razor```
```c#
@page "/recipe/{Id:int}"

@using DataAccess.Models
@using Services

@inject IRecipeService RecipeService

<h3>@Recipe.Title</h3>
<b>Description:</b><p>@Recipe.Description</p>
<b>Date created:</b><p>@Recipe.DateCreated</p>
<b>Date updated:</b><p>@Recipe.DateUpdated</p>

@code {
    [Parameter]
    public int? Id { get; set; }
    public Recipe Recipe = new Recipe();

    protected override async Task OnInitializedAsync()
    {
        if (Id != null)
        {
            Recipe = RecipeService.Get(Id.Value);
        }
    }
}
```
### 2. Geta Recipe By its Id(Recipe Service)
```RecipeService.cs```
```c#
 public Recipe Get(int id)
        {
            return _db.Recipes.Find(id);
        }
```
### 3. Show the Recipr Details on Page Load
```RecipeDetails.razor```
```c#
@page "/recipe/{Id:int}"

@using DataAccess.Models
@using Services

@inject IRecipeService RecipeService

<h3>@Recipe.Title</h3>
<b>Description:</b><p>@Recipe.Description</p>
<b>Date created:</b><p>@Recipe.DateCreated</p>
<b>Date updated:</b><p>@Recipe.DateUpdated</p>

@code {
    [Parameter]
    public int? Id { get; set; }
    public Recipe Recipe = new Recipe();

    protected override async Task OnInitializedAsync()
    {
        if (Id != null)
        {
            Recipe = RecipeService.Get(Id.Value);
        }
    }
}
```
### 4. Redirect to a recipe when selected
```RecipeList.razor```
```c#
@inject IRecipeService RecipeService
@inject NavigationManager NavigationManager
@code {
    List<Recipe> Recipes = new List<Recipe>();

    protected override async Task OnInitializedAsync()
    {
        Recipes = RecipeService.List();
    }

    private void RedirectTo(int recipeId)
    {
        NavigationManager.NavigateTo($"/recipe/{recipeId}");
    }
}
```