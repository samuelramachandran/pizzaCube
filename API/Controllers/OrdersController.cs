using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizzaCubeApi.Models;

namespace pizzaCubeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly pizzaCubeContext dbContext;

        public OrdersController(pizzaCubeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("Pizza")]
        public async Task<IActionResult> Pizza()
        {
            return Ok(dbContext.Pizzas.ToList());
        }

        [HttpGet]
        [Route("Customize/{id:int}")]
        public async Task<IActionResult> PizzaSelected(int id)
        {
            var pizza =  dbContext.Pizzas.Where(x => x.PizzaId == id).ToList();
             return Ok(pizza);
        }


        [HttpGet]
        [Route("Crust")]
        public async Task<IActionResult> Crust()
        {
            return Ok(dbContext.PizzaCrusts.ToList());
        }

        [HttpGet]
        [Route("Toppings")]
        public async Task<IActionResult> Toppings()
        {
            return Ok(dbContext.PizzaToppings.ToList());
        }

        /*[HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(Order request)
        {
            dbContext.Orders.Add(request);
            dbContext.SaveChanges();
            return Ok(request);
        }*/


    }
}
