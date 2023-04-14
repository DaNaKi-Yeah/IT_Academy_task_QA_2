using Recorder.DAL.Entities.Models;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiIntrefaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> AddAsync(AddOrderDTO orderDTO);
        public Task AddRangeAsync(IEnumerable<AddOrderDTO> orderDTOs);
        public Task<GetOrderDTO> GetByIdAsync(int id);
        public Task<IEnumerable<GetOrderDTO>> GetAllAsync();
        public Task UpdateAsync(OrderDTO orderDTO);
        public Task RemoveAsync(OrderDTO orderDTO);
        public Task RemoveRangeAsync(IEnumerable<OrderDTO> orderDTOs);
        public Task RemoveByIdAsync(int id);
    }
}
