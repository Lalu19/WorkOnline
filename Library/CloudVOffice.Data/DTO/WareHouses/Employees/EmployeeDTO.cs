using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Employees
{
    public class EmployeeDTO
    {
        public Int64? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AssignedWareHouse { get; set; }
        public string VehicleNumber { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Priority { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
