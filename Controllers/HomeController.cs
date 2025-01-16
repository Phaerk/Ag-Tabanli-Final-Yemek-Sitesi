using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Delicious_Food_Recipes.Models;
using Delicious_Food_Recipes.Services.Contract.Favorites;

namespace Delicious_Food_Recipes.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IRecipeService _recipeService;

        public HomeController(IHttpClientFactory httpClientFactory, IRecipeService recipeService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index(string searchTerm, string firstLetter = null)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userName = "";
            string userKey = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                userName = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                              .Select(c => c.Value).SingleOrDefault();

                userKey = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                              .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["userName"] = userName;
            ViewData["userKey"] = userKey;  // UId değeri ekleniyor


            try
            {
                string url;

                if (!string.IsNullOrEmpty(firstLetter))
                {
                    // İlk harfe göre yemek listesi
                    url = $"https://www.themealdb.com/api/json/v1/1/search.php?f={firstLetter}";
                }
                else
                {
                    // Genel arama veya tüm yemekler
                    url = string.IsNullOrEmpty(searchTerm)
                        ? "https://www.themealdb.com/api/json/v1/1/search.php?s="
                        : $"https://www.themealdb.com/api/json/v1/1/search.php?s={searchTerm}";
                }

                var response = await _httpClient.GetStringAsync(url);
                var meals = JsonConvert.DeserializeObject<MealResponse>(response).Meals;

                return View(meals);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = "API bağlantısı kurulamadı: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> FilterByCountry(string country)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userName = "";
            string userKey = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                userName = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                              .Select(c => c.Value).SingleOrDefault();

                userKey = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                              .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["userName"] = userName;
            ViewData["userKey"] = userKey;  // UId değeri ekleniyor

            try
            {
                // Ülkeye göre yemekleri filtrele
                var url = $"https://www.themealdb.com/api/json/v1/1/filter.php?a={country}";
                var response = await _httpClient.GetStringAsync(url);
                var meals = JsonConvert.DeserializeObject<MealResponse>(response).Meals;

                return View("Index", meals);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = "API bağlantısı kurulamadı: " + ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userName = "";
            string userKey = "";
            bool isFavorite = false;


            if (claimUser.Identity.IsAuthenticated)
            {
                userName = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                              .Select(c => c.Value).SingleOrDefault();

                userKey = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                              .Select(c => c.Value).SingleOrDefault();

                if (!string.IsNullOrEmpty(userKey) && int.TryParse(id, out int mealId))
                {
                    var existingFavorite = await _recipeService.GetFavoriteAsync(userKey, mealId);
                    isFavorite = existingFavorite != null;
                }
            }

            ViewData["userName"] = userName;
            ViewData["userKey"] = userKey;  // UId değeri ekleniyor
            ViewBag.IsFavorite = isFavorite;


            try
            {
                var response = await _httpClient.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}");
                var mealResponse = JsonConvert.DeserializeObject<MealResponse>(response);

                if (mealResponse?.Meals == null || !mealResponse.Meals.Any())
                {
                    return View("Error");
                }

                var meal = mealResponse.Meals.FirstOrDefault();

                var ingredients = new List<string>();
                for (int i = 1; i <= 20; i++)
                {
                    var ingredient = meal.GetType().GetProperty($"StrIngredient{i}")?.GetValue(meal)?.ToString();
                    var measure = meal.GetType().GetProperty($"StrMeasure{i}")?.GetValue(meal)?.ToString();

                    if (!string.IsNullOrEmpty(ingredient) && !string.IsNullOrEmpty(measure))
                    {
                        ingredients.Add($"{measure} {ingredient}");
                    }
                    else if (!string.IsNullOrEmpty(ingredient))
                    {
                        ingredients.Add(ingredient);
                    }
                }

                meal.Ingredients = ingredients;

                return View(meal);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = "API bağlantısı kurulamadı: " + ex.Message;
                return View("Error");
            }
        }
    }

    public class MealResponse
    {
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        public string IdMeal { get; set; }
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
        public string StrInstructions { get; set; }
        public string StrCategory { get; set; }
        public string StrArea { get; set; }
        public string StrYoutube { get; set; }
        public string StrSource { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
