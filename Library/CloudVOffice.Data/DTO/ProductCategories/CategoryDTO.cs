using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.ProductCategories
{
    public class CategoryDTO
    {
        public int? CategoryId { get; set; }
        public int SectorId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        //public string? IconPicture { get; set; }
        //public int? Parent { get; set; }
        //public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public IFormFile? CategoryImageUp { get; set; }
        //public IFormFile? IconPictureUp { get; set; }
        //public List<CategoryDTO> CategoryDTOs { get; set; }
    }
    //public class ViewCategoryDTO
    //{
    //    public int CategoryId { get; set; }
    //    public int SectorId { get; set; }
    //    public string CategoryName { get; set; }
    //    public string IconPicture { get; set; }
    //    public int? Parent { get; set; }
    //    public string? ParentName { get; set; }
    //    public bool IsActive { get; set; }
    //    public Int64 CreatedBy { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public Int64? UpdatedBy { get; set; }
    //    public DateTime? UpdatedDate { get; set; }
    //    public bool Deleted { get; set; }
    //}
}
