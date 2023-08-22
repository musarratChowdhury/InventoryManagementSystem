﻿using IMS.BusinessModel.Dto.Vendor;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services.SecondaryServices
{
    public class VendorService : BaseSecondaryService<Vendor>
    {
        private readonly IBaseDao<Vendor> _baseDao;
        public VendorService()
        {
            _baseDao = new BaseDao<Vendor>();
        }

        public List<VendorDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new VendorDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<DropDownDto> GetDropDownList(ISession session)
        {
            try
            {
                var entities = _baseDao.GetAll(session);
                var result = new List<DropDownDto>();
                for (int i = 0; i < entities.Count; i++)
                {
                    var dto = new DropDownDto();
                    result.Add(MapToDropDownDto(entities[i], dto));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private DropDownDto MapToDropDownDto(Vendor entity, DropDownDto dto)
        {
            dto.Id = entity.Id;
            dto.FullName = entity.FirstName +" "+ entity.LastName;

            return dto;
        }

        public void Create(VendorFormDto vendorFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var vendor = new Vendor();
                    var mappedVendor = MapToEntity(vendorFormDto, vendor);
                    mappedVendor.Rank = GetNextRank(session);
                    mappedVendor.CreatedBy = userId;
                    mappedVendor.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedVendor, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(VendorDto vendorDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var vendor = new Vendor();
                    var mappedVendor = MapToEntity(vendorDto, vendor);
                    mappedVendor.ModificationDate = DateTime.Now;
                    mappedVendor.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedVendor, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private VendorDto MapToDto(Vendor entity, VendorDto dto)
        {

            dto.Id = entity.Id;
            dto.VendorTypeId = entity.VendorTypeId;
            dto.VendorTypeName = entity.VendorType.Name;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.Email = entity.Email;
            dto.Phone = entity.Phone;
            dto.Address = entity.Address;
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

        //for create operation
        private Vendor MapToEntity(VendorFormDto dto, Vendor vendor)
        {
            vendor.VendorTypeId = dto.VendorTypeId;
            vendor.FirstName = dto.FirstName;
            vendor.LastName = dto.LastName;
            vendor.Email = dto.Email;
            vendor.Phone = dto.Phone;
            vendor.Address = dto.Address;
            vendor.Version = 1;
            vendor.BusinessId = "IMS-1";
            vendor.Status = 1;

            return vendor;
        }

        //for update action
        private Vendor MapToEntity(VendorDto dto, Vendor vendor)
        {
            vendor.Id = dto.Id;
            vendor.CreatedBy = dto.CreatedBy;
            vendor.CreationDate = dto.CreationDate;
            vendor.Rank = dto.Rank;
            vendor.VendorTypeId = dto.VendorTypeId;
            vendor.FirstName = dto.FirstName;
            vendor.LastName = dto.LastName;
            vendor.Email = dto.Email;
            vendor.Phone = dto.Phone;
            vendor.Address = dto.Address;
            vendor.Version = 1;
            vendor.BusinessId = "IMS-1";
            vendor.Status = dto.Status;

            return vendor;
        }
    }
}
