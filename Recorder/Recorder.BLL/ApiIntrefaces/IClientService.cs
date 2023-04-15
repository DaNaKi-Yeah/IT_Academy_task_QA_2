using Recorder.DTOs.ClientDTOs;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiIntrefaces
{
    public interface IClientService:IBaseService<ClientDTO, AddClientDTO, GetClientDTO>
    {

    }
}
