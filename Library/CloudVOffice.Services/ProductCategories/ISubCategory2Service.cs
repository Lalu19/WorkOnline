using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
	public interface ISubCategory2Service
	{
		public MessageEnum SubCategory2Create(SubCategory2DTO subCategory2DTO);
		public MessageEnum SubCategory2Update(SubCategory2DTO subCategory2DTO);
		public MessageEnum DeleteSubCategory2(int SubCategory2Id, Int64 DeletedBy);
		public List<SubCategory2> GetSubCategory2List();
		public SubCategory2 GetSubCategory2ById(int SubCategory2Id);
		public List<SubCategory2> GetSubCategory2BySubCategory1Id(int SubCategory1Id);
	}
}
