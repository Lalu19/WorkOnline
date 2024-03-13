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
    public class SalesExecutiveTargetService : ISalesExecutiveTargetService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesExecutiveTarget> _salesExecutiveTarget;
        public SalesExecutiveTargetService(ApplicationDBContext dbContext, ISqlRepository<SalesExecutiveTarget> salesExecutiveTarget)
        {
            _dbContext = dbContext;
            _salesExecutiveTarget = salesExecutiveTarget;
        }

        public MessageEnum CreateTargetsBySalesExecutive(SalesExecutiveTargetDTO salesExecutiveTargetDTO)
        {
            try
            {
                if (salesExecutiveTargetDTO != null)
                {
                    var objcheck = _dbContext.SalesExecutiveTargets
                        .FirstOrDefault(s => s.SalesExecutiveTargetId == salesExecutiveTargetDTO.SalesExecutiveTargetId && s.Deleted == false);

                    if (objcheck == null)
                    {
                        SalesExecutiveTarget target = new SalesExecutiveTarget
                        {
                            SalesExecutiveRegistrationId = salesExecutiveTargetDTO.SalesExecutiveRegistrationId,
                            MonthId = salesExecutiveTargetDTO.MonthId,
                            SectorId = Convert.ToInt64(salesExecutiveTargetDTO.Sector),
                            CategoryId = Convert.ToInt64(salesExecutiveTargetDTO.Category),
                            MonthlyCategoryWiseTarget = salesExecutiveTargetDTO.MonthlyCategoryWiseTarget,
                            CreatedBy = salesExecutiveTargetDTO.CreatedBy,
                            // Set other properties for new targets
                        };

                        _salesExecutiveTarget.Insert(target);
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
        public MessageEnum UpdateTargetsBySalesExecutive(SalesExecutiveTargetDTO salesExecutiveTargetDTO)
        {
            try
            {
                // Check if there is another target with the same name and a different ID
                var targetWithSameName = _dbContext.SalesExecutiveTargets
                    .FirstOrDefault(s => s.SalesExecutiveTargetId != salesExecutiveTargetDTO.SalesExecutiveTargetId);

                if (targetWithSameName == null)
                {
                    // Target with the specified ID
                    var targetToUpdate = _dbContext.SalesExecutiveTargets
                        .FirstOrDefault(s => s.SalesExecutiveTargetId == salesExecutiveTargetDTO.SalesExecutiveTargetId);

                    if (targetToUpdate != null)
                    {
                        // Update properties of the existing target
                        targetToUpdate.SalesExecutiveRegistrationId = salesExecutiveTargetDTO.SalesExecutiveRegistrationId;
                        targetToUpdate.MonthId = salesExecutiveTargetDTO.MonthId;
                        targetToUpdate.SectorId = Convert.ToInt64(salesExecutiveTargetDTO.Sector);
                        targetToUpdate.CategoryId = Convert.ToInt64(salesExecutiveTargetDTO.Category);
                        targetToUpdate.MonthlyCategoryWiseTarget = salesExecutiveTargetDTO.MonthlyCategoryWiseTarget;
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

        public List<SalesExecutiveTarget> GetAllTargetsBySalesExecutive()
        {
            var a = _dbContext.SalesExecutiveTargets
             //.Include(s => s.Month)
             .Where(x => x.Deleted == false).ToList();

            return a;
        }

        public SalesExecutiveTarget GetSalesExecutiveTargetBySalesExecutiveId(Int64 salesExecutiveId)
        {
            return _dbContext.SalesExecutiveTargets.Where(s => s.SalesExecutiveTargetId == salesExecutiveId).FirstOrDefault();
        }
        public MessageEnum DeleteTargetsBySalesExecutive(Int64 targetId, Int64 DeletedBy)
        {
            try
            {
                var target = _dbContext.SalesExecutiveTargets.Where(x => x.SalesExecutiveTargetId == targetId).FirstOrDefault();
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
