using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.ViewModel
{
    public class CategoryDisplay
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? IconPicture { get; set; }
        public int? Parent { get; set; }
        public bool IsActive { get; set; }
       
        public string ParentName { get; set; }
    }
}
