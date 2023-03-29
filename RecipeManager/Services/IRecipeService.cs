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
