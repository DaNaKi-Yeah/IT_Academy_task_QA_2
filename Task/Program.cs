using Data.Controllers.Consoles;
using Data.DataBase.SQL_Server;
using Data.Models;


AppDbContext dataBase = new AppDbContext();

dataBase.Seed();

ConsoleController consoleController = new ConsoleController(dataBase);

consoleController.Start();

