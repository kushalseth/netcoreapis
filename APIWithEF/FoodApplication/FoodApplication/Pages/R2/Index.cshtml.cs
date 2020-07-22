using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodApplication.Core;
using FoodApplication.Data;

namespace FoodApplication.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly FoodApplication.Data.FoodApplicationDbContext _context;

        public IndexModel(FoodApplication.Data.FoodApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
