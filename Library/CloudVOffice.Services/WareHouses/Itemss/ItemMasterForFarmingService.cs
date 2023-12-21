using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace CloudVOffice.Services.WareHouses.Itemss
{
	public class ItemMasterForFarmingService : IItemMasterForFarmingService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<ItemMasterForFarming> _itemMasterForFarmingRepo;

		public ItemMasterForFarmingService(ApplicationDBContext dbContext, ISqlRepository<ItemMasterForFarming> itemMasterForFarmingRepo)
		{
			_dbContext = dbContext;
			_itemMasterForFarmingRepo = itemMasterForFarmingRepo;
		}
		public ItemMasterForFarmingDTO CreateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO)
		{
			try
			{
				var existingItemMasterForFarming = _dbContext.ItemMasterForFarmings
					.Where(i => i.ItemMasterForFarmingId == itemMasterForFarmingDTO.ItemMasterForFarmingId && !i.Deleted)
					.FirstOrDefault();

				if (existingItemMasterForFarming == null)
				{
					ItemMasterForFarming itemMaster = new ItemMasterForFarming();

					itemMaster.SectorId = itemMasterForFarmingDTO.SectorId;
					itemMaster.CategoryId = itemMasterForFarmingDTO.CategoryId;
					itemMaster.SubCategory1Id = itemMasterForFarmingDTO.SubCategory1Id;

					itemMaster.SubCategory2Id = itemMasterForFarmingDTO.SubCategory2Id;
                    itemMaster.WareHouseName = itemMasterForFarmingDTO.WareHouseName;
                    itemMaster.EmployeeName = itemMasterForFarmingDTO.EmployeeName;
                    itemMaster.VendorName = itemMasterForFarmingDTO.VendorName;
                    itemMaster.DistrictName = itemMasterForFarmingDTO.DistrictName;
					

					itemMaster.Barcode = itemMasterForFarmingDTO.Barcode;
					itemMaster.BarCodeNotAvailable = itemMasterForFarmingDTO.BarCodeNotAvailable;
					itemMaster.UnitId = itemMasterForFarmingDTO.UnitId;
					itemMaster.ProductName = itemMasterForFarmingDTO.ProductName;
					itemMaster.QtyPerKg = itemMasterForFarmingDTO.QtyPerKg;
					itemMaster.Price = itemMasterForFarmingDTO.Price;
					itemMaster.MinQty = itemMasterForFarmingDTO.MinQty;
					itemMaster.GST = itemMasterForFarmingDTO.GST;
					itemMaster.HSN = itemMasterForFarmingDTO.HSN;
					itemMaster.HarvestDate = itemMasterForFarmingDTO.HarvestDate;

					itemMaster.InvoiceNo = itemMasterForFarmingDTO.InvoiceNo;
					itemMaster.ReceivedDate=itemMasterForFarmingDTO.ReceivedDate;

					itemMaster.CreatedBy = itemMasterForFarmingDTO.CreatedBy;

					itemMaster.Thumbnail = itemMasterForFarmingDTO.Thumbnail;
					if (itemMasterForFarmingDTO.Images != null && itemMasterForFarmingDTO.Images.Any())
					{
						itemMaster.Images = string.Join(",", itemMasterForFarmingDTO.Images);
					}
					else
					{
						itemMaster.Images = null; 
					}

					_itemMasterForFarmingRepo.Insert(itemMaster);
					_dbContext.SaveChangesAsync();

					return new ItemMasterForFarmingDTO
					{
						ItemMasterForFarmingId = itemMaster.ItemMasterForFarmingId,

						CategoryId = itemMaster.CategoryId,
						SubCategory1Id = itemMaster.SubCategory1Id,

						SubCategory2Id = itemMaster.SubCategory2Id,
						WareHouseName =itemMaster.WareHouseName,
						EmployeeName =itemMaster.EmployeeName,
						VendorName =itemMaster.VendorName,
                        DistrictName = itemMaster.DistrictName,

                        Barcode = itemMaster.Barcode,
						BarCodeNotAvailable = itemMaster.BarCodeNotAvailable,
						UnitId = itemMaster.UnitId,
						ProductName = itemMaster.ProductName,
						QtyPerKg = itemMaster.QtyPerKg,
						Price = itemMaster.Price,
						MinQty = itemMaster.MinQty,
						GST = itemMaster.GST,
						HSN = itemMaster.HSN,
						HarvestDate = itemMaster.HarvestDate,

						InvoiceNo = itemMaster.InvoiceNo,
						ReceivedDate =itemMaster.ReceivedDate,

						CreatedBy = itemMaster.CreatedBy,

						Images = !string.IsNullOrEmpty(itemMaster.Images) ? itemMaster.Images.Split(',').ToList() : new List<string>(),
						Thumbnail = itemMaster.Thumbnail

					};
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public MessageEnum UpdateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO)
		{
			try
			{
				var itemMaster1 = _dbContext.ItemMasterForFarmings.Where(i => i.ItemMasterForFarmingId != itemMasterForFarmingDTO.ItemMasterForFarmingId && i.ProductName == itemMasterForFarmingDTO.ProductName).FirstOrDefault();
				if (itemMaster1 == null)
				{
					var itemMaster = _dbContext.ItemMasterForFarmings.Where(i => i.ItemMasterForFarmingId == itemMasterForFarmingDTO.ItemMasterForFarmingId).FirstOrDefault();

					if (itemMaster != null)
					{
						itemMaster.SectorId = itemMasterForFarmingDTO.SectorId;
						itemMaster.CategoryId = itemMasterForFarmingDTO.CategoryId;
						itemMaster.SubCategory1Id = itemMasterForFarmingDTO.SubCategory1Id;

						itemMaster.SubCategory2Id = itemMasterForFarmingDTO.SubCategory2Id;
						itemMaster.WareHouseName = itemMasterForFarmingDTO.WareHouseName;
						itemMaster.EmployeeName = itemMasterForFarmingDTO.EmployeeName;
						itemMaster.VendorName = itemMasterForFarmingDTO.VendorName;
                        itemMaster.DistrictName = itemMasterForFarmingDTO.DistrictName;

                        itemMaster.Barcode = itemMasterForFarmingDTO.Barcode;
						itemMaster.BarCodeNotAvailable = itemMasterForFarmingDTO.BarCodeNotAvailable;
						itemMaster.UnitId = itemMasterForFarmingDTO.UnitId;
						itemMaster.ProductName = itemMasterForFarmingDTO.ProductName;
						itemMaster.QtyPerKg = itemMasterForFarmingDTO.QtyPerKg;
						itemMaster.Price = itemMasterForFarmingDTO.Price;
						itemMaster.MinQty = itemMasterForFarmingDTO.MinQty;
						itemMaster.GST = itemMasterForFarmingDTO.GST;
						itemMaster.HSN = itemMasterForFarmingDTO.HSN;
						itemMaster.HarvestDate = itemMasterForFarmingDTO.HarvestDate;

						itemMaster.InvoiceNo = itemMasterForFarmingDTO.InvoiceNo;
						itemMaster.ReceivedDate = itemMasterForFarmingDTO.ReceivedDate;

						//itemMaster.Images = itemMasterForFarmingDTO.Images;

						if (itemMasterForFarmingDTO.Images != null && itemMasterForFarmingDTO.Images.Any())
						{
							itemMaster.Images = string.Join(",", itemMasterForFarmingDTO.Images);
						}
						else
						{
							itemMaster.Images = null; 
						}

						itemMaster.Thumbnail = itemMasterForFarmingDTO.Thumbnail;
						
						itemMaster.UpdatedDate = DateTime.Now;

						_itemMasterForFarmingRepo.Update(itemMaster);
						_dbContext.SaveChanges();

						return MessageEnum.Updated;
					}
					else { return MessageEnum.Invalid; }
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

        public List<Sector> GetSectorListforFarmerProduces()
        {
            try
            {
                return _dbContext.Sectors
                    .Where(x => x.SectorName == "Farmer Produces")
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public void GenerateAndSaveBarcodeImage(string itemMasterForFarmingId)
		{
			byte[] barcodeImageBytes = GenerateBarcodeImage(itemMasterForFarmingId);
			SaveBarcodeImageToDatabase(itemMasterForFarmingId, barcodeImageBytes);
		}


		public byte[] GenerateBarcodeImage(string itemMasterForFarmingId)
		{
			BarcodeWriterPixelData writer = new BarcodeWriterPixelData()
			{
				Format = BarcodeFormat.CODE_128,
				Options = new ZXing.Common.EncodingOptions
				{
					Height = 50,
					Width = 190,
					PureBarcode = false,
					Margin = 10
				}
			};

			var pixelData = writer.Write(itemMasterForFarmingId);

			using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
			{
				var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
				try
				{
					System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
				}
				finally
				{
					bitmap.UnlockBits(bitmapData);
				}

				using (var ms = new System.IO.MemoryStream())
				{
					bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
					return ms.ToArray();
				}
			}
		}

		private void SaveBarcodeImageToDatabase(string itemMasterForFarmingId, byte[] barcodeImageBytes)
		{

			Int64 itemIdInt = Convert.ToInt64(itemMasterForFarmingId);

			ItemMasterForFarming itemMaster = _dbContext.ItemMasterForFarmings.Find(itemIdInt);
			itemMaster.Barcode = Convert.ToBase64String(barcodeImageBytes); 
			_dbContext.SaveChanges();
		}


		public ItemMasterForFarming GetItemMasterForFarmingByItemMasterForFarmingId(long itemMasterForFarmingId)
		{
			try
			{
				return _dbContext.ItemMasterForFarmings.Where(i => i.ItemMasterForFarmingId == itemMasterForFarmingId).FirstOrDefault();
			}
			catch
			{
				throw;
			}
		}



		public ItemMasterForFarming GetItemMasterForFarmingById(long itemMasterForFarmingId)
		{
			try
			{

				ItemMasterForFarming items = _dbContext.ItemMasterForFarmings.Where(i => i.Deleted == false && i.ItemMasterForFarmingId == itemMasterForFarmingId).FirstOrDefault();


				// return _dbContext.ItemMasterForFarmings.Where(i => i.ItemMasterForFarmingId == itemMasterForFarmingId).FirstOrDefault();


					WareHuose wareHuose = _dbContext.WareHouses.FirstOrDefault(s => s.WareHuoseId == Convert.ToInt32(items.WareHouseName));
					Employee employee = _dbContext.Employees.FirstOrDefault(s => s.EmployeeId == Convert.ToInt32(items.EmployeeName));
					Vendor vendor = _dbContext.Vendors.FirstOrDefault(s => s.VendorId == Convert.ToInt32(items.VendorName));
					AddDistrict addDistrict = _dbContext.AddDistricts.FirstOrDefault(s => s.AddDistrictId == Convert.ToInt32(items.DistrictName));


					items.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
					items.EmployeeName = employee != null ? employee.EmployeeName : null;
					items.VendorName = vendor != null ? vendor.VendorName : null;
					items.DistrictName = addDistrict != null ? addDistrict.DistrictName : null;
				

				return items;
			}
			catch
			{
				throw;
			}
		}




		public List<ItemMasterForFarming> GetItemMasterForFarmingList()
		{
			try
			{
                List<Sector> sectors = _dbContext.Sectors.Where(s => s.Deleted == false).ToList();
                List<Category> categories = _dbContext.Categories.Where(c => c.Deleted == false).ToList();
                List<SubCategory1> subCategory1s = _dbContext.SubCategories1.Where(x => x.Deleted == false).ToList();

                List<SubCategory2> subCategory2s = _dbContext.SubCategories2.Where(x => x.Deleted == false).ToList();
                List<WareHuose> wareHuoses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
                List<Employee> employees = _dbContext.Employees.Where(x => x.Deleted == false).ToList();
                List<Vendor> venders = _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
                List<AddDistrict> districts = _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();

                List<ItemMasterForFarming> items = _dbContext.ItemMasterForFarmings.Where(i => i.Deleted == false).ToList();

                foreach (var item in items)
				{
					Sector sector = sectors.FirstOrDefault(i => i.SectorId == item.SectorId);
					Category category = categories.FirstOrDefault(c =>  c.CategoryId == item.CategoryId);
					SubCategory1 subCategory1 = subCategory1s.FirstOrDefault(s => s.SubCategory1Id == item.SubCategory1Id);
					SubCategory2 subCategory2 = subCategory2s.FirstOrDefault(s => s.SubCategory2Id == item.SubCategory2Id);

					WareHuose wareHuose = wareHuoses.FirstOrDefault(s => s.WareHuoseId == Convert.ToInt32(item.WareHouseName));
                    Employee employee = employees.FirstOrDefault(s => s.EmployeeId == Convert.ToInt32(item.EmployeeName));
                    Vendor vendor = venders.FirstOrDefault(s => s.VendorId == Convert.ToInt32(item.VendorName));
				    AddDistrict addDistrict = districts.FirstOrDefault(s => s.AddDistrictId == Convert.ToInt32(item.DistrictName));


					item.Sector = sector != null ? sector.SectorName : null;
					item.Category = category != null ? category.CategoryName : null;
					item.SubCategory1 = subCategory1 != null ? subCategory1.SubCategory1Name : null;
					item.SubCategory2 = subCategory2 != null ? subCategory2.SubCategory2Name : null;

					item.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
					item.EmployeeName = employee != null ? employee.EmployeeName : null;
					item.VendorName = vendor != null ? vendor.VendorName : null;
				    item.DistrictName = addDistrict != null ? addDistrict.DistrictName : null;
				}

				return items;   
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum DeleteItemMasterForFarming(long itemMasterForFarmingId, long DeletedBy)
		{
			try
			{
				var itemMaster = _dbContext.ItemMasterForFarmings.Where(i => i.ItemMasterForFarmingId == itemMasterForFarmingId).FirstOrDefault();

				if (itemMaster != null)
				{
					itemMaster.UpdatedBy = DeletedBy;
					itemMaster.Deleted = true;
					itemMaster.UpdatedDate = DateTime.Now;

					_dbContext.SaveChanges();

					return MessageEnum.Deleted;

				}
				else
				{
					return MessageEnum.Invalid;
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
