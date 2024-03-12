using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sales
{
    public class SalesManagerTargetDTO
    {
        public Int64? SalesManagerTargetId { get; set; }
        public Int64? UserId { get; set; }
        public Int64? StateId { get; set; }
        public Int64? MonthId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public Int64? UnitId { get; set; }
        public Int64? BrandId { get; set; }
        public double? MonthlyCategoryWiseTarget { get; set; }
        public double? MonthlySectorWiseTargetByAdmin { get; set; }
        public double? MonthlyBrandWiseTarget { get; set; }
        public Int64 CreatedBy { get; set; }
    }

    public class SalesManagerrTargetDTO
    {
        
        public Int64? SalesManagerTargetId { get; set; }
        public Int64? UserId { get; set; }
        public string? Sector { get; set; }
        public string? Category { get; set; }
        public Int64 MonthId { get; set; }
        //public string? Month { get; set; }
        public double? MonthlyCategoryWiseTarget { get; set; }
        public Int64 CreatedBy { get; set; }
        
    }
    public class SalesManagerTargetMasterDTO
    {
        public List<SalesManagerrTargetDTO> Targets { get; set; }
    }
}
