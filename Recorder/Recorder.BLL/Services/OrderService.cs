using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Add(Order Order)
        {
            return _orderRepository.Add(Order);
        }

        public void AddRange(IEnumerable<Order> orders)
        {
            _orderRepository.AddRange(orders);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public void Remove(Order order)
        {
            _orderRepository.Remove(order);
        }

        public void RemoveById(int id)
        {
            _orderRepository.RemoveById(id);
        }
    }
}
