using Microsoft.EntityFrameworkCore.Design;
using Recorder.BLL.Services;
using Recorder.DAL.Entities.Models;
using Recorder.PL.ViewControllers.Helpers;
using Recorder.PL.ViewControllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Implementations
{
    public class ClientViewController : IClientViewController
    {
        public delegate void DisplayOrders(IEnumerable<Order> orders);

        private readonly DisplayOrders _displayOrders; //maybe incorrect name
        private readonly ClientService _clientService;
        

        public ClientViewController(ClientService clientService, DisplayOrders displayOrders)
        {
            _clientService = clientService;
            _displayOrders = displayOrders;
        }


        public void DisplayAll()
        {
            var clients = _clientService.GetAll();

            Console.WriteLine("\n----- Clients: -----\n");

            foreach (Client client in clients)
            {
                DisplayOne(client);
                Console.WriteLine("----------------------");
            }
        }
        public void DisplayOne(Client client)
        {
            Console.WriteLine("Client");
            Console.WriteLine($"Id: {client.ID}");
            Console.WriteLine($"Date add: {client.DateAdd}");
            Console.WriteLine($"First name: {client.FirstName}");
            Console.WriteLine($"Second name: {client.SecondName}");
            Console.WriteLine($"Phone number: {client.PhoneNumber}");
            Console.WriteLine($"Order amount: {client.OrderAmount}");
        }

        //TODO: make OrderViewController.DisplayAll(orders) and do DI in ctor to displayOrders
        //### dind't test ###
        public void ShowClientOrders(Client client)
        {
            var orders = client.Orders;

            if (orders is null || !orders.Any())
            {
                Console.WriteLine("No have orders");
            }
            else
            {
                _displayOrders.Invoke(orders);
            }
        }
        public void Add()
        {
            DateTime dateTimeNow = DateTime.Now;
            string firstName, secondName, phoneNumber;

            Console.WriteLine("\nAdding new client\n");

            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter second name: ");
            secondName = Console.ReadLine();
            Console.Write("Enter phone number: ");
            phoneNumber = Console.ReadLine();


            Client newClient = new Client(firstName, secondName, phoneNumber, dateTimeNow) ;

            _clientService.Add(newClient);
        }
        public void EditById()
        {
            DisplayAll();

            Console.WriteLine("\nEditing Client by id\n");

            int clientId = HelperBaseEnitityViewController.GetIdGivenCurrentList(_clientService.GetAll());

            Client client = _clientService.GetById(clientId);
            DisplayOne(client);

            Console.WriteLine();
            Console.WriteLine("Edit property:");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Second name");
            Console.WriteLine("3. Phone number");
            Console.WriteLine();


            while (true)
            {
                Console.Write("Enter property number: ");
                string propertyNumber = Console.ReadLine();

                if (propertyNumber == "1")
                {
                    Console.WriteLine($"First name: {client.FirstName}");
                    Console.Write("Enter new First name: ");
                    string newFirstName = Console.ReadLine();
                    client.FirstName = newFirstName;
                    break;
                }
                else if (propertyNumber == "2")
                {
                    Console.WriteLine($"Second name: {client.SecondName}");
                    Console.Write("Enter new Second name: ");
                    string newSecondName = Console.ReadLine();
                    client.SecondName = newSecondName;
                    break;
                }
                else if (propertyNumber == "3")
                {
                    Console.WriteLine($"Phone number: {client.PhoneNumber}");
                    Console.Write("Enter new Phone number: ");
                    string newPhoneNumber = Console.ReadLine();
                    client.PhoneNumber = newPhoneNumber;
                    break;
                }
                else
                {
                    Console.WriteLine("### Incorrect property number. ###");
                }
            }
            _clientService.Update(client);
        }
        public void RemoveById()
        {
            DisplayAll();

            Console.WriteLine("\nRemoving Client by id\n");

            int clientId = HelperBaseEnitityViewController.GetIdGivenCurrentList(_clientService.GetAll());

            _clientService.RemoveById(clientId);
        }
       
    }
}
