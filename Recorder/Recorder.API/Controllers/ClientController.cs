using Microsoft.AspNetCore.Mvc;
using Recorder.BLL.ApiIntrefaces;
using Recorder.DTOs.ClientDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recorder.API.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet("get/{id}")]
        public async Task<GetClientDTO> GetById(int id)
        {
            return await _clientService.GetByIdAsync(id);
        }

        [HttpGet("get/clients")]
        public async Task<IEnumerable<GetClientDTO>> GetAll()
        {
            return await _clientService.GetAllAsync();
        }

        [HttpPost("add")]
        public async Task<GetClientDTO> Add([FromBody] AddClientDTO addClientDTO)
        {
            return await _clientService.AddAsync(addClientDTO);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] ClientDTO clientDTO)
        {
            await _clientService.UpdateAsync(clientDTO);
        }

        [HttpDelete("remove/{id}")]
        public async Task RemoveById(int id)
        {
            await _clientService.RemoveByIdAsync(id);
        }

        [HttpDelete("remove")]
        public async Task Remove([FromBody] ClientDTO clientDTO)
        {
            await _clientService.RemoveAsync(clientDTO);
        }
    }
}
