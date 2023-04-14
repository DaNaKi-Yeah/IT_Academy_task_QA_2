using Recorder.DAL.Entities.Models;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiIntrefaces
{
    public interface IOrderService:IBaseService<OrderDTO, AddOrderDTO, GetOrderDTO>
    {

    }
}
