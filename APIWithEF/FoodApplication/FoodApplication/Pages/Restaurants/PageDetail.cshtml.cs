using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApplication.Core;
using FoodApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace FoodApplication.Pages.Restaurants
{
    public class PageDetailModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public PageDetailModel(IConfiguration config,
                                IRestaurantData restaurantData)
        {
            this.config = config;
            this. restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; set; }
        public string Message { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        // strict input model, so we are not making a Public property
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            Message = config["Message"];
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}