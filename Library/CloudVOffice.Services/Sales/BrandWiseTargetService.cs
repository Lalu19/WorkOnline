using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
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
    public class BrandWiseTargetService : IBrandWiseTargetService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<BrandWiseTarget> _brandWiseTargetRepo;
        public BrandWiseTargetService(ApplicationDBContext dbContext,
                                      ISqlRepository<BrandWiseTarget> brandWiseTargetRepo
                                      )
        {
            _dbContext = dbContext;
            _brandWiseTargetRepo = brandWiseTargetRepo;
        }
        public MessageEnum BrandWiseTargetCreate(BrandWiseTargetsDTO brandWiseTargetDTO)
        {
            try
            {
                if (brandWiseTargetDTO != null)
                {
                    var objcheck = _dbContext.BrandWiseTargets
                        .FirstOrDefault(s => s.BrandWiseTargetId == brandWiseTargetDTO.BrandWiseTargetId && s.Deleted == false);

                    if (objcheck == null)
                    {
                        BrandWiseTarget target = new BrandWiseTarget
                        {
                            SectorId = brandWiseTargetDTO.SectorId,
                            CategoryId = brandWiseTargetDTO.CategoryId,
                            BrandId = brandWiseTargetDTO.BrandId,
                            MonthId = brandWiseTargetDTO.MonthId,
                            //UnitId=brandWiseTargetDTO.UnitId,
                            MonthlyBrandWiseTarget = brandWiseTargetDTO.MonthlyBrandWiseTarget,
                            CreatedBy = brandWiseTargetDTO.CreatedBy,
                        };

                        _brandWiseTargetRepo.Insert(target);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        return MessageEnum.Duplicate; 
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
                throw; 
            }
        }

        public MessageEnum BrandWiseTargetUpdate(BrandWiseTargetsDTO brandWiseTargetDTO)
        {
            try
            {
                var targetWithSameName = _dbContext.BrandWiseTargets
                    .FirstOrDefault(s => s.BrandWiseTargetId != brandWiseTargetDTO.BrandWiseTargetId);

                if (targetWithSameName == null)
                {
                    var targetToUpdate = _dbContext.BrandWiseTargets
                        .FirstOrDefault(s => s.BrandWiseTargetId == brandWiseTargetDTO.BrandWiseTargetId);

                    if (targetToUpdate != null)
                    {
                        targetToUpdate.SectorId = brandWiseTargetDTO.SectorId;
                        targetToUpdate.CategoryId = brandWiseTargetDTO.CategoryId;
                        targetToUpdate.BrandId = brandWiseTargetDTO.BrandId;
                        targetToUpdate.MonthId = brandWiseTargetDTO.MonthId;
                        //targetToUpdate.UnitId=brandWiseTargetDTO.UnitId;
                        targetToUpdate.MonthlyBrandWiseTarget = brandWiseTargetDTO.MonthlyBrandWiseTarget;

                        _dbContext.SaveChanges();

                        return MessageEnum.Updated;
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

        public BrandWiseTarget GetBrandWiseTargetById(Int64 brandWiseTargetId)
        {
            return _dbContext.BrandWiseTargets.Where(s => s.BrandWiseTargetId == brandWiseTargetId).FirstOrDefault();
        }

        public List<BrandWiseTarget> GetBrandWiseTargetList()
        {
            var a = _dbContext.BrandWiseTargets
           .Include(s => s.Month)
           .Include(s =>s.Sector)
           .Include(s =>s.Category)
           .Include(s =>s.Unit)
           .Include(s =>s.Brand)
           .Where(x => x.Deleted == false).ToList();

            return a;
        }
        public MessageEnum BrandWiseTargetDelete(Int64 brandWiseTargetId, Int64 DeletedBy)
        {
            try
            {
                var target = _dbContext.BrandWiseTargets.Where(x => x.BrandWiseTargetId == brandWiseTargetId).FirstOrDefault();
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
    }
}
