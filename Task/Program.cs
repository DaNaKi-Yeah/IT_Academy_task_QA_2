using Data.Controllers.Consoles;
using Data.DataBase.SQL_Server;
using Data.Models;

//
//  я делал это тз в течение 24 часов (начал вчера вечером), многое не успел сделать, прошу меня понять и не сильно снижать баллы :)) 
//


AppDbContext dataBase = new AppDbContext();

dataBase.Seed();

ConsoleController consoleController = new ConsoleController(dataBase);

consoleController.Start();

