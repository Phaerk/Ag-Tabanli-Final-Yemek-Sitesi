using Microsoft.AspNetCore.Mvc;
using Delicious_Food_Recipes.Models;
using Delicious_Food_Recipes.Services.Contract.Favorites;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Delicious_Food_Recipes.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public FavoritesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> AddFavorite(int mealId, string mealImgUrl, string mealName)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userKey = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                userKey = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                              .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["userKey"] = userKey;

            if (string.IsNullOrEmpty(userKey))
            {
                return Unauthorized("Kullanıcı kimliği bulunamadı.");
            }

            var existingFavorite = await _recipeService.GetFavoriteAsync(userKey, mealId);

            if (existingFavorite != null)
            {
                return Conflict("Bu tarif zaten favorilerde.");
            }

            var favorite = new Favorite
            {
                UserKey = userKey,
                RecipeId = mealId,
                RecipeImgUrl = mealImgUrl,
                RecipeName = mealName,
                CreatedAt = DateTime.UtcNow
            };

            await _recipeService.AddFavoriteAsync(favorite);

            return RedirectToAction("Details", "Home", new { id = mealId });
        }





        public async Task<IActionResult> RemoveFavorite(int mealId)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userKey = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                userKey = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                              .Select(c => c.Value).SingleOrDefault();
            }

            if (string.IsNullOrEmpty(userKey))
            {
                return Unauthorized("Kullanıcı kimliği bulunamadı.");
            }

            var existingFavorite = await _recipeService.GetFavoriteAsync(userKey, mealId);

            if (existingFavorite == null)
            {
                return NotFound("Bu tarif favorilerde bulunmuyor.");
            }

            await _recipeService.RemoveFavoriteAsync(userKey, mealId);

            return RedirectToAction("Details", "Home", new { id = mealId });
        }

        public async Task<IActionResult> MealDetails(int mealId)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userKey = claimUser.Identity.IsAuthenticated ?
                             claimUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value : "";

            bool isFavorite = false;

            if (!string.IsNullOrEmpty(userKey))
            {
                var existingFavorite = await _recipeService.GetFavoriteAsync(userKey, mealId);
                isFavorite = existingFavorite != null;
            }

            ViewBag.IsFavorite = isFavorite;

            return View(); // MealDetails.cshtml view'ine yönlendirilir
        }

        public async Task<IActionResult> ListFavorites()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userKey = claimUser.Identity.IsAuthenticated ?
                             claimUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value : "";

            if (string.IsNullOrEmpty(userKey))
            {
                return Unauthorized("Kullanıcı kimliği bulunamadı.");
            }

            var favorites = await _recipeService.GetAllFavoritesAsync(userKey);
            return View("FavoritesList", favorites);
        }






    }
}
