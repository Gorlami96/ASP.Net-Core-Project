using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable <Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants =  new List<Restaurant>()
            {
                new Restaurant{Id=1 , Name = "Scott's Pizza" , Location = "ABCD", Cuisine = CuisineType.Italian},
                new Restaurant{Id=2 , Name = "Cinnamon Club" , Location = "LMNO" , Cuisine = CuisineType.Mexican},
                new Restaurant{Id=1 , Name = "Dhaba" , Location = "EFGH", Cuisine = CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                where string.IsNullOrEmpty(r.Name) || //TODO
                orderby r.Name
                select r;
        }
    }
}