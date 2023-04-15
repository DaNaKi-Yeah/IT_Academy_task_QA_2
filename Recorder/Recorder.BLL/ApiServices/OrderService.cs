using AutoMapper;
using Recorder.BLL.ApiIntrefaces;
using Recorder.BLL.Services;
using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Interfaces;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiServices
{
    public class OrderService : BaseService<Order>,IOrderService
    {
        public OrderService(IDbRepository<Order> repository, IMapper mapper) : base(repository, mapper) { }


        public async Task<GetOrderDTO> AddAsync(AddOrderDTO orderDTO)
        {
            Order addOrder = MapToOrder(orderDTO);

            Order addedOrder = await _repository.AddAsync(addOrder);
            await _repository.SaveChangesAsync();

            GetOrderDTO getOrderDTO = MapToGetOrderDTO(addedOrder);

            return getOrderDTO;
        }
        public async Task AddRangeAsync(IEnumerable<AddOrderDTO> orderDTOs)
        {
            var addOrders = _mapper.Map<IEnumerable<Order>>(orderDTOs);

            await _repository.AddRangeAsync(addOrders);
            await _repository.SaveChangesAsync();
        }

        public async Task<GetOrderDTO> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);

            var getOrderDTO = MapToGetOrderDTO(order);

            return getOrderDTO;
        }
        public async Task<IEnumerable<GetOrderDTO>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();

            var getOrderDTOs = _mapper.Map<IEnumerable<GetOrderDTO>>(orders);

            return getOrderDTOs;
        }

        public async Task RemoveAsync(OrderDTO orderDTO)
        {
            var order = MapToOrder(orderDTO);

            await _repository.RemoveAsync(order);
            await _repository.SaveChangesAsync();
        }
        public async Task RemoveByIdAsync(int id)
        {
            await _repository.RemoveByIdAsync(id);
            await _repository.SaveChangesAsync();
        }
        public async Task RemoveRangeAsync(IEnumerable<OrderDTO> orderDTOs)
        {
            var orders = _mapper.Map<IEnumerable<Order>>(orderDTOs);

            await _repository.RemoveRangeAsync(orders);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDTO orderDTO)
        {
            var order = MapToOrder(orderDTO);

            await _repository.UpdateAsync(order);
            await _repository.SaveChangesAsync();
        }

        
        private Order MapToOrder(OrderDTO orderDTO)
        {
            return _mapper.Map<Order>(orderDTO);
        }
        private Order MapToOrder(AddOrderDTO orderDTO)
        {
            return _mapper.Map<Order>(orderDTO);
        }
        private GetOrderDTO MapToGetOrderDTO(Order order)
        {
            return _mapper.Map<GetOrderDTO>(order);
        }
    }
}
