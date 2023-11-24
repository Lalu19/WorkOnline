using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace CloudVOffice.Core.Domain.WareHouses
{
    public class WareHuose:  IAuditEntity, ISoftDeletedEntity
    {

        public Int64 WareHuoseId { get; set; }
        public string GSTNumber { get; set; }
        public string? WareHouseName { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
