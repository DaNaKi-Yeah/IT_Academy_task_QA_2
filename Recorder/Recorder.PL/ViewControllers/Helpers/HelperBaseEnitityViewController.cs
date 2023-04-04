using Recorder.BLL.Services;
using Recorder.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.PL.ViewControllers.Helpers
{
    public static class HelperBaseEnitityViewController
    {
        public static int GetIdGivenCurrentList<T>(IEnumerable<T> collection) where T : BaseEntity
        {
            string TypeName = $"{typeof(T).Name}";

            string idStr;
            int id = -1;
            while (true)
            {
                Console.Write($"Enter {TypeName} Id: ");
                idStr = Console.ReadLine();

                bool isInteger = int.TryParse(idStr, out id);

                if (isInteger)
                {
                    bool isHaveClientById = collection.Any(c => c.ID == id);

                    if (isHaveClientById)
                    {
                        break;
                    }
                    else if (!isHaveClientById)
                    {
                        Console.WriteLine($"### Incorrect id. ### No have {TypeName} with this Id \"{idStr}\".");
                    }
                }
                else if (!isInteger)
                {
                    Console.WriteLine($"### Incorrect id. ### \"{idStr}\" is not number.");
                }
            }

            return id;
        }
    }
}
