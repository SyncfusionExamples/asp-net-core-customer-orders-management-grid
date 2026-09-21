using System;
using System.Collections.Generic;
using CustomerOrdersManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerOrdersManagement.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Static, real-time sample data bound directly to the Grid via
        /// `dataSource="@Model.Orders"`. No controller, no repository,
        /// no DataManager/UrlAdaptor involved.
        /// </summary>
        public List<Order> Orders { get; } = BuildSampleOrders();

        public void OnGet() { }

        private static List<Order> BuildSampleOrders()
        {
            string[] customers =
            {
                "Aiden Brooks",   "Bella Carter",  "Carlos Diaz",    "Daniela Evans",
                "Ethan Foster",   "Fiona Garcia",  "Gabriel Hayes",  "Hannah Ito",
                "Isaac Jennings", "Julia Kim",     "Kai Lopez",      "Lily Martinez",
                "Mason Nguyen",   "Nora O'Brien",  "Owen Patel",     "Penelope Quinn",
                "Quincy Roberts", "Riley Sanchez", "Sophia Tan",     "Thomas Underwood"
            };

            string[] products =
            {
                "Wireless Mouse",  "Mechanical Keyboard", "27\" Monitor",      "USB-C Hub",
                "Noise-Cancelling Headphones", "4K Webcam", "Ergonomic Chair",  "Standing Desk",
                "Laptop Stand",    "External SSD 1TB",    "Smart LED Lamp",   "Bluetooth Speaker"
            };

            string[] statuses = { "Pending", "Processing", "Shipped", "Delivered", "Cancelled" };

            var rnd = new Random(2026_09_21);
            var list = new List<Order>(customers.Length);

            int id = 1001;
            foreach (var customer in customers)
            {
                list.Add(new Order
                {
                    OrderID      = id++,
                    CustomerName = customer,
                    Product      = products[rnd.Next(products.Length)],
                    Quantity     = rnd.Next(1, 12),
                    Price        = Math.Round((decimal)(rnd.NextDouble() * 480 + 20), 2),
                    OrderDate    = DateTime.Today.AddDays(-rnd.Next(0, 180)),
                    Status       = statuses[rnd.Next(statuses.Length)]
                });
            }

            return list;
        }
    }
}
