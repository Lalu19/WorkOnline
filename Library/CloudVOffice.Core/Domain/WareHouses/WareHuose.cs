using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CloudVOffice.Core.Domain.WareHouses
{
    public class WareHuose:  IAuditEntity, ISoftDeletedEntity
    {

        public Int64 WareHuoseId { get; set; }
        public String WarehouseName { get; set; }
        public Int64 PinCodeId { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
