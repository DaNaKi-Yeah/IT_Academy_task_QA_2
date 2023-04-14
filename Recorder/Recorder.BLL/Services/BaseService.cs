using AutoMapper;
using Recorder.DAL.Entities.Models;
using Recorder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.Services
{
    public class BaseService<TEntity>
    {
        protected readonly IDbRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IDbRepository<TEntity> repository, IMapper mapper) { _repository = repository; _mapper = mapper; }
    }
}
