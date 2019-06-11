using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
	public class Restaurant
	{
		public int Id { get; set; }
		//Data validation. During the model binding(from html to property, .NET will check all these requirements
		[Required, StringLength(50)]
		public string Name { get; set; }
		[Required, StringLength(77)]
		public string Location { get; set; }
		public CuisineType Cuisine { get; set; }

	}

}