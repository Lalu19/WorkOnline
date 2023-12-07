using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudVOffice.Core.Domain.ProductCategories
{
    public class Product : IAuditEntity, ISoftDeletedEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ParentGroupId { get; set; }
        public string? Image { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public Product Parent { get; set; }
        public ICollection<Product> Subordinates { get; set; } = new List<Product>();
    }
}
