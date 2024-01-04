using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public class SubCategory3Service: ISubCategory3Service
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SubCategory3> _SubCategory3Repo;
        public SubCategory3Service(ApplicationDBContext dbContext, ISqlRepository<SubCategory3> SubCategory3Repo)
        {
            _dbContext = dbContext;
            _SubCategory3Repo = SubCategory3Repo;
        }
        public MessageEnum SubCategory3Create(SubCategory3DTO subCategory3DTO)
        {
            try
            {
                var objcheck = _dbContext.SubCategories3.SingleOrDefault(opt => opt.Deleted == false && opt.SubCategory3Name == subCategory3DTO.SubCategory3Name);
                if (objcheck == null)
                {
                    SubCategory3 ct = new SubCategory3();
                    ct.SectorId = subCategory3DTO.SectorId;
                    ct.CategoryId = subCategory3DTO.CategoryId;
                    ct.SubCategory1Id = subCategory3DTO.SubCategory1Id;
                    ct.SubCategory2Id = subCategory3DTO.SubCategory2Id;
                    ct.SubCategory3Name = subCategory3DTO.SubCategory3Name;

                    ct.CreatedBy = subCategory3DTO.CreatedBy;
                    ct.CreatedDate = System.DateTime.Now;
                    var obj = _SubCategory3Repo.Insert(ct);
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
        public List<SubCategory3> GetSubCategory3List()
        {
            try
            {
                return _dbContext.SubCategories3.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        public SubCategory3 GetSubCategory3ById(int SubCategory3Id)
        {
            return _dbContext.SubCategories3.Where(x => x.SubCategory3Id == SubCategory3Id && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum SubCategory3Update(SubCategory3DTO subCategory3DTO)
        {
            try
            {
                var updateSubCategory3 = _dbContext.SubCategories3.Where(x => x.SubCategory3Id != subCategory3DTO.SubCategory3Id && x.SubCategory3Name == subCategory3DTO.SubCategory3Name && x.Deleted == false).FirstOrDefault();
                if (updateSubCategory3 == null)
                {
                    var a = _dbContext.SubCategories3.Where(x => x.SubCategory3Id == subCategory3DTO.SubCategory3Id).FirstOrDefault();
                    if (a != null)
                    {
                        a.SectorId = subCategory3DTO.SectorId;
                        a.CategoryId = subCategory3DTO.CategoryId;
                        a.SubCategory1Id = subCategory3DTO.SubCategory1Id;
                        a.SubCategory2Id = subCategory3DTO.SubCategory2Id;
                        a.SubCategory3Name = subCategory3DTO.SubCategory3Name;
                        a.UpdatedBy = subCategory3DTO.CreatedBy;
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
        public MessageEnum DeleteSubCategory3(int SubCategory3Id, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SubCategories3.Where(x => x.SubCategory3Id == SubCategory3Id).FirstOrDefault();
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
        public List<SubCategory3> GetSubCategory3BySubCategory2Id(int SubCategory2Id)
        {
            return _dbContext.SubCategories3.Where(x => x.SubCategory2Id == SubCategory2Id && x.Deleted == false).ToList();
        }
    }
}
