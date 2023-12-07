using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Employees
{
    public class Employee : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AssignedWareHouse { get; set; }
        public string? VehicleNumber { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Priority { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
