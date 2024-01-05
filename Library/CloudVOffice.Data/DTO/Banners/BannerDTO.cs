using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Banners
{
	public class BannerDTO
	{
		public Int64? BannerId { get; set; }
		public string? BannerName { get; set; }
		public string? BannerImage { get; set; }
		public Int64 CreatedBy { get; set; }
		public IFormFile? BannerImageUp { get; set; }
	}
}
