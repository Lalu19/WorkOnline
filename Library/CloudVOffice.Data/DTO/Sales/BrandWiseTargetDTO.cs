using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sales
{
    public class BrandWiseTargetDTO
    {
        public Int64? BrandWiseTargetId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public Int64? BrandId { get; set; }
        public Int64? MonthId { get; set; }
        public Int64? UnitId { get; set; }
        public double? MonthlyBrandWiseTarget { get; set; }
        public Int64 CreatedBy { get; set; }
    }

    public class BrandWiseTargetsDTO
    {
        public Int64? BrandWiseTargetId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? MonthId { get; set; }
        //public Int64? UnitId { get; set; }
        public double? MonthlyBrandWiseTarget { get; set; }
        public Int64 CreatedBy { get; set; }
    }

    public class BrandWiseTargetMasterDTO
    {
        public List<BrandWiseTargetsDTO> Targetss { get; set; }
    }
}
