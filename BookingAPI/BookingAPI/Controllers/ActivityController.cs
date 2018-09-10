using BookingAPI.Entities;
using BookingAPI.RepositoryLayer;
using BookingAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingAPI.Controllers
{
    public class ActivityController : ApiController
    {
        [Route("Products/Activity")]
        [HttpPost]
        public void AddProduct(Activity activityProduct)
        {
            ActivityProductRepository repository = new ActivityProductRepository();
            repository.AddProduct(activityProduct);
        }

        [Route("Products/Activity")]
        [HttpGet]
        public List<Activity> Get()
        {
            ActivityProductRepository repository = new ActivityProductRepository();
            IProductTotalFareStrategy productFare = new ActivityProductFare();
            List<Activity> activities = repository.GetAllProducts();
            foreach(Activity activity in activities)
            {
                activity.Price = productFare.GetTotalFare(activity.Price);
            }
            return activities;
        }

        [Route("Products/Activity/Book/{id}")]
        [HttpPut]
        public bool BookProdcut([FromUri]int id)
        {
            ActivityProductRepository repository = new ActivityProductRepository();
            return repository.BookProduct(id);
        }

        [Route("Products/Activity/Save/{id}")]
        [HttpPut]
        public void SaveProduct([FromUri]int id)
        {
            ActivityProductRepository repository = new ActivityProductRepository();
            repository.SaveProduct(id);
        }
    }
}