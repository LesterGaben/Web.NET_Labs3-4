using AutoMapper;
using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services.Abstract {
    public abstract class BaseService<TEntity> where TEntity : class {

        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IGenericRepository<TEntity> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
