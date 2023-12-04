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
	public interface ISubCategory1Service
	{
		public MessageEnum SubCategory1Create(SubCategory1DTO subCategory1DTO);
		public MessageEnum SubCategory1Update(SubCategory1DTO subCategory1DTO);
		public MessageEnum DeleteSubCategory1(int SubCategory1Id, Int64 DeletedBy);
		public List<SubCategory1> GetSubCategory1List();
		public SubCategory1 GetSubCategory1ById(int SubCategory1Id);
	}
}
