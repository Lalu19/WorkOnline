using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Vehicles
{
    public class Vehicle : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string BrandName { get; set; }
        public string ChasisNo { get; set; }
        public string FuelType { get; set; }
        public string NoC { get; set; }
        public string RC { get; set; }
        public string InsuranceDetails { get; set; }
        public DateTime? PurchaseYear { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
