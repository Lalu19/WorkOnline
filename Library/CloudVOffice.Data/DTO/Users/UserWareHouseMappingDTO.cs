using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Users
{
    public class UserWareHouseMappingDTO
    {
        public int? UserWareHouseMappingId { get; set; }
        public Int64 WareHuoseId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
