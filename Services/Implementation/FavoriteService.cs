using Delicious_Food_Recipes.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Delicious_Food_Recipes.Services.Contract.Favorites;

namespace Delicious_Food_Recipes.Services.Implementation.Favorites
{
    public class RecipeService : IRecipeService
    {
        private readonly DbWebapplication01Context _context;

        public RecipeService(DbWebapplication01Context context)
        {
            _context = context;
        }

        public async Task AddFavoriteAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<Favorite> GetFavoriteAsync(string userKey, int recipeId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserKey == userKey && f.RecipeId == recipeId);
        }

        public async Task RemoveFavoriteAsync(string userKey, int recipeId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserKey == userKey && f.RecipeId == recipeId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync(string userKey)
        {
            return await _context.Favorites
                .Where(f => f.UserKey == userKey)
                .ToListAsync();
        }
    }
}