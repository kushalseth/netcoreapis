using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApplication.Core;
using FoodApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FoodApplication.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        // set config into a private field
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData,
                         ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        // this tells asp.net, that when you execute the class we are getting ready to execute a 
        // method on this class to process an HTTP request
        // by default it binds only for HTTPPost requests, we can enable using SupportsGet = true
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public void OnGet()//(string searchTerm)
        {
            logger.LogError("execute");
            //Message = "Hello World";
            //SearchTerm = searchTerm;
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}