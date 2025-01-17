﻿using Microsoft.AspNetCore.Mvc;

using Delicious_Food_Recipes.Models;
using Delicious_Food_Recipes.Services;
using Delicious_Food_Recipes.Resources;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Delicious_Food_Recipes.Services.Implementation;
using Delicious_Food_Recipes.Services.Contract;
using Delicious_Food_Recipes.Models;

namespace Delicious_Food_Recipes.Controllers
{
    public class StartController : Controller
    {
        private readonly IUserService _userService;

        public StartController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            model.UKey = Utilities.EncryptKey(model.UKey);  // Key encryption method

            User regUser = await _userService.SaveUser(model);  // Save user

            if (regUser.UId > 0)
            {
                return RedirectToAction("Singin", "Start");
            }

            ViewData["Message"] = "Couldn't create user";   // Share information with the view

            return View();
        }

        public IActionResult Singin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Singin(string email, string key)
        {
            User getUser = await _userService.GetUser(email, Utilities.EncryptKey(key));    // Get user with email and encrypted key

            if (getUser == null)
            {  // If the user doesn't exist
                ViewData["Message"] = "Credentials aren't correct. ";
                return View();
            }

            // If the user does exist
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, getUser.UName),
                new Claim(ClaimTypes.NameIdentifier, getUser.UId.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // Register structure
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };   // Create properties

            await HttpContext.SignInAsync(  // Register user login
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
