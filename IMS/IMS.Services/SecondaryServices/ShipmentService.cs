﻿using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.Shipment;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;

namespace IMS.Services.SecondaryServices
{
    public class ShipmentService : BaseSecondaryService<Shipment>
    {
         private readonly IBaseDao<Shipment> _baseDao;
        public ShipmentService()
        {
            _baseDao = new BaseDao<Shipment>();
        }

        public List<ShipmentDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new ShipmentDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(ShipmentFormDto shipmentFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var shipment = new Shipment();
                    var mappedShipment = MapToEntity(shipmentFormDto, shipment);
                    mappedShipment.Rank = GetNextRank(session);
                    mappedShipment.CreatedBy = userId;
                    mappedShipment.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedShipment, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(ShipmentDto shipmentDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var shipment = new Shipment();
                    var mappedShipment = MapToEntity(shipmentDto, shipment);
                    mappedShipment.ModificationDate = DateTime.Now;
                    mappedShipment.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedShipment, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private ShipmentDto MapToDto(Shipment entity, ShipmentDto dto)
        {

            dto.Id = entity.Id;
            dto.ShipmentTypeId = entity.ShipmentTypeId;
            dto.ShipmentTypeName = entity.ShipmentType.Name;
            dto.ShipmentDate = entity.ShipmentDate;
            dto.ShippingAddress = entity.ShippingAddress;
            dto.SalesOrderId = entity.SalesOrderId;
            dto.SalesOrderSerialNumber = $"#SO{entity.SalesOrder.Id}C{entity.SalesOrder.CustomerId}";
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
        private Shipment MapToEntity(ShipmentFormDto dto, Shipment shipment)
        {
            shipment.ShipmentTypeId = dto.ShipmentTypeId;
            shipment.ShipmentDate = dto.ShipmentDate;
            shipment.ShippingAddress = dto.ShippingAddress;
            shipment.SalesOrderId = dto.SalesOrderId;
            shipment.Version = 1;
            shipment.BusinessId = "IMS-1";
            shipment.Status = 1;

            return shipment;
        }

        //for update action
        private Shipment MapToEntity(ShipmentDto dto, Shipment shipment)
        {
            shipment.Id = dto.Id;
            shipment.CreatedBy = dto.CreatedBy;
            shipment.CreationDate = dto.CreationDate;
            shipment.Rank = dto.Rank;
            shipment.ShipmentTypeId = dto.ShipmentTypeId;
            shipment.ShipmentDate = dto.ShipmentDate;
            shipment.ShippingAddress = dto.ShippingAddress;
            shipment.SalesOrderId = dto.SalesOrderId;
            shipment.Version = 1;
            shipment.BusinessId = "IMS-1";
            shipment.Status = dto.Status;

            return shipment;
        }
    }
}