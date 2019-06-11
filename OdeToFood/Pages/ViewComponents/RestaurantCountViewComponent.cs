using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.ViewComponents
{
	/*This will render a ViewComponent in a folder shared/componentes.
	 Difference between partial view and a view component? View component is independent
	 Partial view depends on some information from parent view*/
	public class RestaurantCountViewComponent :
		ViewComponent
	{
		private readonly IRestaurantData restaurantData;

		public RestaurantCountViewComponent(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}

		public IViewComponentResult Invoke()
		{
			var count = restaurantData.GetCountOfRestaurants();
			return View(count);
		}
	}
}
