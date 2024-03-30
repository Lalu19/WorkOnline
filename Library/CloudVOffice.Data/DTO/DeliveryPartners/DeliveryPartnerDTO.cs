﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.DeliveryPartners
{
    public class DeliveryPartnerDTO
    {
        public Int64? DeliveryPartnerId { get; set; }
        public Int64? WareHuoseId { get; set; }
        public string? DriverName { get; set; }
        public string? DriverContact { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerContact { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? FuelType { get; set; }
        public string? VehicleType { get; set; }
        public string? RegistrationType { get; set; }
        public double? LoadCapacity { get; set; }
        public string? VehicleName { get; set; }
        public string? EngineNumber { get; set; }
        public string? ChassisNumber { get; set; }
        public DateTime? RegistrationYear { get; set; }
        public string? VehicleNumber { get; set; }
        public string? PollutionCertificate { get; set; }
        public string? Insurance { get; set; }
        public string? Mileage { get; set; }
        public string? OwnerPhoto { get; set; }
        public string? DriverPhoto { get; set; }
        public string? VehicleFrontPhoto { get; set; }
        public string? VehicleBackPhoto { get; set; }
        public string? AssignedCode { get; set; }
        public bool Availability { get; set; }
        public bool TaskAccepted { get; set; }
        public bool TaskRejected { get; set; }
        public bool NotificationSent { get; set; }



        public IFormFile? OwnerPhotoUp { get; set; }
        public IFormFile? DriverPhotoUp { get; set; }
        public IFormFile? VehicleFrontPhotoUp { get; set; }
        public IFormFile? VehicleBackPhotoUp { get; set; }


        public Int64 CreatedBy { get; set; }
    }
}
