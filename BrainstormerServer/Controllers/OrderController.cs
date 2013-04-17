using Newtonsoft.Json.Linq;
using PizzaServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaServer.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> Orders = new List<Order>();
        private static List<Order> NewOrders = new List<Order>();

        public ActionResult Index()
        {
            return View();
        }


        public enum State { New, InProgress, Completed, Finished, Repayment }

        public ActionResult Hi()
        {
            return Json("Hi1", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetNew(String PizzaIS)
        {
            List<Order> returnOrder = new List<Order>();
            foreach (Order order in NewOrders)
            {
                returnOrder.Add(order);
                order.state = 1;
            }
            NewOrders.Clear();
            return Json(returnOrder.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangeState(int State, int OrderID, float Price)
        {
            foreach (Order order in Orders)
            {
                if (order.orderID == OrderID)
                {
                    order.state = State;
                    order.price = Price;
                }
            }
            return Json("okej", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BuyPizza(int clientID, int orderID, String pizzaName, int state)
        {
            NewOrders.Add(new Order { clientID = clientID, pizzaName = pizzaName, orderID = orderID });
            Orders.Add(new Order { clientID = clientID, pizzaName = pizzaName, orderID = orderID, state = state });
            return Json("okej", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RefreshOrder(int ClientID)
        {
            List<Order> returnOrder = new List<Order>();
            foreach (Order order in Orders)
            {
                if (order.clientID == ClientID)
                {
                    returnOrder.Add(order);
                }
            }
            return Json(returnOrder.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult NewOrder()
        {
            return Json(NewOrders.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Order()
        {
            return Json(Orders.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClearNewOrder()
        {
            NewOrders = new List<Order>();
            return Json(NewOrders.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClearOrder()
        {
            Orders = new List<Order>();
            return Json(Orders.ToArray(), JsonRequestBehavior.AllowGet);
        }

        /*[HttpPost]
        public ActionResult Test(JObject json)
        {
            return Json("okej", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Test2()
        {
            return Json("okej", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Test3(String json)
        {
            return Json("okej " + json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Test4(String name, int age)
        {
            return Json("okej " + name + " " + age, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult refreshorder(String client)
        {
            return Json("ISSERVER " + client, JsonRequestBehavior.AllowGet);
        }*/
    }
}
