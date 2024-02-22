using CloudVOffice.Core.Domain.WareHouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Users
{
    public class UserWareHouseMapping : IAuditEntity, ISoftDeletedEntity
    {
        public int UserWareHouseMappingId { get; set; }
        public Int64 WareHuoseId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        [ForeignKey("WareHuoseId")]
        public WareHuose WareHuose { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
