using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sales
{
	public class SalesManagerService : ISalesManagerService
    {
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SalesManager> _salesManagerRepo;

		public SalesManagerService(ApplicationDBContext dbContext,
								   ISqlRepository<SalesManager> salesManagerRepo

									)
		{
			_dbContext = dbContext;
			_salesManagerRepo = salesManagerRepo;

		}
		public MessageEnum SalesManagerCreate(SalesManagerDTO salesManagerDTO)
		{
			try
			{
				var objcheck = _dbContext.SalesManagers.SingleOrDefault(opt => opt.Deleted == false && opt.SalesManagerName == salesManagerDTO.SalesManagerName);
				if (objcheck == null)
				{
					SalesManager sc = new SalesManager();
					sc.SalesManagerName = salesManagerDTO.SalesManagerName;
					sc.StateId = salesManagerDTO.StateId;
					sc.Telephone = salesManagerDTO.Telephone;
					sc.Address=salesManagerDTO.Address;
					sc.EmailId = salesManagerDTO.EmailId;
					sc.CreatedBy = salesManagerDTO.CreatedBy;
					sc.CreatedDate = System.DateTime.Now;
					var obj = _salesManagerRepo.Insert(sc);
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
		public List<SalesManager> GetSalesManagerList()
		{
			try
			{
				return _dbContext.SalesManagers.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum SalesManagerUpdate(SalesManagerDTO salesManagerDTO)
		{
			try
			{
				var updateSalesManager = _dbContext.SalesManagers.Where(x => x.SalesManagerId != salesManagerDTO.SalesManagerId && x.SalesManagerName == salesManagerDTO.SalesManagerName && x.Deleted == false).FirstOrDefault();
				if (updateSalesManager == null)
				{
					var a = _dbContext.SalesManagers.Where(x => x.SalesManagerId == salesManagerDTO.SalesManagerId).FirstOrDefault();
					if (a != null)
					{
						a.SalesManagerName = salesManagerDTO.SalesManagerName;
						a.StateId = salesManagerDTO.StateId;
						a.Telephone = salesManagerDTO.Telephone;
						a.Address = salesManagerDTO.Address;
						a.EmailId = salesManagerDTO.EmailId;
						a.UpdatedBy = salesManagerDTO.CreatedBy;
						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
						return MessageEnum.Updated;
					}
					else
						return MessageEnum.Invalid;
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
		public SalesManager GetSalesManagerById(Int64 SalesManagerId)
		{
			return _dbContext.SalesManagers.Where(x => x.SalesManagerId ==SalesManagerId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum SalesManagerDelete(Int64 SalesManagerId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.SalesManagers.Where(x => x.SalesManagerId == SalesManagerId).FirstOrDefault();

				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Deleted;
				}
				else
					return MessageEnum.Invalid;
			}
			catch
			{
				throw;
			}
		}

		public Int64 GetSalesManagerIdByName(string Name)
		{
			var a = _dbContext.SalesManagers.FirstOrDefault(mon => mon.SalesManagerName == Name);
			return a.SalesManagerId;
		}
	}
}
