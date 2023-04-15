using Microsoft.AspNetCore.Mvc;
using Recorder.BLL.ApiIntrefaces;
using Recorder.DTOs.OrderDTOs;

namespace Recorder.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("get/{id}")]
        public async Task<GetOrderDTO> GetById(int id)
        {
            return await _orderService.GetByIdAsync(id);
        }

        [HttpGet("get/orders")]
        public async Task<IEnumerable<GetOrderDTO>> GetAll()
        {
            return await _orderService.GetAllAsync();
        }

        [HttpPost("add")]
        public async Task<GetOrderDTO> Add([FromBody] AddOrderDTO addOrderDTO)
        {
            return await _orderService.AddAsync(addOrderDTO);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] OrderDTO orderDTO)
        {
            await _orderService.UpdateAsync(orderDTO);
        }

        [HttpDelete("remove/{id}")]
        public async Task RemoveById(int id)
        {
            await _orderService.RemoveByIdAsync(id);
        }

        [HttpDelete("remove")]
        public async Task Remove([FromBody] OrderDTO orderDTO)
        {
            await _orderService.RemoveAsync(orderDTO);
        }
    }
}
