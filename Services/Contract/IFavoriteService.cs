using Delicious_Food_Recipes.Models;
using System.Threading.Tasks;

namespace Delicious_Food_Recipes.Services.Contract.Favorites
{
    public interface IRecipeService
    {
        Task AddFavoriteAsync(Favorite favorite);
        Task<Favorite> GetFavoriteAsync(string userKey, int recipeId);
        Task RemoveFavoriteAsync(string userKey, int recipeId);  // New method for removing a favorite
        Task<IEnumerable<Favorite>> GetAllFavoritesAsync(string userKey);
    }
}
