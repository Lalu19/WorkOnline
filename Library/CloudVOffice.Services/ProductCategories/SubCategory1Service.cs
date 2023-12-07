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
	public class SubCategory1Service : ISubCategory1Service
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SubCategory1> _SubCategory1Repo;
		public SubCategory1Service(ApplicationDBContext dbContext, ISqlRepository<SubCategory1> SubCategory1Repo)
		{
			_dbContext = dbContext;
			_SubCategory1Repo = SubCategory1Repo;
		}
		public MessageEnum SubCategory1Create(SubCategory1DTO subCategory1DTO)
		{
			try
			{
				var objcheck = _dbContext.SubCategories1.SingleOrDefault(opt => opt.Deleted == false && opt.SubCategory1Name == subCategory1DTO.SubCategory1Name);
				if (objcheck == null)
				{
					SubCategory1 ct = new SubCategory1();
					ct.CategoryId = subCategory1DTO.CategoryId;
					ct.SubCategory1Name = subCategory1DTO.SubCategory1Name;

					ct.CreatedBy = subCategory1DTO.CreatedBy;
					ct.CreatedDate = System.DateTime.Now;
					var obj = _SubCategory1Repo.Insert(ct);
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
		public List<SubCategory1> GetSubCategory1List()
		{
			try
			{
				return _dbContext.SubCategories1.Where(x => x.Deleted == false).ToList();

			}
			catch
			{
				throw;
			}
		}
		public SubCategory1 GetSubCategory1ById(int SubCategory1Id)
		{
			return _dbContext.SubCategories1.Where(x => x.SubCategory1Id == SubCategory1Id && x.Deleted == false).SingleOrDefault();
		}
		public MessageEnum SubCategory1Update(SubCategory1DTO subCategory1DTO)
		{
			try
			{
				var updateSubCategory1 = _dbContext.SubCategories1.Where(x => x.SubCategory1Id != subCategory1DTO.SubCategory1Id && x.SubCategory1Name == subCategory1DTO.SubCategory1Name && x.Deleted == false).FirstOrDefault();
				if (updateSubCategory1 == null)
				{
					var a = _dbContext.SubCategories1.Where(x => x.SubCategory1Id == subCategory1DTO.SubCategory1Id).FirstOrDefault();
					if (a != null)
					{
						a.CategoryId = subCategory1DTO.CategoryId;
						a.SubCategory1Name = subCategory1DTO.SubCategory1Name;
						a.UpdatedBy = subCategory1DTO.CreatedBy;
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

		public MessageEnum DeleteSubCategory1(int SubCategory1Id, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.SubCategories1.Where(x => x.SubCategory1Id == SubCategory1Id).FirstOrDefault();
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

	}
}
