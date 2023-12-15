using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
	public class SubCategory2Service : ISubCategory2Service
    {
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SubCategory2> _SubCategory2Repo;
		public SubCategory2Service(ApplicationDBContext dbContext, ISqlRepository<SubCategory2> SubCategory2Repo)
		{
			_dbContext = dbContext;
			_SubCategory2Repo = SubCategory2Repo;
		}
		public MessageEnum SubCategory2Create(SubCategory2DTO subCategory2DTO)
		{
			try
			{
				var objcheck = _dbContext.SubCategories2.SingleOrDefault(opt => opt.Deleted == false && opt.SubCategory2Name == subCategory2DTO.SubCategory2Name);
				if (objcheck == null)
				{
					SubCategory2 ct = new SubCategory2();
					ct.SectorId = subCategory2DTO.SectorId;
					ct.CategoryId = subCategory2DTO.CategoryId;
					ct.SubCategory1Id = subCategory2DTO.SubCategory1Id;
					ct.SubCategory2Name = subCategory2DTO.SubCategory2Name;

					ct.CreatedBy = subCategory2DTO.CreatedBy;
					ct.CreatedDate = System.DateTime.Now;
					var obj = _SubCategory2Repo.Insert(ct);
					_dbContext.SaveChanges();

					return MessageEnum.Success;
				}
				else
				{
					return MessageEnum.Duplicate;
				}
			}
			catch
			{
				throw;
			}
		}
		public List<SubCategory2> GetSubCategory2List()
		{
			try
			{
				return _dbContext.SubCategories2.Where(x => x.Deleted == false).ToList();

			}
			catch
			{
				throw;
			}
		}
		public SubCategory2 GetSubCategory2ById(int SubCategory2Id)
		{
			return _dbContext.SubCategories2.Where(x => x.SubCategory2Id == SubCategory2Id && x.Deleted == false).SingleOrDefault();
		}
		public MessageEnum SubCategory2Update(SubCategory2DTO subCategory2DTO)
		{
			try
			{
				var updateSubCategory2 = _dbContext.SubCategories2.Where(x => x.SubCategory2Id != subCategory2DTO.SubCategory2Id && x.SubCategory2Name == subCategory2DTO.SubCategory2Name && x.Deleted == false).FirstOrDefault();
				if (updateSubCategory2 == null)
				{
					var a = _dbContext.SubCategories2.Where(x => x.SubCategory2Id == subCategory2DTO.SubCategory2Id).FirstOrDefault();
					if (a != null)
					{
						a.SectorId = subCategory2DTO.SectorId;
						a.CategoryId = subCategory2DTO.CategoryId;
						a.SubCategory1Id = subCategory2DTO.SubCategory1Id;
						a.SubCategory2Name = subCategory2DTO.SubCategory2Name;
						a.UpdatedBy = subCategory2DTO.CreatedBy;
						a.UpdatedDate = DateTime.Now;

						_dbContext.SaveChanges();
						return MessageEnum.Updated;
					}
					else
						return MessageEnum.Invalid;
				}
				else
				{
					return MessageEnum.Duplicate;
				}
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum DeleteSubCategory2(int SubCategory2Id, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.SubCategories2.Where(x => x.SubCategory2Id == SubCategory2Id).FirstOrDefault();
				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Deleted;
				}
				else
					return MessageEnum.Invalid;
			}
			catch
			{
				throw;
			}
		}


        public List<SubCategory2> GetSubCategory2BySubCategory1Id(int SubCategory1Id)
        {
            return _dbContext.SubCategories2.Where(x => x.SubCategory1Id == SubCategory1Id && x.Deleted == false).ToList();
        }
    }
}
