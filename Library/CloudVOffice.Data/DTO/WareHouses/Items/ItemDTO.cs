using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CloudVOffice.Data.DTO.WareHouses.Items
{
    public class ItemDTO
    {
        public Int64? ItemId { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public double UnitOfMeasurement { get; set; }
        public int? CaseWeight { get; set; }
        public int? UnitPerCase { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Barcode { get; set; }
		public bool BarCodeNotAvailable { get; set; }
		public double MRP { get; set; }
        public double PurchaseCost { get; set; }
        public double SalesCost { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public string HandlingType { get; set; }
        //public string? Images { get; set; }
        //public IFormFile? ImagesUp { get; set; }

        public string? Thumbnail { get; set; }
        public IFormFile? ThumbnailUp { get; set; }
        public List<string> Images { get; set; } = new List<string>();
		public List<IFormFile>? ImagesUp { get; set; }
        public string? Videos { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
