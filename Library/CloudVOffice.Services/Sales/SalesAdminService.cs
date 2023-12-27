using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using LinqToDB;
using LinqToDB.Tools;

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

		public MessageEnum CreateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO)
		{
			try
			{
				var objcheck = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminDTO.SalesAdminTargetId && s.Deleted == false).FirstOrDefault();

				if (objcheck == null)
                {
					SalesAdminTarget target = new SalesAdminTarget();

					target.SalesAdminTargetName = salesAdminDTO.SalesAdminTargetName;
					target.Month = salesAdminDTO.Month;
					target.SectorId = salesAdminDTO.SectorId;
					target.CategoryId = salesAdminDTO.CategoryId;
					target.MonthlyCategoryWiseTarget = salesAdminDTO.MonthlyCategoryWiseTarget;
					target.MonthlySectorWiseTarget = salesAdminDTO.MonthlySectorWiseTarget;
					target.MonthlyBrandWiseTarget = salesAdminDTO.MonthlyBrandWiseTarget;
					target.UnitId = salesAdminDTO.UnitId;
					//target.Districts = salesAdminDTO.Districts;
					target.CreatedBy = salesAdminDTO.CreatedBy;

                    var obj = _salesAdmin.Insert(target);
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

        public SalesAdminTarget GetSalesAdminTargetBySalesAdminId(Int64 salesAdminId)
        {
            return _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminId).FirstOrDefault();
		}

		public List<SalesAdminTarget> GetAllTargetsBySalesAdmin()
		{
            return _dbContext.SalesAdminTargets.Where(s => s.Deleted == false).ToList();
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

        public MessageEnum UpdateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO)
        {
            try
            {
                var target1 = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId != salesAdminDTO.SalesAdminTargetId && s.SalesAdminTargetName == salesAdminDTO.SalesAdminTargetName).FirstOrDefault();

                if (target1 == null)
                {
                    var target = _dbContext.SalesAdminTargets.Where(s => s.SalesAdminTargetId == salesAdminDTO.SalesAdminTargetId).FirstOrDefault();

                    if(target != null)
                    {
						target.SalesAdminTargetName = salesAdminDTO.SalesAdminTargetName;
						target.Month = salesAdminDTO.Month;
						target.SectorId = salesAdminDTO.SectorId;
						target.CategoryId = salesAdminDTO.CategoryId;
						target.MonthlyCategoryWiseTarget = salesAdminDTO.MonthlyCategoryWiseTarget;
						target.MonthlySectorWiseTarget = salesAdminDTO.MonthlySectorWiseTarget;
						target.MonthlyBrandWiseTarget = salesAdminDTO.MonthlyBrandWiseTarget;
						target.UnitId = salesAdminDTO.UnitId;
						//target.Districts = salesAdminDTO.Districts;

                        _salesAdmin.Update(target);
                        _dbContext.SaveChanges();

                        return MessageEnum.Success;

					}
                    else
                    {
						return MessageEnum.Invalid;
					}
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
