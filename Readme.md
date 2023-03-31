

# Recipe Manager
Created a recipe manager web application that can be used as a starter template for some of our personal projects, or enhance our portfolio to increase your chances of getting into a better job!

## Retrieve Data using EntityFramework Core
- Edit form 
- Add EditForm
-  Add EditForm Submission handler
-  Setup Blazored Toast
-  Setup Validation

### 1. Edit form 
[RecipeDetails.razor]
```c#
<EditForm Model="@Recipe" OnValidSubmit="@HandleOnValidSubmit" class="col-7 p-0">
    <label>Created on: @Recipe.DateCreated</label> <br />
    <label>Updated on: @Recipe.DateUpdated</label>
</EditForm>
```
### 2. Add Edit form 
```c#
<div class="form-group">
        <label for="title">Title</label>
        <InputText id="title" @bind-Value="@Recipe.Title" class="form-control" placeholder="Green curry..." />
        <ValidationMessage For="@(() => Recipe.Title)"/>
    </div>

    <div class="form-group">
        <label for="description">Description</label>
        <InputTextArea id="description" @bind-Value="@Recipe.Description" class="form-control" placeholder="Cook the potatoes in boiling water for about 10 mins..." row="5" />
    </div>
```
### 3. Add Edit form Submission handler

[RecipeDetails.razor]
```c#
<div class="form-group">
        <button type="submit" class="btn btn-primary">Save</button>
</div>
```
### 4. Setup Blazored Toast
-  package ```Blazored.Toast```
[_Layout.cshtml]
```html
<link href="_content/Blazored.Toast/blazored-toast.min.css" rel="stylesheet" />
```
[MainLayout.razor]
Adding Blazored Toasts in main layout's page.
```c#
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>
    <BlazoredToasts />

    <main>
        <div class="top-row px-4">
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>
```
[_import.razor]
```c#
@using Blazored.Toast
@using Blazored.Toast.Services
```
[Startup.cs]
```c#
public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddBlazoredToast();
        }
```
[RecipeService.cs]
```c#
public Recipe Update(Recipe recipe)
        {
            var dbRecipe = _db.Recipes.Find(recipe.Id);

            if (dbRecipe != null)
            {
                dbRecipe = recipe;
                dbRecipe.DateUpdated = DateTime.Now;

                _db.SaveChanges();
            }
            return dbRecipe;
        }
```

### 5. Setup Validation
[Recipe.cs]
```c#
[Required]
        [StringLength(50, ErrorMessage = "The title is too long, try a shorter one (50 characters limit)")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The description is too long, try a shorter one (1000 characters limit)")]
```
[RecipeDetails.razor]
```html
<EditForm Model="@Recipe" OnValidSubmit="@HandleOnValidSubmit" class="col-7 p-0">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <div class="form-group">
        <label for="title">Title</label>
        <InputText id="title" @bind-Value="@Recipe.Title" class="form-control" placeholder="Green curry..." />
        <ValidationMessage For="@(() => Recipe.Title)"/>
    </div>

    <div class="form-group">
        <label for="description">Description</label>
        <InputTextArea id="description" @bind-Value="@Recipe.Description" class="form-control" placeholder="Cook the potatoes in boiling water for about 10 mins..." row="5" />
    </div>

    <div class="form-group">
        <button type="submit" class="btn btn-primary">Save</button>
    </div>
    <hr />
    <label>Created on: @Recipe.DateCreated</label> <br />
    <label>Updated on: @Recipe.DateUpdated</label>
</EditForm>
```
```c#
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

    private void HandleOnValidSubmit()
    {
        try
        {
            RecipeService.Update(Recipe);
            ToastService.ShowSuccess("Your recipe has been saved successfully");
        }
        catch (Exception)
        {
            ToastService.ShowError("Something went wrong while saving your recipe");
        }
    }
}
```
