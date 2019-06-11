using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
		private readonly IRestaurantData restaurantData;
		private readonly IHtmlHelper htmlHelper;
		[BindProperty] //Restaurant should be populated with the information from post form
		public Restaurant Restaurant { get; set; }
		public IEnumerable<SelectListItem> Cuisines { get; set; }
		

		public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}
        public IActionResult OnGet(int? restaurantId)
        {
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
			if (restaurantId.HasValue)
			{
				Restaurant = restaurantData.GetById(restaurantId.Value);
			}
			else
			{
				//This is adding a new resttaurant
				Restaurant = new Restaurant();
			}
			if(Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
        }

		public IActionResult OnPost()
		{
			/*PRG - post, redirect, get. You don't want to stay on a page with post request after submiting the form
			 as post resubmission is conceptually bad idea*/
			if (!ModelState.IsValid)
			{
				Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
				return Page();
			}
			if (Restaurant.Id > 0)
			{
				restaurantData.Update(Restaurant);
				
			}
			else
			{
				restaurantData.Add(Restaurant);
			}
			restaurantData.Commit();
			TempData["Message"] = "Restaurant saved!"; //this disapperars after the first request
			return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id, TempData});

		}
    }
}