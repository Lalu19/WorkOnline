using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public interface ISubCategory3Service
    {
        public MessageEnum SubCategory3Create(SubCategory3DTO subCategory3DTO);
        public MessageEnum SubCategory3Update(SubCategory3DTO subCategory3DTO);
        public MessageEnum DeleteSubCategory3(int SubCategory3Id, Int64 DeletedBy);
        public List<SubCategory3> GetSubCategory3List();
        public SubCategory3 GetSubCategory3ById(int SubCategory3Id);
        public List<SubCategory3> GetSubCategory3BySubCategory2Id(int SubCategory2Id);
    }
}
