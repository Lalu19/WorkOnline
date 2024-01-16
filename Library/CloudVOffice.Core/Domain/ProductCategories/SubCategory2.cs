﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.ProductCategories
{
	public class SubCategory2 : IAuditEntity, ISoftDeletedEntity
    {
		public int SubCategory2Id { get; set; }
		public int SectorId { get; set; }
		public int CategoryId { get; set; }
		public int SubCategory1Id { get; set; }
		public string SubCategory2Name { get; set; }
        public string SubCategory2Image { get; set; }
        public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
