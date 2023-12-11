using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Category> _CategoryRepo;
        public CategoryService(ApplicationDBContext dbContext, ISqlRepository<Category> CategoryRepo)
        {
            _dbContext = dbContext;
            _CategoryRepo = CategoryRepo;
        }
        public MessageEnum CategoryCreate(CategoryDTO categoryDTO)
        {
            try
            {
                var objcheck = _dbContext.Categories.SingleOrDefault(opt => opt.Deleted == false && opt.CategoryName == categoryDTO.CategoryName);
                if (objcheck == null)
                {
                    Category ct = new Category();
                    ct.SectorId = categoryDTO.SectorId;
                    ct.CategoryName = categoryDTO.CategoryName;
                  
                    ct.CreatedBy = categoryDTO.CreatedBy;
                    ct.CreatedDate = System.DateTime.Now;
                    var obj = _CategoryRepo.Insert(ct);
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
        public List<Category> GetCategoryList()
        {
            try
            {
                return _dbContext.Categories.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        public Category GetCategoryById(int CategoryId)
        {
            return _dbContext.Categories.Where(x => x.CategoryId == CategoryId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum CategoryUpdate(CategoryDTO categoryDTO)
        {
            try
            {
                var updateCategory = _dbContext.Categories.Where(x => x.CategoryId != categoryDTO.CategoryId && x.CategoryName == categoryDTO.CategoryName && x.Deleted == false).FirstOrDefault();
                if (updateCategory == null)
                {
                    var a = _dbContext.Categories.Where(x => x.CategoryId == categoryDTO.CategoryId).FirstOrDefault();
                    if (a != null)
                    {
                        a.SectorId = categoryDTO.SectorId;
                        a.CategoryName = categoryDTO.CategoryName;
                        a.UpdatedBy = categoryDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;

                        //if (categoryDTO.IconPicture != "")
                        //{
                        //    a.IconPicture = categoryDTO.IconPicture;
                        //}

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
        public MessageEnum DeleteCategory(int CategoryId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
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

        public List<Category> GetCategoryBySectorId(int SectorId)
        {
            return _dbContext.Categories.Where(x => x.SectorId == SectorId && x.Deleted == false).ToList();
        }
    }
}
