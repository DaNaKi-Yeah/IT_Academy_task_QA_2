using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.ApiIntrefaces
{
    public interface IBaseService<TEnitityDTO, TAddEntityDTO, TGetEntityDTO>
    {
        public Task<TEnitityDTO> AddAsync(TAddEntityDTO orderDTO);
        public Task AddRangeAsync(IEnumerable<TAddEntityDTO> orderDTOs);
        public Task<TGetEntityDTO> GetByIdAsync(int id);
        public Task<IEnumerable<TGetEntityDTO>> GetAllAsync();
        public Task UpdateAsync(TEnitityDTO orderDTO);
        public Task RemoveAsync(TEnitityDTO orderDTO);
        public Task RemoveRangeAsync(IEnumerable<TEnitityDTO> orderDTOs);
        public Task RemoveByIdAsync(int id);
    }
}
