using DataAccess.Data;
using DataAccess.Models;

namespace RecipeManager.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _db;

        public RecipeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Recipe Create(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> List()
        {
            return  _db.Recipes.ToList();
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}