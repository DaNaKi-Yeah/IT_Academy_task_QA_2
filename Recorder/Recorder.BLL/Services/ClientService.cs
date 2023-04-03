using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.Services
{
    public class ClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Add(Client client)
        {
            return _clientRepository.Add(client);
        }

        public void AddRange(IEnumerable<Client> clients)
        {
            _clientRepository.AddRange(clients);
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }

        public void Remove(Client client)
        {
            _clientRepository.Remove(client);
        }

        public void RemoveById(int id)
        {
           _clientRepository.RemoveById(id);
        }
    }
}
