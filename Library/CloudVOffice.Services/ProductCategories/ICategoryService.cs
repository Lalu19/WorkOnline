using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public interface ICategoryService
    {
        public MessageEnum CategoryCreate(CategoryDTO categoryDTO);
        public MessageEnum CategoryUpdate(CategoryDTO categoryDTO);
        public MessageEnum DeleteCategory(int CategoryId, Int64 DeletedBy);
        public List<Category> GetCategoryList();
        public Category GetCategoryById(int CategoryId);
       
    }
}
