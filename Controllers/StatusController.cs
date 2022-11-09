using Microsoft.AspNetCore.Mvc;
using pizzaCube.Models;
using pizzaCube.Models.viewModel;
using static NuGet.Packaging.PackagingConstants;
using System.Linq;

namespace pizzaCube.Controllers
{
    public class StatusController : Controller
    {
        private readonly pizzaCubeContext dbContext;

        public StatusController(pizzaCubeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            int cusID = Convert.ToInt32(TempData["custID"]);
            var data = (from ord in dbContext.Orders where ord.CustomerId == cusID
                        join p in dbContext.Pizzas on ord.PizzaId equals p.PizzaId
                        select new OrderViewModel()
                        {
                            pizzaName = p.PizzaName,
                            pizzaType = p.PizzaType,
                            OrderNumber = ord.OrderNumber,
                            OrderDate = ord.OrderDate,
                            Qty = ord.Qty,
                            Status = ord.Status
                        }).ToList();
            // var order = dbContext.Orders.ToList();

            return View(data);

            //return View();
        }
    }
}
