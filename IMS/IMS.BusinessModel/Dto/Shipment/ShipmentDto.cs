﻿using System;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.BusinessModel.Dto.Shipment
{
    public class ShipmentDto : BaseDto
    {
        public DateTime ShipmentDate { get; set; }
        public long SalesOrderId { get; set; }
        public string SalesOrderSerialNumber { get; set; }
        public long ShipmentTypeId { get; set; }
        public string ShipmentTypeName { get; set; }
    }

    public class ShipmentFormDto
    {
        public DateTime ShipmentDate { get; set; }
        public long SalesOrderId { get; set; }
        public long ShipmentTypeId { get; set; }
    }
}