using Recorder.BLL.Services;
using Recorder.DAL.Entities.Models;
using Recorder.PL.ViewControllers.Helpers;
using Recorder.PL.ViewControllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Implementations
{
    public class OrderViewController : IOrderViewController
    {
        public readonly OrderService _orderService;


        public OrderViewController(OrderService orderService)
        {
            _orderService = orderService;
        }


        public void DisplayAll()
        {
            var orders = _orderService.GetAll();

            DisplayAll(orders);
        }
        public void DisplayAll(IEnumerable<Order> orders)
        {
            Console.WriteLine("\n----- Orders: -----\n");

            foreach (Order order in orders)
            {
                DisplayOne(order);
                Console.WriteLine("----------------------");
            }
        }

        public void DisplayOne(Order order)
        {
            Console.WriteLine("Order");
            Console.WriteLine($"Id: {order.ID}");
            Console.WriteLine($"Client id: {order.ClientID}");
            Console.WriteLine($"Order added: {order.OrderDate}");
            Console.WriteLine($"Order close: {order.CloseDate}");
            Console.WriteLine($"Price: {order.Price}");
            Console.WriteLine($"Description: {order.Description}");
        }

        public void Add(int clientId)
        {
            DateTime dateTimeNow = DateTime.Now;
            DateTime dateTimeAfterDaysFromNow;
            string description;
            double price;


            Console.WriteLine("\nAdding new order\n");

            price = GetCorrectPrice();

            Console.Write("Enter description: ");
            description = Console.ReadLine();

            dateTimeAfterDaysFromNow = GetCloseDate(dateTimeNow);


            Order newOrder = new Order(clientId, price, description, dateTimeNow, dateTimeAfterDaysFromNow);

            _orderService.Add(newOrder);
        }

        public void EditById()
        {
            Console.WriteLine("\nEditing Order by id\n");

            int orderId = GetOrderId();

            Order order = _orderService.GetById(orderId);
            DisplayOne(order);


            Console.WriteLine();
            Console.WriteLine("Edit property:");
            Console.WriteLine("1. Price");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Close date");
            Console.WriteLine();


            while (true)
            {
                Console.Write("Enter property number: ");
                string propertyNumber = Console.ReadLine();

                if (propertyNumber == "1")
                {
                    Console.WriteLine($"Price: {order.Price}");
                    double newPrice = GetCorrectPrice();

                    order.Price = newPrice;
                    break;
                }
                else if (propertyNumber == "2")
                {
                    Console.WriteLine($"Description: {order.Description}");
                    Console.Write("Enter new Description: ");
                    string newDescripion = Console.ReadLine();
                    order.Description = newDescripion;
                    break;
                }
                else if (propertyNumber == "3")
                {
                    Console.WriteLine($"Close date: {order.CloseDate}");
                    order.CloseDate = GetCloseDate(order.OrderDate);
                    break;
                }
                else
                {
                    Console.WriteLine("### Incorrect property number. ###");
                }
            }
            _orderService.Update(order);
        }

        public void RemoveById()
        {
            Console.WriteLine("\nRemoving Order by id\n");

            int orderId = GetOrderId();

            _orderService.RemoveById(orderId);
        }

        public int GetEntityId()
        {
            return HelperBaseEnitityViewController.GetIdGivenCurrentList(_orderService.GetAll());
        }

        private int GetOrderId()
        {
            return GetEntityId();
        }


        private double GetCorrectPrice()
        {
            while (true)
            {
                Console.Write("Enter Price: ");
                string newPrice = Console.ReadLine();
                double price;

                bool correctPrice = double.TryParse(newPrice, out price);

                if (correctPrice)
                {
                    return price;
                }
                else if (!correctPrice)
                {
                    Console.WriteLine("### Incorrect price ### Use \".\"/\",\"");
                }
            }

        }

        private DateTime GetCloseDate(DateTime orderDate)
        {
            while (true)
            {
                Console.WriteLine($"Order date: {orderDate}");
                Console.Write($"Enter order close date (enter days (from order date)): ");
                string daysStr = Console.ReadLine();

                if (int.TryParse(daysStr, out int days))
                {
                    return orderDate.AddDays(days);
                    break;
                }
                else
                {
                    Console.WriteLine("### Incorrect value ### (enter example 3)");
                }
            }
        }
    }
}
