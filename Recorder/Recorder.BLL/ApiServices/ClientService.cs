using AutoMapper;
using Recorder.BLL.ApiIntrefaces;
using Recorder.BLL.Services;
using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Interfaces;
using Recorder.DTOs.ClientDTOs;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiServices
{
    public class ClientService: BaseService<Client>, IClientService
    {
        public ClientService(IDbRepository<Client> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetClientDTO> AddAsync(AddClientDTO orderDTO)
        {
            Client client = MapToClient(orderDTO);

            Client addedClient = await _repository.AddAsync(client);
            await _repository.SaveChangesAsync();

            var getClientDTO = MapToGetClientDTO(addedClient);

            return getClientDTO;
        }

        public async Task AddRangeAsync(IEnumerable<AddClientDTO> orderDTOs)
        {
            var clients = _mapper.Map<IEnumerable<Client>>(orderDTOs);

            await _repository.AddRangeAsync(clients);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetClientDTO>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();

            var clientDTOs = _mapper.Map<IEnumerable<GetClientDTO>>(clients);

            return clientDTOs;
        }

        public async Task<GetClientDTO> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);

            var clientDTO = MapToGetClientDTO(client);

            return clientDTO;
        }

        public async Task RemoveAsync(ClientDTO orderDTO)
        {
            var client = MapToClient(orderDTO);

            await _repository.RemoveAsync(client);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            await _repository.RemoveByIdAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<ClientDTO> orderDTOs)
        {
            var clients = _mapper.Map<IEnumerable<Client>>(orderDTOs);

            await _repository.RemoveRangeAsync(clients);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClientDTO orderDTO)
        {
            var client = MapToClient(orderDTO);

            await _repository.UpdateAsync(client);
            await _repository.SaveChangesAsync();
        }

        private Client MapToClient(ClientDTO clientDTO)
        {
            return _mapper.Map<Client>(clientDTO);
        }
        private Client MapToClient(AddClientDTO clientDTO)
        {
            return _mapper.Map<Client>(clientDTO);
        }
        private GetClientDTO MapToGetClientDTO(Client order)
        {
            return _mapper.Map<GetClientDTO>(order);
        }
    }
}
