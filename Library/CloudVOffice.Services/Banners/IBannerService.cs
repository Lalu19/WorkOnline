using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Banners
{
	public interface IBannerService
	{
		public MessageEnum CreateBanner(BannerDTO bannerDTO);
		public List<Banner> GetBannerList();
		public Banner GetBannerById(Int64 bannerId);
		public MessageEnum UpdateBanner(BannerDTO bannerDTO);
		public MessageEnum DeleteBanner(Int64 bannerId, Int64 DeletedBy);
	}
}
