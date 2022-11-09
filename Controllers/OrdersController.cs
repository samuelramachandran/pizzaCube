using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pizzaCube.Models;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace pizzaCube.Controllers
{
    public class OrdersController : Controller
    {
        private readonly pizzaCubeContext dbContext;
        private  int? custID;

        public OrdersController(pizzaCubeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public static List<Pizza> PizzaInfo = new List<Pizza>();
        public static List<Pizza> Crust = new List<Pizza>();
        public static List<Pizza> Toppings = new List<Pizza>();
        public static List<Pizza> pizzaSelected = new List<Pizza>();


        public async Task<IActionResult> Index()
        {


            using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:7192/api/Orders/Pizza" );
                    if (Res.IsSuccessStatusCode)
                    {
                        var Pizzares = Res.Content.ReadAsStringAsync().Result;
                        PizzaInfo = JsonConvert.DeserializeObject<List<Pizza>>(Pizzares);
                    }
                }

                return View("Pizzalist",PizzaInfo);

        }

        public async Task<IActionResult> Ordernow()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7192/api/Orders/Pizza");
                if (Res.IsSuccessStatusCode)
                {
                    var Pizzares = Res.Content.ReadAsStringAsync().Result;
                    PizzaInfo = JsonConvert.DeserializeObject<List<Pizza>>(Pizzares);
                }
            }

            return View("Ordernow",PizzaInfo);
        }

        [HttpGet]
        public async Task<IActionResult> Placeorder(int id)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resPizza = await client.GetAsync("https://localhost:7192/api/Orders/Customize/"+ id);
                if (resPizza.IsSuccessStatusCode)
                {
                    var pizza = resPizza.Content.ReadAsStringAsync().Result;
                    pizzaSelected = JsonConvert.DeserializeObject<List<Pizza>>(pizza);
                }


                HttpResponseMessage resCrust = await client.GetAsync("https://localhost:7192/api/Orders/Crust");
                if (resCrust.IsSuccessStatusCode)
                {
                    var crust = resCrust.Content.ReadAsStringAsync().Result;
                    Crust = JsonConvert.DeserializeObject<List<Pizza>>(crust);
                    ViewBag.Crust = Crust;
                }
                HttpResponseMessage resToppings = await client.GetAsync("https://localhost:7192/api/Orders/Toppings");
                if (resToppings.IsSuccessStatusCode)
                {
                    var toppings = resToppings.Content.ReadAsStringAsync().Result;
                    Toppings = JsonConvert.DeserializeObject<List<Pizza>>(toppings);
                    ViewBag.toppings = Toppings;
                }
            }
            return View("Customize",pizzaSelected);
        }
/*
        [HttpGet]
        public async Task<IActionResult> PlaceOrder(Order res)
        {
            return View("Customize",res);
        }*/

        [HttpPost]
        public async Task<IActionResult> Placeorder(Order request,Customer customerRequest, Payment paymentRequest)

        {
            TempData["returnurl"] = Request.Headers["Referer"].ToString();

            var data = dbContext.Customers.FirstOrDefault(x => x.Phone == customerRequest.Phone);
            if(data != null)
            {
                 custID = data.CustomerId;
                TempData["custID"] = data.CustomerId;
            }
            else if (data == null)
            {
             var customer = new Customer()
                {
                    FirstName = customerRequest.FirstName,
                    Phone = customerRequest.Phone,
                    DeliveryAddress = customerRequest.DeliveryAddress

                };
                await dbContext.Customers.AddAsync(customer);
                await dbContext.SaveChangesAsync();

                custID = customer.CustomerId;
                TempData["custID"] = customer.CustomerId;
            }
            int transactioID = new Random().Next(1000, 9999);
            var pay = new Payment()
            {

                TransactionId = transactioID.ToString(),
                CardNumber = paymentRequest.CardNumber,
                ExpDate = paymentRequest.ExpDate,
                ExpMonth = paymentRequest.ExpMonth,
                Cvv = paymentRequest.Cvv,
                Status = "Compeleted"
            };
            await dbContext.Payments.AddAsync(pay);
            await dbContext.SaveChangesAsync();
            int ordNumber = new Random().Next(1000, 9999);

            var order = new Order()
            {
                OrderNumber = ordNumber,
                CustomerId = custID,
                PizzaId = request.PizzaId,
                OrderDate = DateTime.Now,
                PaymentId = pay.PaymentId,
                Qty = request.Qty,
                NoOfSlices = request.NoOfSlices,
                CrustId = request.CrustId,
                ToppingsId = request.ToppingsId,
                Status = "Preparing"

            };


            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            TempData["ordNumber"] = ordNumber;
            return Redirect(TempData["returnurl"].ToString());
          //  return RedirectToAction("Placeorder");
            //return RedirectToAction("Index", "Status");
        }
    }
}
