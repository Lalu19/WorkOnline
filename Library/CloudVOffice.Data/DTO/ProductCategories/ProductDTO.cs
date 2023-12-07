using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.ProductCategories
{
    public class ProductDTO
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ParentGroupId { get; set; }
        public string? Image { get; set; }
        public int CreatedBy { get; set; }
        public IFormFile? ImageUpload { get; set; }
    }
}
