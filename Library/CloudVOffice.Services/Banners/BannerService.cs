using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Banners
{
	public class BannerService : IBannerService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<Banner> _bannerRepo;

		public BannerService(ApplicationDBContext dbContext, ISqlRepository<Banner> bannerRepo)
		{
			_dbContext = dbContext;
			_bannerRepo = bannerRepo;
		}
		public MessageEnum CreateBanner(BannerDTO bannerDTO)
		{
			try
			{
                var objcheck = _dbContext.Banners.SingleOrDefault(opt => opt.Deleted == false && opt.BannerName == bannerDTO.BannerName);
                if (objcheck == null)
				{
					Banner ban = new Banner();
					ban.BannerName = bannerDTO.BannerName;
					ban.BannerImage = bannerDTO.BannerImage;
					ban.CreatedBy = bannerDTO.CreatedBy;
                    ban.CreatedDate = System.DateTime.Now;
                    var obj = _bannerRepo.Insert(ban);
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
		public List<Banner> GetBannerList()
		{
			try
			{
				var a = _dbContext.Banners.Where(x => x.Deleted == false).ToList();
				return a;
			}
			catch
			{
				throw;
			}
		}
		public Banner GetBannerById(Int64 bannerId)
		{
			try
			{
				var a = _dbContext.Banners.Where(x => x.BannerId == bannerId && x.Deleted == false).FirstOrDefault();
				return a;
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum UpdateBanner(BannerDTO bannerDTO)
		{
			try
			{
				var a = _dbContext.Banners.Where(x => x.BannerId != bannerDTO.BannerId && x.BannerName == bannerDTO.BannerName && x.Deleted == false).FirstOrDefault();

				if (a == null)
				{
					var buy = _dbContext.Banners.Where(x => x.BannerId == bannerDTO.BannerId).FirstOrDefault();

					if (buy != null)
					{
						buy.BannerName = bannerDTO.BannerName;
						buy.BannerImage = bannerDTO.BannerImage;
						buy.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();

						return MessageEnum.Updated;
					}
					else
					{
						return MessageEnum.Invalid;
					}
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
		public MessageEnum DeleteBanner(Int64 bannerId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.Banners.Where(x => x.BannerId == bannerId).FirstOrDefault();
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
