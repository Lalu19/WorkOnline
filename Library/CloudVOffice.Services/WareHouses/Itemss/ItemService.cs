using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
//using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ZXing.QrCode;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.WareHouses.Brands;

namespace CloudVOffice.Services.WareHouses.Itemss
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Item> _itemRepo;

        public ItemService(ApplicationDBContext dbContext, ISqlRepository<Item> itemRepo)
        {
            _dbContext = dbContext;
            _itemRepo = itemRepo;
        }
		public ItemDTO CreateItem(ItemDTO itemDTO)
		{
			try
			{
				var existingItem = _dbContext.Items
					.Where(i => i.ItemName == itemDTO.ItemName && !i.Deleted)
					.FirstOrDefault();

					if (existingItem == null)
					{
						Item item = new Item();
						item.ItemName = itemDTO.ItemName;
						item.SectorId = itemDTO.SectorId;
						item.CategoryId = itemDTO.CategoryId;
						item.SubCategory1Id = itemDTO.SubCategory1Id;
						item.SubCategory2Id = itemDTO.SubCategory2Id;

						//item.WareHouseName = itemDTO.WareHouseName;
						//item.DistrictName = itemDTO.DistrictName;
						//item.VendorName = itemDTO.VendorName;
						//item.EmployeeName = itemDTO.EmployeeName;

						item.WareHuoseId = itemDTO.WareHuoseId;
						item.AddDistrictId = itemDTO.AddDistrictId;
						item.VendorId = itemDTO.VendorId;
						item.EmployeeId = itemDTO.EmployeeId;
						item.BrandId = itemDTO.BrandId;

						item.CompanyName = itemDTO.CompanyName;
						//item.BrandName = itemDTO.BrandName;
						item.ProductWeight = itemDTO.ProductWeight;
						item.UnitId = itemDTO.UnitId;
						item.CaseWeight = itemDTO.CaseWeight;
						item.UnitPerCase = itemDTO.UnitPerCase;
						item.ManufactureDate = itemDTO.ManufactureDate;
						item.ExpiryDate = itemDTO.ExpiryDate;
						item.Barcode = itemDTO.Barcode;
						item.BarCodeNotAvailable = itemDTO.BarCodeNotAvailable;
						item.MRP = itemDTO.MRP;
						item.MRPCaseCost = itemDTO.MRPCaseCost;
						item.HSN = itemDTO.HSN;
						item.PurchaseCost = itemDTO.PurchaseCost;
						item.PurchaseCaseCost = itemDTO.PurchaseCaseCost;
						item.SalesCost = itemDTO.SalesCost;
						item.SalesCaseCost = itemDTO.SalesCaseCost;
						item.SGST = itemDTO.SGST;
						item.CGST = itemDTO.CGST;
						item.SellerMargin = itemDTO.SellerMargin;

						//item.HandlingType = itemDTO.HandlingType;

						item.HandlingTypeId = itemDTO.HandlingTypeId;

						item.InvoiceNo = itemDTO.InvoiceNo;
						item.ReceivedDate = itemDTO.ReceivedDate;
						item.CreatedBy = itemDTO.CreatedBy;

						if (itemDTO.Images != null && itemDTO.Images.Any())
						{
							// Join the list of images into a comma-separated string
							item.Images = string.Join(",", itemDTO.Images);
						}
						else
						{
							item.Images = null; // or an empty string depending on your database schema
						}

						item.Thumbnail = itemDTO.Thumbnail;



						_itemRepo.Insert(item);
						_dbContext.SaveChangesAsync();

						return new ItemDTO
						{
							ItemId = item.ItemId,

							ItemName = item.ItemName,
							SectorId = item.SectorId,
							CategoryId = item.CategoryId,
							SubCategory1Id = item.SubCategory1Id,
							SubCategory2Id = item.SubCategory2Id,

							//WareHouseName = item.WareHouseName,
							//DistrictName = item.DistrictName,
							//VendorName = item.VendorName,
							//EmployeeName = item.EmployeeName,

							WareHuoseId = item.WareHuoseId,
							AddDistrictId = item.AddDistrictId,
							VendorId = item.VendorId,
							EmployeeId = item.EmployeeId,

							CompanyName = item.CompanyName,
							BrandId = item.BrandId,
							//BrandName = item.BrandName,
							UnitId = item.UnitId,
							ProductWeight = item.ProductWeight,
							CaseWeight = item.CaseWeight,
							UnitPerCase = item.UnitPerCase,
							ManufactureDate = item.ManufactureDate,
							ExpiryDate = item.ExpiryDate,
							Barcode = item.Barcode,
							BarCodeNotAvailable = item.BarCodeNotAvailable,
							MRP = item.MRP,
							MRPCaseCost = item.MRPCaseCost,
							PurchaseCost = item.PurchaseCost,
							PurchaseCaseCost = item.PurchaseCaseCost,
							SalesCost = item.SalesCost,
							SalesCaseCost = item.SalesCaseCost,
							SGST = item.SGST,
							HSN = item.HSN,
							CGST = item.CGST,
							SellerMargin = item.SellerMargin,

							//HandlingType = item.HandlingType,
							HandlingTypeId = item.HandlingTypeId,

							InvoiceNo = item.InvoiceNo,
							ReceivedDate = item.ReceivedDate,
							CreatedBy = item.CreatedBy,

							Images = !string.IsNullOrEmpty(item.Images) ? item.Images.Split(',').ToList() : new List<string>(),
							Thumbnail = item.Thumbnail

						};
					}
					else
					{
						// Handle the duplicate case as needed
						return null;
					}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it appropriately
				throw;
			}
		}

		public void GenerateAndSaveBarcodeImage(string itemId)
        {

			//Image barcodeImage = GenerateBarcodeImage(itemId);

			byte[] barcodeImageBytes = GenerateBarcodeImage(itemId);
			SaveBarcodeImageToDatabase(itemId, barcodeImageBytes);
		}

		public byte[] GenerateBarcodeImage(string itemId)
		{
			BarcodeWriterPixelData writer = new BarcodeWriterPixelData()
			{
				Format = BarcodeFormat.CODE_128,
				Options = new ZXing.Common.EncodingOptions
				{
					Height = 50,
					Width = 240,
					PureBarcode = false,
					Margin = 10
				}
			};

			var pixelData = writer.Write(itemId);

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

		private void SaveBarcodeImageToDatabase(string itemId, byte[] barcodeImageBytes)
        {
			//// Convert the Image to a byte array
			//byte[] imageBytes;
			//using (MemoryStream ms = new MemoryStream())
			//{
			//    barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			//    imageBytes = ms.ToArray();
			//}

			//// Update the Item entity with the barcode image
			//Item item = _dbContext.Items.Find(itemId);
			//item.Barcode = Convert.ToBase64String(imageBytes); // Store the barcode image as a base64-encoded string
			//_dbContext.SaveChanges();

			Int64 itemIdInt = Convert.ToInt64(itemId);

			Item item = _dbContext.Items.Find(itemIdInt);
			item.Barcode = Convert.ToBase64String(barcodeImageBytes); // Store the barcode image as a base64-encoded string
			_dbContext.SaveChanges();
		}

		public MessageEnum UpdateItem(ItemDTO itemDTO)
		{
			try
			{
				var item1 = _dbContext.Items.Where(i => i.ItemId != itemDTO.ItemId && i.ItemName == itemDTO.ItemName).FirstOrDefault();
				if (item1 == null)
				{
					var item = _dbContext.Items.Where(i => i.ItemId == itemDTO.ItemId).FirstOrDefault();

					if (item != null)
					{
						item.ItemName = itemDTO.ItemName;
						item.SectorId = itemDTO.SectorId;
						item.CategoryId = itemDTO.CategoryId;
						item.SubCategory1Id = itemDTO.SubCategory1Id;
						item.SubCategory2Id = itemDTO.SubCategory2Id;

                        //item.WareHouseName = itemDTO.WareHouseName;
                        //item.DistrictName = itemDTO.DistrictName;
                        //item.VendorName = itemDTO.VendorName;
                        //item.EmployeeName = itemDTO.EmployeeName;

                        item.WareHuoseId = itemDTO.WareHuoseId;
                        item.AddDistrictId = itemDTO.AddDistrictId;
                        item.VendorId = itemDTO.VendorId;
                        item.EmployeeId = itemDTO.EmployeeId;


                        item.CompanyName = itemDTO.CompanyName;
                        item.BrandId = itemDTO.BrandId;
                       // item.BrandName = itemDTO.BrandName;
						item.ProductWeight = itemDTO.ProductWeight;
						item.UnitId = itemDTO.UnitId;
                        item.CaseWeight = itemDTO.CaseWeight;
                        item.UnitPerCase = itemDTO.UnitPerCase;
                        item.ManufactureDate = itemDTO.ManufactureDate;
                        item.ExpiryDate = itemDTO.ExpiryDate;
                        item.Barcode = itemDTO.Barcode;
                        item.HSN = itemDTO.HSN;
                        item.BarCodeNotAvailable = itemDTO.BarCodeNotAvailable;
                        item.MRP = itemDTO.MRP;
                        item.MRPCaseCost = itemDTO.MRPCaseCost;
                        item.PurchaseCost = itemDTO.PurchaseCost;
                        item.PurchaseCaseCost = itemDTO.PurchaseCaseCost;
                        item.SalesCost = itemDTO.SalesCost;
                        item.SalesCaseCost = itemDTO.SalesCaseCost;
                        item.SGST = itemDTO.SGST;
                        item.CGST = itemDTO.CGST;
						item.SellerMargin=itemDTO.SellerMargin;

                        //item.HandlingType = itemDTO.HandlingType;
                        item.HandlingTypeId = itemDTO.HandlingTypeId;

                        item.InvoiceNo = itemDTO.InvoiceNo;
						item.ReceivedDate = itemDTO.ReceivedDate;
						item.UpdatedBy = itemDTO.CreatedBy;

						if (itemDTO.Images != null && itemDTO.Images.Any())
						{
							// Join the list of images into a comma-separated string
							item.Images = string.Join(",", itemDTO.Images);
						}

						if (itemDTO.ThumbnailUp != null)
						{
							// Update the thumbnail only if a new file is provided
							// Your existing logic to save the thumbnail goes here
						}

						// Update other fields as needed

						item.UpdatedDate = DateTime.Now;

						_itemRepo.Update(item);
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

		public Item GetItemByItemId(Int64 itemId)
        {
            try
            {
                return _dbContext.Items.Where(i => i.ItemId == itemId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

		public Item GetItemById(Int64 itemId)
		{
			try
			{

				List<WareHuose> wareHuoses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
				List<Employee> employees = _dbContext.Employees.Where(x => x.Deleted == false).ToList();
				List<Vendor> venders = _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
				List<AddDistrict> districts = _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();
				List<Unit> units = _dbContext.Units.Where(x => x.Deleted == false).ToList();
				List<HandlingType> handlingTypes = _dbContext.HandlingTypes.Where(h => h.Deleted == false).ToList();
				List<Brand> brands = _dbContext.Brands.Where(h => h.Deleted == false).ToList();

				Item item = _dbContext.Items.Where(i => i.Deleted == false && i.ItemId == itemId).FirstOrDefault();


				WareHuose wareHuose = wareHuoses.FirstOrDefault(s => s.WareHuoseId == Convert.ToInt32(item.WareHuoseId));
				Employee employee = employees.FirstOrDefault(s => s.EmployeeId == Convert.ToInt32(item.EmployeeId));
				Vendor vendor = venders.FirstOrDefault(s => s.VendorId == Convert.ToInt32(item.VendorId));
				AddDistrict addDistrict = districts.FirstOrDefault(s => s.AddDistrictId == Convert.ToInt32(item.AddDistrictId));
				Unit unit = units.FirstOrDefault(s => s.UnitId == Convert.ToInt32(item.UnitId));
				HandlingType handlingType = handlingTypes.FirstOrDefault(s => s.HandlingTypeId == Convert.ToInt32(item.HandlingTypeId));
				Brand brand = brands.FirstOrDefault(s => s.BrandId == Convert.ToInt32(item.BrandId));


				item.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
				item.EmployeeName = employee != null ? employee.EmployeeName : null;
				item.VendorName = vendor != null ? vendor.VendorName : null;
				item.DistrictName = addDistrict != null ? addDistrict.DistrictName : null;
				item.ShortName = unit != null ? unit.ShortName : null;
				item.HandlingType = handlingType != null ? handlingType.HandlingTypeName : null;
				item.BrandName = brand != null ? brand.BrandName : null;


				return item;

			}
			catch
			{
				throw;
			}
		}

		public MessageEnum DeleteItem(Int64 itemId, Int64 DeletedBy)
        {
            try
            {
                var item = _dbContext.Items.Where(i => i.ItemId == itemId).FirstOrDefault();

                if(item != null)
                {
                    item.UpdatedBy = DeletedBy;
                    item.Deleted = true;
                    item.UpdatedDate = DateTime.Now;

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

        public List<Item> GetItemList()
        {
			try 
			{
				List<Sector> sectors = _dbContext.Sectors.Where(s => s.Deleted == false).ToList();
				List<Category> categories = _dbContext.Categories.Where(c => c.Deleted == false).ToList();
				List<SubCategory1> subCategory1s = _dbContext.SubCategories1.Where(x => x.Deleted == false).ToList();
				List<SubCategory2> subCategory2s = _dbContext.SubCategories2.Where(x => x.Deleted == false).ToList();
				List<WareHuose> warehouses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
				List<AddDistrict> districts = _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();
				List<Employee> employees = _dbContext.Employees.Where(x => x.Deleted == false).ToList();
				List<Vendor> vendors = _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
				List<HandlingType> handlingTypes = _dbContext.HandlingTypes.Where(h => h.Deleted == false).ToList();
				//List<GST> gsts = _dbContext.GSTs.Where(g => g.Deleted == false).ToList();
				List<Item> items = _dbContext.Items.Where(i  => i.Deleted == false).ToList();
				List<Unit> units = _dbContext.Units.Where(i  => i.Deleted == false).ToList();
				List<Brand> brands = _dbContext.Brands.Where(i  => i.Deleted == false).ToList();


				foreach (var item in items)
				{
					HandlingType handlingType = handlingTypes.FirstOrDefault(h => h.HandlingTypeId == Convert.ToInt32(item.HandlingTypeId));
					WareHuose wareHuose = warehouses.FirstOrDefault(h => h.WareHuoseId == Convert.ToInt32(item.WareHuoseId));
					AddDistrict district = districts.FirstOrDefault(h => h.AddDistrictId == Convert.ToInt32(item.AddDistrictId));
					Vendor vendor = vendors.FirstOrDefault(h => h.VendorId == Convert.ToInt32(item.VendorId));
					Employee emp = employees.FirstOrDefault(h => h.EmployeeId == Convert.ToInt32(item.EmployeeId));
				//	GST gst = gsts.FirstOrDefault(g => g.GSTId == Convert.ToInt32(item.CGST));
					Sector sector = sectors.FirstOrDefault(q => q.SectorId == Convert.ToInt32(item.SectorId));
					Category category = categories.FirstOrDefault(z => z.CategoryId == Convert.ToInt32(item.CategoryId));
					SubCategory1 subCategory1 = subCategory1s.FirstOrDefault(y => y.SubCategory1Id == Convert.ToInt32(item.SubCategory1Id));
					SubCategory2 subCategory2 = subCategory2s.FirstOrDefault(y => y.SubCategory2Id == Convert.ToInt32(item.SubCategory2Id));
					Unit unit = units.FirstOrDefault(h => h.UnitId == Convert.ToInt32(item.UnitId));
					Brand brand = brands.FirstOrDefault(h => h.BrandId == Convert.ToInt32(item.BrandId));


					item.HandlingType = handlingType != null ? handlingType.HandlingTypeName : null;
					//item.CGST = gst != null ? gst.GSTValue : null;
					item.SectorName = sector != null ? sector.SectorName : null;
					item.CategoryName = category != null ? category.CategoryName : null;
					item.SubCategory1Name = subCategory1 != null ? subCategory1.SubCategory1Name : null;
					item.SubCategory2Name = subCategory2 != null ? subCategory2.SubCategory2Name : null;
					item.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
					item.DistrictName = district != null ? district.DistrictName : null;
					item.VendorName = vendor != null ? vendor.VendorName : null;
					item.EmployeeName = emp != null ? emp.EmployeeName : null;
					item.ShortName = unit != null ? unit.ShortName : null;
					item.BrandName = brand != null ? brand.BrandName : null;
				}

					return items;
			}
			catch
			{
				throw;
			}
		}

		public List<Item> GetItemlistByBrandId(Int64 BrandId)
		{
            return _dbContext.Items.Where(x => x.BrandId == BrandId && x.Deleted == false).ToList();
        }
        public List<Item> GetItemlistByCategoryId(int CategoryId)
        {
            return _dbContext.Items.Where(x => x.CategoryId == CategoryId && x.Deleted == false).ToList();
        }
        public List<Item> GetItemlistBySectorId(int SectorId)
        {
            return _dbContext.Items.Where(x => x.SectorId == SectorId && x.Deleted == false).ToList();
        }

    }
}
