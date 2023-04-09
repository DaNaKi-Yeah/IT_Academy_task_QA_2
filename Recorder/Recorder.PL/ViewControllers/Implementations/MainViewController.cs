using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Recorder.PL.ViewControllers.Common.Enums;
using Recorder.PL.ViewControllers.Helpers;
using Recorder.PL.ViewControllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Implementations
{
    public class MainViewController : IMainViewController
    {
        private RecorderTable _currentRecorderTable;

        private readonly IClientViewController _clientViewController;
        private readonly IOrderViewController _orderViewController;


        public MainViewController(IClientViewController clientViewController, IOrderViewController orderViewController)
        {
            _clientViewController = clientViewController;
            _orderViewController = orderViewController;
        }


        public void Display()
        {
            while (true)
            {
                ChooseTable();
                DisplayTable();

                while (true)
                {
                    ActionMenu actionMenu = ChooseAction();

                    if (actionMenu == ActionMenu.Return)
                    {
                        //return for choose table
                        Console.WriteLine("\nReturned\n");
                        break;
                    }
                    else if (actionMenu == ActionMenu.Exit)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("============ start action ============");
                        DoAction(actionMenu);
                        Console.WriteLine("============ end action ============");
                        DisplayTable();
                    }
                }
            }
        }


        private void ChooseTable()
        {
            Console.WriteLine("Tables:");
            Console.WriteLine("1. Clients");
            Console.WriteLine("2. Orders");

            while (true)
            {
                Console.Write("\nEnter table number: ");
                string tableNumber = Console.ReadLine();

                if (tableNumber == "1")
                {
                    _currentRecorderTable = RecorderTable.Clients;
                    break;
                }
                else if (tableNumber == "2")
                {
                    _currentRecorderTable = RecorderTable.Orders;
                    break;
                }
                else
                {
                    Console.WriteLine("### Incorrect table number ###");
                }
            }
        }

        private void DisplayTable()
        {
            if (_currentRecorderTable == RecorderTable.Clients)
            {
                _clientViewController.DisplayAll();
            }
            else if (_currentRecorderTable == RecorderTable.Orders)
            {
                _orderViewController.DisplayAll();
            }
        }

        private ActionMenu ChooseAction()
        {
            Console.WriteLine($"\nAction menu for {_currentRecorderTable}: ");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Return");
            Console.WriteLine("5. Exit");

            if (_currentRecorderTable == RecorderTable.Clients)
            {
                Console.WriteLine("6. Show client orders");
            }

            while (true)
            {
                Console.Write("\nEnter action number: ");
                string actionNumber = Console.ReadLine();

                if (actionNumber == "1")
                {
                    return ActionMenu.Add;
                }
                else if (actionNumber == "2")
                {
                    return ActionMenu.Edit;
                }
                else if (actionNumber == "3")
                {
                    return ActionMenu.Remove;
                }
                else if (actionNumber == "4")
                {
                    return ActionMenu.Return;
                }
                else if (actionNumber == "5")
                {
                    return ActionMenu.Exit;
                }
                else if (actionNumber == "6" && _currentRecorderTable == RecorderTable.Clients)
                {
                    return ActionMenu.ShowClientOrders;
                }
                else
                {
                    Console.WriteLine("### Incorrect action number ###");
                }
            }
        }

        private void DoAction(ActionMenu actionMenu)
        {
            if (_currentRecorderTable == RecorderTable.Clients)
            {
                if (actionMenu == ActionMenu.Add)
                {
                    _clientViewController.Add();
                }
                else if (actionMenu == ActionMenu.Edit)
                {
                    _clientViewController.EditById();
                }
                else if (actionMenu == ActionMenu.Remove)
                {
                    _clientViewController.RemoveById();
                }
                else if (actionMenu == ActionMenu.ShowClientOrders)
                {
                    int clientId = _clientViewController.GetEntityId();
                    _clientViewController.ShowClientOrders(clientId);
                }
            }
            else if (_currentRecorderTable == RecorderTable.Orders)
            {
                if (actionMenu == ActionMenu.Add)
                {
                    _clientViewController.DisplayAll();
                    int clientId = _clientViewController.GetEntityId();
                    _orderViewController.Add(clientId);
                }
                else if (actionMenu == ActionMenu.Edit)
                {
                    _orderViewController.EditById();
                }
                else if (actionMenu == ActionMenu.Remove)
                {
                    _orderViewController.RemoveById();
                }
            }
            else
            {
                throw new ArgumentNullException("didn't choose RecorderTable");
            }
        }
    }
}
