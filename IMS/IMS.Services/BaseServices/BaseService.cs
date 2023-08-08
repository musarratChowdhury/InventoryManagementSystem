using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity.Common;
using IMS.BusinessModel.Entity.Configuration;
using IMS.Dao;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Services.BaseServices
{
    public interface IBaseService<IConfigurationDto, IConfigurationFormData, TEntity> where TEntity : IBaseEntity 
                                                           
    {
        IEnumerable<ConfigurationDto> GetAll(ISession session);
        void Delete(long entityId, ISession session);
        ConfigurationDto MapToDto(TEntity entity, ConfigurationDto dto);
        TEntity MapToEntity(ConfigurationFormData DtoForm, TEntity entity);
    }
    public class BaseService<TDto, TDtoForm, TEntity> : IBaseService<IConfigurationDto, IConfigurationFormData, TEntity> where TEntity : IBaseEntity 
    {
        private IBaseDao<TEntity> _BaseDao;

        public BaseService()
        {
            _BaseDao = new BaseDao<TEntity>();
        }

        public IEnumerable<ConfigurationDto> GetAll(ISession session)
        {
            var entities = _BaseDao.GetAll(session);
            var dto = new ConfigurationDto();
            var result =  entities.Select(entity => MapToDto(entity ,dto));
            return result;
        }

        public void Delete(long entityId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entity = _BaseDao.GetById(entityId, session);
                    if (entity != null)
                    {
                        _BaseDao.Delete(entity, session);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public ConfigurationDto MapToDto(TEntity entity, ConfigurationDto dto)
        {

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Status = entity.Status;
            dto.Rank = entity.Rank;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreationDate = entity.CreationDate;
            dto.ModifiedBy = entity.ModifiedBy;
            dto.ModificationDate = entity.ModificationDate;
            dto.Version = entity.Version;
            dto.BusinessId = entity.BusinessId;

            return dto;
        }

        public TEntity MapToEntity(ConfigurationFormData dtoForm, TEntity entity) 
        {

            entity.Id = dtoForm.Id;
            entity.Name = dtoForm.Name;
            entity.Description = dtoForm.Description;
            entity.Status = dtoForm.Status;
            entity.Rank = dtoForm.Rank;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = 1;
            entity.ModificationDate = DateTime.Now;
            entity.ModifiedBy = 1;
            entity.Version = 1;
            entity.BusinessId = "IMS-1";

            return entity;
        }
    }
}
