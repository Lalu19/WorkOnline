using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Data.DTO.WareHouses.Employees;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;

namespace CloudVOffice.Services.WareHouses.Employees
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<Employee> _employeeRepo;

		public EmployeeService(ApplicationDBContext dbContext, ISqlRepository<Employee> EmployeeRepo)
		{
			_dbContext = dbContext;
			_employeeRepo = EmployeeRepo;
		}

		public MessageEnum EmployeeCreate(EmployeeDTO employeeDTO)
		{
			try
			{
				var emp = _dbContext.Employees.Where(em => em.EmployeeId == employeeDTO.EmployeeId && em.Deleted == false).FirstOrDefault();

				if (emp == null)
				{
					Employee employee = new Employee();

					employee.EmployeeName = employeeDTO.EmployeeName;
					employee.DateOfBirth = employeeDTO.DateOfBirth;
					employee.AssignedWareHouse = employeeDTO.AssignedWareHouse;
					employee.VehicleNumber = employeeDTO.VehicleNumber;
					employee.Position = employeeDTO.Position;
					employee.Priority = employeeDTO.Priority;
					employee.Mobile = employeeDTO.Mobile;					
					employee.IsActive = employeeDTO.IsActive;

					employee.CreatedBy = employeeDTO.CreatedBy;
					var obj = _employeeRepo.Insert(employee);
					_dbContext.SaveChanges();

					return MessageEnum.Success;
				}
				else
				{
					return MessageEnum.Duplicate;
				}

			}
			catch 
			{
				throw;
			}
		}		

		public MessageEnum EmployeeUpdate(EmployeeDTO employeeDTO)
		{
			try
			{
				var emp = _dbContext.Employees.Where(em => em.EmployeeId != employeeDTO.EmployeeId && em.EmployeeName == employeeDTO.EmployeeName && em.Deleted == false).FirstOrDefault();
				if (emp == null)
				{
					var employee = _dbContext.Employees.Where(e => e.EmployeeId == employeeDTO.EmployeeId).FirstOrDefault();
					if (employee != null)
					{
						employee.EmployeeName = employeeDTO.EmployeeName;
						employee.DateOfBirth = employeeDTO.DateOfBirth;
						employee.AssignedWareHouse = employeeDTO.AssignedWareHouse;
						employee.VehicleNumber = employeeDTO.VehicleNumber;
						employee.Position = employeeDTO.Position;
						employee.Priority = employeeDTO.Priority;
						employee.Mobile = employeeDTO.Mobile;
						employee.CreatedBy = employeeDTO.CreatedBy;
						employee.IsActive = employeeDTO.IsActive;

						employee.UpdatedDate = DateTime.Now;
						_employeeRepo.Update(employee);
						_dbContext.SaveChanges();

						return MessageEnum.Updated;
					}
					else { return MessageEnum.Invalid; }
				}

				else
				{
					return MessageEnum.Duplicate;
				}
			}
			catch
			{
				throw;
			}
		}

		public Employee GetEmployeeById(Int64 employeeId)
		{
			try
			{			
				var employee = _dbContext.Employees.FirstOrDefault(em => em.EmployeeId == employeeId);
				return employee;
			}
			catch
			{
				throw;
			}
		}

		public List<Employee> GetEmployees()
		{
			try
			{

				List<WareHuose> wareHuoses = _dbContext.WareHouses.Where(wh => wh.Deleted == false).ToList();
				List<Vehicle> vehicles = _dbContext.Vehicles.Where(v => v.Deleted == false).ToList();

				List<Employee> employees = _dbContext.Employees.Where(emp => emp.Deleted == false).ToList();


				foreach (var employee in employees)
				{

					WareHuose assignedWareHouse = wareHuoses.FirstOrDefault(wh => wh.WareHuoseId == Convert.ToInt32(employee.AssignedWareHouse));
					Vehicle vehicle = vehicles.FirstOrDefault(v => v.VehicleId == Convert.ToInt32(employee.VehicleNumber));

					employee.AssignedWareHouse = assignedWareHouse != null ? assignedWareHouse.WareHouseName : null;
					employee.VehicleNumber = vehicle != null ? vehicle.VehicleNumber : null;
				}

				return employees;

			}
			catch
			{
				throw;
			}
		}

		public MessageEnum EmployeeDelete(Int64 employeeId, Int64 DeletedBy)
		{
			try
			{			
				var employee = _dbContext.Employees.Where(em => em.EmployeeId == employeeId && em.Deleted == false).FirstOrDefault();

				employee.Deleted = true;
				employee.UpdatedBy = DeletedBy;
				employee.UpdatedDate = DateTime.Now;

				_dbContext.SaveChanges();
				return MessageEnum.Deleted;
			}
			catch
			{
				throw;
			}
		}
	}
}
