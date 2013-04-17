using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaServer.Models
{
    public class Order
    {

        public int state {get; set;}
        public int orderID { get; set; }
        public int clientID { get; set; }
        public float price { get; set; }
        public string pizzaName { get; set; }
    }
}