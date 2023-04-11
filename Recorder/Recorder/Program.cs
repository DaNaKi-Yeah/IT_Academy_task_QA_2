using Recorder.BLL.Services;
using Recorder.DAL.DataBase.SQL;
using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Implementations;
using Recorder.PL.ViewControllers.Implementations;
using Recorder.PL.ViewControllers.Interfaces;

using (AppDbContext context = new AppDbContext())
{

    Repository<Order> orderRepository = new Repository<Order>(context); 
    Repository<Client> clientRepository = new Repository<Client>(context);

    OrderService orderService = new OrderService(orderRepository);
    ClientService clientService = new ClientService(clientRepository);

    IOrderViewController orderViewController = new OrderViewController(orderService);
    IClientViewController clientViewController = new ClientViewController(clientService, orderViewController.DisplayAll);
    IMainViewController mainViewController = new MainViewController(clientViewController, orderViewController);

    mainViewController.Display();
}