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
	public class SubCategory4Service : ISubCategory4Service
    {
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SubCategory4> _SubCategory4Repo;
		public SubCategory4Service(ApplicationDBContext dbContext, ISqlRepository<SubCategory4> SubCategory4Repo)
		{
			_dbContext = dbContext;
			_SubCategory4Repo = SubCategory4Repo;
		}
		public MessageEnum SubCategory4Create(SubCategory4DTO subCategory4DTO)
		{
			try
			{
				var objcheck = _dbContext.SubCategories4.SingleOrDefault(opt => opt.Deleted == false && opt.SubCategory4Name == subCategory4DTO.SubCategory4Name);
				if (objcheck == null)
				{
					SubCategory4 ct = new SubCategory4();
					ct.SectorId = subCategory4DTO.SectorId;
					ct.CategoryId = subCategory4DTO.CategoryId;
					ct.SubCategory1Id = subCategory4DTO.SubCategory1Id;
					ct.SubCategory2Id = subCategory4DTO.SubCategory2Id;
					ct.SubCategory3Id= subCategory4DTO .SubCategory3Id;
					ct.SubCategory4Name = subCategory4DTO.SubCategory4Name;

					ct.CreatedBy = subCategory4DTO.CreatedBy;
					ct.CreatedDate = System.DateTime.Now;
					var obj = _SubCategory4Repo.Insert(ct);
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
		public List<SubCategory4> GetSubCategory4List()
		{
			try
			{
				return _dbContext.SubCategories4.Where(x => x.Deleted == false).ToList();

			}
			catch
			{
				throw;
			}
		}
		public SubCategory4 GetSubCategory4ById(int SubCategory4Id)
		{
			return _dbContext.SubCategories4.Where(x => x.SubCategory4Id == SubCategory4Id && x.Deleted == false).SingleOrDefault();
		}
		public MessageEnum SubCategory4Update(SubCategory4DTO subCategory4DTO)
		{
			try
			{
				var updateSubCategory4 = _dbContext.SubCategories4.Where(x => x.SubCategory4Id != subCategory4DTO.SubCategory4Id && x.SubCategory4Name == subCategory4DTO.SubCategory4Name && x.Deleted == false).FirstOrDefault();
				if (updateSubCategory4 == null)
				{
					var a = _dbContext.SubCategories4.Where(x => x.SubCategory4Id == subCategory4DTO.SubCategory4Id).FirstOrDefault();
					if (a != null)
					{
						a.SectorId = subCategory4DTO.SectorId;
						a.CategoryId = subCategory4DTO.CategoryId;
						a.SubCategory1Id = subCategory4DTO.SubCategory1Id;
						a.SubCategory2Id = subCategory4DTO.SubCategory2Id;
						a.SubCategory3Id=subCategory4DTO.SubCategory3Id;
						a.SubCategory4Name = subCategory4DTO.SubCategory4Name;
						a.UpdatedBy = subCategory4DTO.CreatedBy;
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
		public MessageEnum DeleteSubCategory4(int SubCategory4Id, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.SubCategories4.Where(x => x.SubCategory4Id == SubCategory4Id).FirstOrDefault();
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
		public List<SubCategory4> GetSubCategory4BySubCategory3Id(int SubCategory3Id)
		{
			return _dbContext.SubCategories4.Where(x => x.SubCategory3Id == SubCategory3Id && x.Deleted == false).ToList();
		}
	}
}
