using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Data.DTO.WareHouses.Employees;

namespace CloudVOffice.Services.WareHouses.Employees
{
	public interface IEmployeeService
	{		
		public MessageEnum EmployeeCreate (EmployeeDTO employeeDTO);
		public Employee GetEmployeeById(Int64 employeeId);
		public List<Employee> GetEmployees();
		public MessageEnum EmployeeUpdate (EmployeeDTO employeeDTO);
		public MessageEnum EmployeeDelete (Int64 employeeId, Int64 DeletedBy);
	}
}
