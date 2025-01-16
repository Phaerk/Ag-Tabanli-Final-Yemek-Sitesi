using System;
using System.Collections.Generic;

namespace Delicious_Food_Recipes.Models
{
    public partial class Favorite
    {
        public int Id { get; set; } // Primary Key

        public string UserKey { get; set; } // Kullanıcıyı eşleştirmek için

        public int RecipeId { get; set; } // Favori tarifin ID'si (API'den gelen)

        public string RecipeImgUrl { get; set; } // Tarifin resim URL'si

        public string RecipeName { get; set; } // Tarifin adı

        public DateTime CreatedAt { get; set; } // Eklenme tarihi

        public static bool IsFavorite(List<Favorite> favorites, string userKey, int mealId, string mealImgUrl, string mealName)
        {
            return favorites.Any(f =>
                f.UserKey == userKey &&
                f.RecipeId == mealId &&
                f.RecipeImgUrl == mealImgUrl &&
                f.RecipeName == mealName);
        }
    }
}
