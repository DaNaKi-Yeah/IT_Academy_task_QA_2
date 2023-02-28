using Data.DataBase.SQL_Server;
using Data.Models.Entities;
using Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers.Consoles
{
    public class ConsoleClientController
    {
        private readonly Repository<Client> _clientsRepository;


        public ConsoleClientController(Repository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        // Добавить(Add) +
        // Редактировать(Edit) +
        // Удалить(Delete) +
        // Показать заказы клиента(Show client’s orders)

        public void Add()
        {
            Console.WriteLine("-------------Adding new Client-------------");

            string firstName, secondName, phoneNumber;

            uint orderAmount = 0;
            DateTime dateAdd = DateTime.Now;

            Console.Write("First name: ");
            firstName= Console.ReadLine();

            Console.Write("Second name: ");
            secondName = Console.ReadLine();

            Console.Write("Phone number: ");
            phoneNumber = Console.ReadLine();


            _clientsRepository.Add(new Client()
            {
                FirstName = firstName,
                SecondName = secondName,
                PhoneNumber = phoneNumber,
                OrderAmount = orderAmount,
                DateAdd = dateAdd
            });
        }

        public void Edit()
        {
            do
            {
                Console.Write("Enter client id: ");
                string clientIdStr = Console.ReadLine();

                if (int.TryParse(clientIdStr, out int clientId))
                {
                    if (clientId < 0)
                    {
                        Console.WriteLine("Incorrect id. Id is less 0.");
                        continue;
                    }

                    Client client = _clientsRepository.GetById((uint)clientId);

                    if (client is null)
                    {
                        Console.WriteLine("Incorrect id. There is no client with this id.");
                        continue;
                    }

                    ConsoleController.PrintClient(client);


                    do
                    {
                        Console.WriteLine("\n------------------\nWhat you will edit?");
                        Console.WriteLine("1. First name");
                        Console.WriteLine("2. Second name");
                        Console.WriteLine("3. Phone number\n");

                        Console.Write("Editing action number: ");
                        string editingField = Console.ReadLine();

                        if (editingField == "1")
                        {
                            Console.WriteLine("\nNew first name: ");
                            client.FirstName = Console.ReadLine();
                            break;
                        }
                        else if (editingField == "2")
                        {
                            Console.WriteLine("\nNew second name: ");
                            client.SecondName = Console.ReadLine();
                            break;
                        }
                        else if (editingField == "3")
                        {
                            Console.WriteLine("\nNew phone number: ");
                            client.PhoneNumber = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect select");
                        }

                    } while (true);

                    _clientsRepository.Update(client);
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect id.");
                }


            } while (true);
        }

        public void Delete()
        {
            do
            {
                Console.Write("Enter client id: ");
                string clientIdStr = Console.ReadLine();

                if (int.TryParse(clientIdStr, out int clientId))
                {
                    if (clientId < 0)
                    {
                        Console.WriteLine("Incorrect id. Id is less 0.");
                        continue;
                    }

                    Client client = _clientsRepository.GetById((uint)clientId);

                    if (client is null)
                    {
                        Console.WriteLine("Incorrect id. There is no client with this id.");
                        continue;
                    }

                    ConsoleController.PrintClient(client);

                    _clientsRepository.Delete(client);
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect id.");
                }


            } while (true);
        }


    }
}
