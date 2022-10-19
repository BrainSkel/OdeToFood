using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models.ViewModels
{
	public class RestaurantReviewEditViewModel
	{
		public int Id { get; set; }
		public int Rating { get; set; }
		public string Body { get; set; }
		public int RestaurantId { get; set; }
		public int RestaurantReview { get; set; }
	}
}