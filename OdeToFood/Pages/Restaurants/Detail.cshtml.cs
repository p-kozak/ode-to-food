using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
		private readonly IRestaurantData restaurantData;
		public Restaurant Restaurant { get; set; }
		[TempData] //Binding, looks for the key "Message"
		public string Message { get; set; }

		public DetailModel(IRestaurantData restaurantData) //injected interace 
		{
			this.restaurantData = restaurantData;

		}
        public IActionResult OnGet(int restaurantId)
        {
			Restaurant = restaurantData.GetById(restaurantId);
			if(Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
        }
    }
}