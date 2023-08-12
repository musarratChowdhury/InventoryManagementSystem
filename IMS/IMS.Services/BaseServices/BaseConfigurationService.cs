using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Entity.Common;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace IMS.Services.BaseServices
{
    public interface IBaseConfigurationService<IConfigurationDto, IConfigurationFormData, TEntity> where TEntity : IConfigurationEntity
                                                           
    {
        IEnumerable<ConfigurationDto> GetAll(ISession session);
        void Create(ConfigurationFormData dtoFormData, ISession session);
        void Update(ConfigurationFormData dtoFormData, ISession session);
        void Delete(long entityId, ISession session);
        ConfigurationDto MapToDto(TEntity entity, ConfigurationDto dto);
        TEntity MapToEntity(ConfigurationFormData DtoForm, TEntity entity);
    }
    public class BaseConfigurationService<TDto, TDtoForm, TEntity> : IBaseConfigurationService<IConfigurationDto, IConfigurationFormData, TEntity> where TEntity : IConfigurationEntity
    {
        private IBaseDao<TEntity> _BaseDao;
        private long _currentUserId;

        public BaseConfigurationService()
        {
            _BaseDao = new BaseDao<TEntity>();
            _currentUserId = Int64.Parse(ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public IEnumerable<ConfigurationDto> GetAll(ISession session)
        {
            try
            {
                var entities = _BaseDao.GetAll(session);
                var dto = new ConfigurationDto();
                var result =  entities.Select(entity => MapToDto(entity ,dto));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Create(ConfigurationFormData dtoFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entityType = ConfigurationEntity.CreateInstance<TEntity>();
                    var entity = MapToEntity(dtoFormData, entityType);
                    entity.Rank = GetNextRank(session);
                    _BaseDao.Create(entity, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public void Update(ConfigurationFormData dtoFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entityType = ConfigurationEntity.CreateInstance<TEntity>();
                    var entity = MapToEntity(dtoFormData, entityType);
                    _BaseDao.Update(entityType, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
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

        protected int GetNextRank(ISession session)
        {
            try {
                var highestRank = _BaseDao.GetHighestRank(session);
                return highestRank + 1;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            entity.CreatedBy = _currentUserId;
            entity.ModificationDate = DateTime.Now;
            entity.ModifiedBy = 1;
            entity.Version = 1;
            entity.BusinessId = "IMS-1";

            return entity;
        }
    }
}
