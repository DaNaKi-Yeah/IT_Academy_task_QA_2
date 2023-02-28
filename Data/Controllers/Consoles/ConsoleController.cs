using Data.DataBase.SQL_Server;
using Data.Models.Entities;
using Data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers.Consoles
{
    public class ConsoleController
    {
        enum Action
        {
            Add,
            Edit,
            Delete,
            Return,
            Exit,
            ShowOrdersByClient
        }
        enum Table
        {
            Clients,
            Orders
        }
        private readonly AppDbContext _context;

        private readonly Repository<Client> _clientsRepository;
        private readonly Repository<Order> _ordersRepository;


        public ConsoleController(AppDbContext context)
        {
            _context = context;
            _clientsRepository = new Repository<Client>(_context);
            _ordersRepository = new Repository<Order>(_context);
        }


        public void Start()
        {
            bool isWorking = true;

            do
            {
                Table table = ChooseTable();

                do
                {
                    Action action = ChooseAction(table);

                    if (action == Action.Return)
                    {
                        break;
                    }
                    else if (action == Action.Exit)
                    {
                        isWorking = false;
                        break;
                    }
                    else
                    {
                        DoAction(table, action);
                    }
                } while (true);

            } while (isWorking);


            Console.WriteLine("the end");
            Console.ReadKey();
        }


        private Table ChooseTable()
        {
            do
            {
                Console.WriteLine("Choose table:");
                Console.WriteLine("1. Clients");
                Console.WriteLine("2. Orders");

                Console.Write("\ntable number: ");
                string tableNumber = Console.ReadLine();


                if (tableNumber == "1")
                {
                    PrintClients();
                    return Table.Clients;
                }
                else if (tableNumber == "2")
                {
                    PrintOrders();
                    return Table.Orders;
                }
                else
                {
                    Console.WriteLine("\nIncorrect number\n");
                }
            } while (true);
        }


        private void PrintClients()
        {
            List<Client> clients = _clientsRepository.GetAll();

            if (clients is null)
            {
                Console.WriteLine("Clients is empty");
            }

            Console.WriteLine("--------------Clients--------------");
            foreach (Client client in clients)
            {
                PrintClient(client);
                Console.WriteLine("=================================");
            }
        }
        public static void PrintClient(Client client)
        {
            if (client is null)
            {
                Console.WriteLine("Not have a client");
            }

            Console.WriteLine($"ID: {client.ID}");
            Console.WriteLine($"First name: {client.FirstName}");
            Console.WriteLine($"Second name: {client.SecondName}");
            Console.WriteLine($"Phone number: {client.PhoneNumber}");
            Console.WriteLine($"Order amount: {client.OrderAmount}");
            Console.WriteLine($"Date add: {client.DateAdd}");
        }


        private void PrintOrders()
        {
            List<Order> orders = _ordersRepository.GetAll();

            if (orders is null)
            {
                Console.WriteLine("Orders is empty");
            }

            Console.WriteLine("--------------Orders--------------");
            foreach (Order order in orders)
            {
                PrintOrder(order);
                Console.WriteLine("=================================");
            }
        }
        public static void PrintOrder(Order order)
        {
            if (order is null)
            {
                Console.WriteLine("Not have a order");
            }

            Console.WriteLine($"ID: {order.ID}");
            Console.WriteLine($"Client ID: {order.ClientID}");
            Console.WriteLine($"Order date: {order.OrderDate}");
            Console.WriteLine($"Close date: {order.CloseDate}");
            Console.WriteLine($"Description: {order.Description}");
            Console.WriteLine($"Order price: {order.Price}");
        }


        private Action ChooseAction(Table table)
        {
            do
            {
                Console.WriteLine("Choose action:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Return");
                Console.WriteLine("5. Exit");
                if (table == Table.Clients)
                    Console.WriteLine("6. Show client's orders");


                Console.Write("\naction number: ");
                string actionNumber = Console.ReadLine();

                if (int.TryParse(actionNumber, out int number))
                {
                    if (number == 1)
                    {
                        return Action.Add;
                    }
                    else if (number == 2)
                    {
                        return Action.Edit;
                    }
                    else if (number == 3)
                    {
                        return Action.Delete;
                    }
                    else if (number == 4)
                    {
                        return Action.Return;
                    }
                    else if (number == 5)
                    {
                        return Action.Exit;
                    }
                    else if (number == 6)
                    {
                        return Action.ShowOrdersByClient;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number\n\n");
                }
            } while (true);
        }


        private void DoAction(Table table, Action action)
        {
            // Добавить(Add)
            // Редактировать(Edit)
            // Удалить(Delete)
            // Показать заказы клиента(Show client’s orders)


            if (table == Table.Clients)
            {
                ConsoleClientController consoleClientController = new ConsoleClientController(_clientsRepository);
                if (action == Action.Add)
                {
                    consoleClientController.Add();
                }
                else if(action == Action.Edit)
                {
                    consoleClientController.Edit();
                }
                else if(action == Action.Delete)
                {
                    consoleClientController.Delete();
                }
            }
            else if (table == Table.Orders)
            {


            }

            //_context.UpdateOrderAmountsForClients();
        }
    }
}
