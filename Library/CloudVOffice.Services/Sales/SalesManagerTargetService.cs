using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sales
{
    public class SalesManagerTargetService: ISalesManagerTargetService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesManagerTarget> _salesManagerTarget;
        public SalesManagerTargetService(ApplicationDBContext dbContext, ISqlRepository<SalesManagerTarget> salesManagerTarget)
        {
            _dbContext = dbContext;
            _salesManagerTarget = salesManagerTarget;
        }
        public MessageEnum CreateSalesManagerTarget(SalesManagerTargetDTO salesManagerTargetDTO)
        {
            try
            {
                if (salesManagerTargetDTO != null)
                {
                    var objcheck = _dbContext.SalesManagerTargets
                        .FirstOrDefault(s => s.SalesManagerTargetId == salesManagerTargetDTO.SalesManagerTargetId && s.Deleted == false);

                    if (objcheck == null)
                    {
                        SalesManagerTarget target = new SalesManagerTarget
                        {
                            MonthId = salesManagerTargetDTO.MonthId,
                            SectorId =(int?) Convert.ToInt64(salesManagerTargetDTO.SectorId),
                            CategoryId =(int?) Convert.ToInt64(salesManagerTargetDTO.CategoryId),
                            MonthlyCategoryWiseTarget = salesManagerTargetDTO.MonthlyCategoryWiseTarget,
                            CreatedBy = salesManagerTargetDTO.CreatedBy,
                            // Set other properties for new targets
                        };

                        _salesManagerTarget.Insert(target);
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

        SalesManagerTarget GetSalesManagerTargetBySalesManagerTargetId(Int64 salesManagerTargetId)
        {
            return _dbContext.SalesManagerTargets.Where(s => s.SalesManagerTargetId == salesManagerTargetId).FirstOrDefault();
        }

        public List<SalesManagerTarget> GetAllTargetsBySalesManagerTarget()
        {
            var a = _dbContext.SalesManagerTargets
            .Include(s => s.Month)
            .Where(x => x.Deleted == false).ToList();

            return a;

        }

        public List<SalesManagerTarget> GetTargetsByCategoryIdBySalesManagerTarget(Int64 categoryId)
        {
            throw new NotImplementedException();
        }

        public List<SalesManagerTarget> GetTargetsBySectorIdBySalesManagerTarget(Int64 sectorId)
        {
            throw new NotImplementedException();
        }

        public List<SalesManagerTarget> GetTargetsByMonthBySalesManagerTarget(Int64 monthId)
        {
            throw new NotImplementedException();
        }

        public MessageEnum DeleteTargetsBySalesManagerTarget(Int64 salesManagerTargetId, Int64 DeletedBy)
        {
            try
            {
                var target = _dbContext.SalesManagerTargets.Where(x => x.SalesManagerTargetId == salesManagerTargetId).FirstOrDefault();
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

        public MessageEnum UpdateTargetsBySalesManagerTarget(SalesManagerTargetDTO salesManagerTargetDTO)
        {
            try
            {
                // Check if there is another target with the same name and a different ID
                var targetWithSameName = _dbContext.SalesManagerTargets
                    .FirstOrDefault(s => s.SalesManagerTargetId != salesManagerTargetDTO.SalesManagerTargetId);

                if (targetWithSameName == null)
                {
                    // Target with the specified ID
                    var targetToUpdate = _dbContext.SalesManagerTargets
                        .FirstOrDefault(s => s.SalesManagerTargetId == salesManagerTargetDTO.SalesManagerTargetId);

                    if (targetToUpdate != null)
                    {
                        // Update properties of the existing target
                        targetToUpdate.MonthId = salesManagerTargetDTO.MonthId;
                        targetToUpdate.SectorId =(int?) Convert.ToInt64(salesManagerTargetDTO.SectorId);
                        targetToUpdate.CategoryId =(int?) Convert.ToInt64(salesManagerTargetDTO.CategoryId);
                        targetToUpdate.MonthlyCategoryWiseTarget = salesManagerTargetDTO.MonthlyCategoryWiseTarget;
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

        SalesManagerTarget ISalesManagerTargetService.GetSalesManagerTargetBySalesManagerTargetId(long salesManagerTargetId)
        {
            throw new NotImplementedException();
        }

        public MessageEnum CreateSalesManagerTarget(object target)
        {
            throw new NotImplementedException();
        }

        public MessageEnum UpdateTargetsBySalesManagerTarget(object target)
        {
            throw new NotImplementedException();
        }
    }
}
