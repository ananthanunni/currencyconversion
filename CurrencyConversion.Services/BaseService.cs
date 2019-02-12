using CurrencyConversion.Dto;
using CurrencyConversion.Data.Models;
using AutoMapper;

namespace CurrencyConversion.Services
{
    public abstract class BaseService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        private IMapper _toEntityMapper;
        private IMapper _toDtoMapper;

        public BaseService()
        {
            _toEntityMapper = new MapperConfiguration(cfg => cfg.CreateMap<TDto, TEntity>()).CreateMapper();
            _toDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<TDto, TEntity>()).CreateMapper();
        }

        protected TEntity ToEntity(TDto dto) => _toEntityMapper.Map<TDto, TEntity>(dto);
        protected TDto ToDto(TEntity entity) => _toDtoMapper.Map<TEntity, TDto>(entity);
    }
}
