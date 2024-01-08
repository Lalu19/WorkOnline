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
	public interface ISubCategory4Service
	{
		public MessageEnum SubCategory4Create(SubCategory4DTO subCategory4DTO);
		public MessageEnum SubCategory4Update(SubCategory4DTO subCategory4DTO);
		public MessageEnum DeleteSubCategory4(int SubCategory4Id, Int64 DeletedBy);
		public List<SubCategory4> GetSubCategory4List();
		public SubCategory4 GetSubCategory4ById(int SubCategory4Id);
		public List<SubCategory4> GetSubCategory4BySubCategory3Id(int SubCategory3Id);
	}
}
