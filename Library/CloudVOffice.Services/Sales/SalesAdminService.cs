using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using LinqToDB;
using LinqToDB.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.Sales
{
    public class SalesAdminService : ISalesAdminService
    {

		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SalesAdminTarget> _salesAdmin;
		public SalesAdminService(ApplicationDBContext dbContext, ISqlRepository<SalesAdminTarget> salesAdmin)
		{
			_dbContext = dbContext;
			_salesAdmin = salesAdmin;
		}

		//public MessageEnum CreateTargetsBySalesAdmin(SalesAdminTargetMasterDTO salesAdminTargetMasterDTO)
		//{
		//	try
		//	{
		//		//var objcheck = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminDTO.SalesAdminTargetId && s.Deleted == false).FirstOrDefault();
		//		var objcheck = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminTargetMasterDTO.Targets. && s.Deleted == false).FirstOrDefault();

		//		if (objcheck == null)
		//              {
		//			SalesAdminTarget target = new SalesAdminTarget();

		//			target.SalesAdminTargetName = salesAdminDTO.SalesAdminTargetName;
		//			target.MonthId = salesAdminDTO.MonthId;
		//			target.SectorId = salesAdminDTO.SectorId;
		//			target.CategoryId = salesAdminDTO.CategoryId;
		//			target.MonthlyCategoryWiseTarget = salesAdminDTO.MonthlyCategoryWiseTarget;
		//			target.MonthlySectorWiseTarget = salesAdminDTO.MonthlySectorWiseTarget;
		//			target.MonthlyBrandWiseTarget = salesAdminDTO.MonthlyBrandWiseTarget;
		//			target.UnitId = salesAdminDTO.UnitId;
		//			//target.Districts = salesAdminDTO.Districts;
		//			target.CreatedBy = salesAdminDTO.CreatedBy;

		//                  var obj = _salesAdmin.Insert(target);
		//                  _dbContext.SaveChanges();

		//                  return MessageEnum.Success;
		//		}
		//              else
		//              {
		//                  return MessageEnum.Duplicate;
		//              }
		//          }
		//          catch
		//          {
		//              throw;
		//          }
		//}



		//public MessageEnum CreateTargetsBySalesAdmin(SalesAdminTargetMasterDTO salesAdminTargetMasterDTO)
		//{
		//	try
		//	{
		//		if (salesAdminTargetMasterDTO != null && salesAdminTargetMasterDTO.Targets != null)
		//		{
		//			foreach (var salesAdminDTO in salesAdminTargetMasterDTO.Targets)
		//			{
		//				var objcheck = _dbContext.SalesAdminTargets
		//					.FirstOrDefault(s => s.SalesAdminTargetId == salesAdminDTO.SalesAdminTargetId && s.Deleted == false);

		//				if (objcheck == null)
		//				{
		//					SalesAdminTarget target = new SalesAdminTarget
		//					{
		//						//SalesAdminTargetName = salesAdminDTO.SalesAdminTargetName,
		//						MonthId = salesAdminDTO.MonthId,
		//						SectorId = Convert.ToInt64(salesAdminDTO.Sector),
		//						CategoryId = Convert.ToInt64(salesAdminDTO.Category),
		//						MonthlyCategoryWiseTarget = salesAdminDTO.MonthlyCategoryWiseTarget,
		//						//MonthlySectorWiseTarget = salesAdminDTO.MonthlySectorWiseTarget,
		//						//MonthlyBrandWiseTarget = salesAdminDTO.MonthlyBrandWiseTarget,

		//						CreatedBy = salesAdminDTO.CreatedBy,
		//					};
		//					_salesAdmin.Insert(target);
		//				}
		//				else
		//				{
		//					return MessageEnum.Duplicate; // or handle duplicates as needed
		//				}
		//			}

		//			_dbContext.SaveChanges();

		//			return MessageEnum.Success;
		//		}
		//		else
		//		{
		//			return MessageEnum.Invalid;
		//		}
		//	}
		//	catch
		//	{
		//		throw; // Handle the exception appropriately
		//	}
		//}


		public MessageEnum CreateTargetsBySalesAdmin(SalesAdminTargetDTO salesAdminTargetDTO)
		{
			try
			{
				if (salesAdminTargetDTO != null)
				{
					var objcheck = _dbContext.SalesAdminTargets
						.FirstOrDefault(s => s.SalesAdminTargetId == salesAdminTargetDTO.SalesAdminTargetId && s.Deleted == false);

					if (objcheck == null)
					{
						SalesAdminTarget target = new SalesAdminTarget
						{
							MonthId = salesAdminTargetDTO.MonthId,
							SectorId = Convert.ToInt64(salesAdminTargetDTO.Sector),
							CategoryId = Convert.ToInt64(salesAdminTargetDTO.Category),
							MonthlyCategoryWiseTarget = salesAdminTargetDTO.MonthlyCategoryWiseTarget,
							CreatedBy = salesAdminTargetDTO.CreatedBy,
							// Set other properties for new targets
						};

						_salesAdmin.Insert(target);
						_dbContext.SaveChanges(); // Save changes for each new target
					}
					else
					{
						return MessageEnum.Duplicate; // or handle duplicates as needed
					}

					return MessageEnum.Success;
				}
				else
				{
					return MessageEnum.Invalid;
				}
			}
			catch
			{
				throw; // Handle the exception appropriately
			}
		}




		public SalesAdminTarget GetSalesAdminTargetBySalesAdminId(Int64 salesAdminId)
        {
            return _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminId).FirstOrDefault();
		}

		//public List<SalesAdminTarget> GetAllTargetsBySalesAdmin()
		//{
  //          return _dbContext.SalesAdminTargets.Where(s => s.Deleted == false).ToList();
		//}
        public List<SalesAdminTarget> GetAllTargetsBySalesAdmin()
        {
            var a = _dbContext.SalesAdminTargets
            .Include(s => s.Month)			
            .Where(x => x.Deleted == false).ToList();

            return a;

        }
        public List<SalesAdminTarget> GetTargetsByCategoryIdBySalesAdmin(Int64 categoryId)
		{
			throw new NotImplementedException();
		}		

        public List<SalesAdminTarget> GetTargetsBySectorIdBySalesAdmin(Int64 sectorId)
        {
            throw new NotImplementedException();
        }

        public List<SalesAdminTarget> GetTargetsByMonthBySalesAdmin(Int64 monthId)
        {
            throw new NotImplementedException();
        }        

        public MessageEnum DeleteTargetsBySalesAdmin(Int64 targetId, Int64 DeletedBy)
        {
            try
            {
                var target = _dbContext.SalesAdminTargets.Where(x => x.SalesAdminTargetId == targetId).FirstOrDefault();
                if (target != null)
                {
                    target.Deleted = true;
                    target.UpdatedBy = DeletedBy;
                    target.UpdatedDate = DateTime.Now;
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

		//    public MessageEnum UpdateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO)
		//    {
		//        try
		//        {
		//            var target1 = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId != salesAdminDTO.SalesAdminTargetId && s.SalesAdminTargetName == salesAdminDTO.SalesAdminTargetName).FirstOrDefault();

		//            if (target1 == null)
		//            {
		//                var target = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminDTO.SalesAdminTargetId).FirstOrDefault();

		//                if(target != null)
		//                {
		//		target.SalesAdminTargetName = salesAdminDTO.SalesAdminTargetName;
		//		target.MonthId = salesAdminDTO.MonthId;
		//		target.SectorId = salesAdminDTO.SectorId;
		//		target.CategoryId = salesAdminDTO.CategoryId;
		//		target.MonthlyCategoryWiseTarget = salesAdminDTO.MonthlyCategoryWiseTarget;
		//		target.MonthlySectorWiseTarget = salesAdminDTO.MonthlySectorWiseTarget;
		//		target.MonthlyBrandWiseTarget = salesAdminDTO.MonthlyBrandWiseTarget;
		//		target.UnitId = salesAdminDTO.UnitId;
		//		//target.Districts = salesAdminDTO.Districts;

		//                    _salesAdmin.Update(target);
		//                    _dbContext.SaveChanges();

		//                    return MessageEnum.Success;

		//	}
		//                else
		//                {
		//		return MessageEnum.Invalid;
		//	}
		//            }
		//            else
		//            {
		//	return MessageEnum.Duplicate;
		//}
		//        }
		//        catch
		//        {
		//            throw;
		//        }
		//    }


		public MessageEnum UpdateTargetsBySalesAdmin(SalesAdminTargetDTO salesAdminTargetDTO)
		{
			try
			{
				// Check if there is another target with the same name and a different ID
				var targetWithSameName = _dbContext.SalesAdminTargets
					.FirstOrDefault(s => s.SalesAdminTargetId != salesAdminTargetDTO.SalesAdminTargetId);

				if (targetWithSameName == null)
				{
					// Target with the specified ID
					var targetToUpdate = _dbContext.SalesAdminTargets
						.FirstOrDefault(s => s.SalesAdminTargetId == salesAdminTargetDTO.SalesAdminTargetId);

					if (targetToUpdate != null)
					{
						// Update properties of the existing target
						targetToUpdate.MonthId = salesAdminTargetDTO.MonthId;
						targetToUpdate.SectorId = Convert.ToInt64(salesAdminTargetDTO.Sector);
						targetToUpdate.CategoryId = Convert.ToInt64(salesAdminTargetDTO.Category);
						targetToUpdate.MonthlyCategoryWiseTarget = salesAdminTargetDTO.MonthlyCategoryWiseTarget;
						// Update other properties for existing targets

						_dbContext.SaveChanges();

						return MessageEnum.Updated;
					}
					else
					{
						return MessageEnum.Invalid; // or handle not found as needed
					}
				}
				else
				{
					return MessageEnum.Duplicate; // or handle duplicate as needed
				}
			}
			catch
			{
				throw; // Handle the exception appropriately
			}
		}


		public string GetCategoryIdByName(string categoryName)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryName == categoryName);
            if (category != null)
            {
                return category.CategoryId.ToString();
            }
            else { return null; }
        }
    }
}
