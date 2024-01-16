using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.ProductCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.ProductCategories
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        private readonly ApplicationDBContext _dbContext;
		public SectorController(ISectorService sectorService, ApplicationDBContext dbContext)
        {
            _sectorService = sectorService;
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult SectorCreate(SectorDTO sectorDTO)
        {
            try
            {
                var a = _sectorService.SectorCreate(sectorDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SectorList()
        {
            var a = _sectorService.GetSectorList();
            return Ok(a);
        }
        [HttpGet("{SectorId}")]
        public IActionResult SingleSectorListbyId(int SectorId)
        {
            var a = _sectorService.GetSectorById(SectorId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateSector(SectorDTO sectorDTO)
        {
            try
            {
                var a = _sectorService.SectorUpdate(sectorDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{SectorId}/{DeletedBy}")]
        public ActionResult DeleteSector(int SectorId, int DeletedBy)
        {
            var a = _sectorService.DeleteSector(SectorId, DeletedBy);
            return Ok(a);
        }
        [HttpGet]
        public IActionResult GetSectorListforFarmerProduces()
        {
            var a = _sectorService.GetSectorListforFarmerProduces();
            return Ok(a);
        }

		//      [HttpGet]
		//      public IActionResult SectorTreeView(int SectorId)
		//{
		//          //var a = _dbContext.Sectors.Select(s => s.SectorId).ToList();

		//          var a = _sectorService.GetSectorList();

		//          List<int> catIds = new List<int>();


		//          foreach (var sectorId in a)
		//          {
		//		var categoryIds = _dbContext.Categories
		//                           .Where(c => c.SectorId == sectorId)
		//                           .Select(c => c.CategoryId)
		//                           .ToList();

		//		catIds.Add(categoryIds);
		//          }
		//}


		[HttpGet]
		public IActionResult SectorTreeView()
		{
			var sectors = _sectorService.GetSectorList();

			//List<(Sector Sector, List<Category> CategoryIds)> sectorCategories = new List<(Sector, List<Category>();

			List<(Sector Sector, List<Category> CategoryIds)> sectorCategories = new List<(Sector, List<Category>)>();


			foreach (var sector in sectors)
			{
				var categoryIds = _dbContext.Categories
									.Where(c => c.SectorId == sector.SectorId)									
									.ToList();

				sectorCategories.Add((sector, categoryIds));


                //foreach(var category in categoryIds)
                //{
                //    var sectorCategory = _dbContext.Items.Where(q => q.CategoryId == category.CategoryId).ToList();


                //}
			}


			return Ok(sectorCategories); // or whatever response you want to return
		}


		//[HttpGet]
		//public IActionResult SectorTreeViewAll()
		//{
		//	var sectors = _sectorService.GetSectorList();

		//	List<(Sector Sector, List<Category> Categories, List<Item> Items)> sectorCategories = new List<(Sector, List<Category>, List<Item>)>();

		//	foreach (var sector in sectors)
		//	{
		//		var categoryIds = _dbContext.Categories
		//							.Where(c => c.SectorId == sector.SectorId)
		//							.ToList();

		//		List<Item> itemsForSector = new List<Item>();

		//		foreach (var category in categoryIds)
		//		{
		//			var items = _dbContext.Items
		//							.Where(q => q.CategoryId == category.CategoryId)
		//							.ToList();

		//			itemsForSector.AddRange(items);
		//		}

		//		sectorCategories.Add((sector, categoryIds, itemsForSector));
		//	}

		//	// Now, sectorCategories contains tuples of sectors, categories, and associated items.

		//	// Your logic here...

		//	return Ok(sectorCategories); // or whatever response you want to return
		//}


		//[HttpGet]
		//public IActionResult SectorTreeViewAll()
		//{
		//	var sectors = _sectorService.GetSectorList();

		//	List<(Sector Sector, List<(Category Category, List<Item> Items)> Categories)> SectorsWithCategories =
		//		new List<(Sector, List<(Category, List<Item>)>)>();

		//	foreach (var sector in sectors)
		//	{
		//		var categories = _dbContext.Categories
		//							.Where(c => c.SectorId == sector.SectorId)
		//							.ToList();

		//		List<(Category, List<Item>)> CategoriesWithItems = new List<(Category, List<Item>)>();

		//		foreach (var category in categories)
		//		{
		//			var items = _dbContext.Items
		//							.Where(q => q.CategoryId == category.CategoryId)
		//							.ToList();

		//			CategoriesWithItems.Add((category, items));
		//		}

		//		SectorsWithCategories.Add((sector, CategoriesWithItems));
		//	}

		//	// Now, SectorsWithCategories contains tuples of sectors, categories, and associated items.

		//	// Your logic here...

		//	return Ok(SectorsWithCategories); // or whatever response you want to return
		//}

		[HttpGet]
		public IActionResult SectorTreeViewAll()
		{
			var sectors = _sectorService.GetSectorList();

			var result = sectors.Select(sector => new
			{
				Sector = new
				{
					sector.SectorId,
					sector.SectorName,
					sector.CreatedBy,
					sector.CreatedDate,
					sector.UpdatedBy,
					sector.UpdatedDate,
					sector.Deleted
				},
				Categories = _dbContext.Categories
					.Where(c => c.SectorId == sector.SectorId)
					.Select(category => new
					{
						Category = new
						{
							category.CategoryId,
							category.SectorId,
							category.CategoryName,
							category.CreatedBy,
							category.CreatedDate,
							category.UpdatedBy,
							category.UpdatedDate,
							category.Deleted
						},
						SubCategories1 = _dbContext.SubCategories1
							.Where(sub => sub.CategoryId == category.CategoryId)
							.Select(sub => new
							{
								sub.SubCategory1Id,
								sub.SubCategory1Name,
								sub.SectorId,
								sub.CategoryId,
								sub.GSTId,
								sub.HSN,
								sub.CreatedBy,
								sub.CreatedDate,
								sub.UpdatedBy,
								sub.UpdatedDate,
								sub.Deleted,
								SubCategories2 = _dbContext.SubCategories2
									.Where(sub2 => sub2.SubCategory1Id == sub.SubCategory1Id)
									.Select(sub2 => new
									{
										sub2.SubCategory2Id,
										sub2.SubCategory2Name,
										sub2.SectorId,
										sub2.CategoryId,
										sub2.SubCategory1Id,
										sub2.CreatedBy,
										sub2.CreatedDate,
										sub2.UpdatedBy,
										sub2.UpdatedDate,
										sub2.Deleted
									})
									.ToList()
							})
							.ToList()
					})
					.ToList()
			})
			.ToList();

			return Ok(result);
		}
	}
}
