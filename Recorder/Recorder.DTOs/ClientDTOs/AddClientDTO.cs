using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.DTOs.ClientDTOs
{
    public class AddClientDTO
    {
        public DateTime DateAdd { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
