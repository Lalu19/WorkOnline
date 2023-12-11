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

		//public MessageEnum CreateItem(ItemDTO itemDTO)
		//{
		//	try
		//	{


		//		var item1 = _dbContext.Items.Where(i => i.ItemId == itemDTO.ItemId && i.Deleted == false).FirstOrDefault();

		//		if (item1 == null)
		//		{
		//			Item item = new Item();
		//			item.ItemName = itemDTO.ItemName;
		//			item.CompanyName = itemDTO.CompanyName;
		//			item.BrandName = itemDTO.BrandName;
		//			item.UnitOfMeasurement = itemDTO.UnitOfMeasurement;
		//			item.CaseWeight = itemDTO.CaseWeight;
		//			item.UnitPerCase = itemDTO.UnitPerCase;
		//			item.ManufactureDate = itemDTO.ManufactureDate;
		//			item.ExpiryDate = itemDTO.ExpiryDate;
		//			item.Barcode = itemDTO.Barcode;
		//			item.BarCodeAvailable = itemDTO.BarCodeAvailable;
		//			item.MRP = itemDTO.MRP;
		//			item.PurchaseCost = itemDTO.PurchaseCost;
		//			item.SalesCost = itemDTO.SalesCost;
		//			item.SGST = itemDTO.SGST;
		//			item.CGST = itemDTO.CGST;
		//			item.HandlingType = itemDTO.HandlingType;
		//			//item.Images = itemDTO.Images;

		//			if (itemDTO.Images != null && itemDTO.Images.Any())
		//			{
		//				// Join the list of images into a comma-separated string
		//				item.Images = string.Join(",", itemDTO.Images);
		//			}
		//			else
		//			{
		//				item.Images = null; // or an empty string depending on your database schema
		//			}

		//			item.Thumbnail = itemDTO.Thumbnail;

		//			item.Videos = itemDTO.Videos;
		//			item.IsActive = itemDTO.IsActive;
		//			item.CreatedBy = itemDTO.CreatedBy;

		//			_itemRepo.Insert(item);
		//			_dbContext.SaveChanges();


		//			return MessageEnum.Success;


		//		}
		//		else
		//		{
		//			return MessageEnum.Duplicate;
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}

		//}





		public ItemDTO CreateItem(ItemDTO itemDTO)
		{
			try
			{
				var existingItem = _dbContext.Items
					.Where(i => i.ItemId == itemDTO.ItemId && !i.Deleted)
					.FirstOrDefault();

				if (existingItem == null)
				{
					Item item = new Item();
					item.ItemName = itemDTO.ItemName;
					item.SectorId = itemDTO.SectorId;
					item.CategoryId = itemDTO.CategoryId;
					item.SubCategory1Id = itemDTO.SubCategory1Id;
					item.CompanyName = itemDTO.CompanyName;
					item.BrandName = itemDTO.BrandName;
					item.UnitOfMeasurement = itemDTO.UnitOfMeasurement;
					item.CaseWeight = itemDTO.CaseWeight;
					item.UnitPerCase = itemDTO.UnitPerCase;
					item.ManufactureDate = itemDTO.ManufactureDate;
					item.ExpiryDate = itemDTO.ExpiryDate;
					item.Barcode = itemDTO.Barcode;
					item.BarCodeNotAvailable = itemDTO.BarCodeNotAvailable;
					item.MRP = itemDTO.MRP;
					item.PurchaseCost = itemDTO.PurchaseCost;
					item.SalesCost = itemDTO.SalesCost;
					item.SGST = itemDTO.SGST;
					item.CGST = itemDTO.CGST;
					item.HandlingType = itemDTO.HandlingType;

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
						CompanyName = item.CompanyName,
						BrandName = item.BrandName,
						UnitOfMeasurement = item.UnitOfMeasurement,
						CaseWeight = item.CaseWeight,
						UnitPerCase = item.UnitPerCase,
						ManufactureDate = item.ManufactureDate,
						ExpiryDate = item.ExpiryDate,
						Barcode = item.Barcode,
						BarCodeNotAvailable = item.BarCodeNotAvailable,
						MRP = item.MRP,
						PurchaseCost = item.PurchaseCost,
						SalesCost = item.SalesCost,
						SGST = item.SGST,
						CGST = item.CGST,
						HandlingType = item.HandlingType,

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





		//private Image GenerateBarcodeImage(Int64 itemId)
		//{
		//          //Use the BarcodeLib or any other library to generate the barcode image


		//          Barcode barcode = new Barcode();
		//          string data = itemId.ToString();
		//          barcode.IncludeLabel = true;
		//          barcode.Alignment = AlignmentPositions.Center;

		//          // Assuming there is a new way to specify the barcode type in version 3.0.3
		//          //barcode.EncodedType = BarcodeLib.TYPE.UPCA;
		//          //barcode.EncodedType = BarcodeLib.


		//          //return barcode.Encode(Type(data), Color.Black, Color.White, 290, 120);

		//      }


		//private Bitmap GenerateBarcodeImage(Int64 itemId)
		//{
		//	BarcodeWriter barcodeWriter = new BarcodeWriter();
		//	barcodeWriter.Format = BarcodeFormat.UPCA; // Use UPCA format for UPC-A barcodes
		//	barcodeWriter.Options = new ZXing.Common.EncodingOptions
		//	{
		//		Width = 290,   // Set the width of the barcode image
		//		Height = 120,  // Set the height of the barcode image
		//		Margin = 10    // Set the margin of the barcode
		//	};

		//	string data = itemId.ToString();
		//	Bitmap barcodeBitmap = barcodeWriter.Write(data);

		//	return barcodeBitmap;
		//}

		//private Bitmap GenerateBarcodeImage(string itemId)
		//{
		//	////BarcodeWriter barcodeWriter = new BarcodeWriter();

		//	//BarcodeWriter<Bitmap> barcodeWriter = new BarcodeWriter<Bitmap>();
		//	//barcodeWriter.Format = BarcodeFormat.UPC_A; // Use UPCA format for UPC-A barcodes
		//	//barcodeWriter.Options = new ZXing.Common.EncodingOptions
		//	//{
		//	//	Width = 290,   // Set the width of the barcode image
		//	//	Height = 120,  // Set the height of the barcode image
		//	//	Margin = 10    // Set the margin of the barcode
		//	//};

		//	//string data = itemId.ToString();
		//	//Bitmap barcodeBitmap = barcodeWriter.Write(data);

		//	//return barcodeBitmap;




		//	//BarcodeWriter<Bitmap> barcodeWriter = new BarcodeWriter<Bitmap>
		//	//{
		//	//	Format = BarcodeFormat.UPC_A,
		//	//	Options = new ZXing.Common.EncodingOptions
		//	//	{
		//	//		Width = 290,
		//	//		Height = 120,
		//	//		Margin = 10
		//	//	},
		//	//};

		//	//string data = itemId.ToString();
		//	//Bitmap barcodeBitmap = barcodeWriter.Write(data);

		//	//return barcodeBitmap;


		//	BarcodeWriterPixelData writer = new BarcodeWriterPixelData()
		//	{
		//		Format = BarcodeFormat.CODE_128,
		//		Options = new ZXing.Common.EncodingOptions
		//		{
		//			Height = 400,
		//			Width = 800,
		//			PureBarcode = false, // Indicates that the text should be displayed
		//			Margin = 10
		//		}
		//	};

		//	var pixelData = writer.Write("test text");

		//	using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
		//	{
		//		using (var ms = new System.IO.MemoryStream())
		//		{
		//			var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
		//			try
		//			{
		//				System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
		//			}
		//			finally
		//			{
		//				bitmap.UnlockBits(bitmapData);
		//			}

		//			bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
		//			return File(ms.ToArray(), "image/jpeg");
		//		}
		//	}

		//}


		public byte[] GenerateBarcodeImage(string itemId)
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
                        item.CompanyName = itemDTO.CompanyName;
                        item.BrandName = itemDTO.BrandName;
                        item.UnitOfMeasurement = itemDTO.UnitOfMeasurement;
                        item.CaseWeight = itemDTO.CaseWeight;
                        item.UnitPerCase = itemDTO.UnitPerCase;
                        item.ManufactureDate = itemDTO.ManufactureDate;
                        item.ExpiryDate = itemDTO.ExpiryDate;
                        item.Barcode = itemDTO.Barcode;
                        item.BarCodeNotAvailable = itemDTO.BarCodeNotAvailable;
                        item.MRP = itemDTO.MRP;
                        item.PurchaseCost = itemDTO.PurchaseCost;
                        item.SalesCost = itemDTO.SalesCost;
                        item.SGST = itemDTO.SGST;
                        item.CGST = itemDTO.CGST;
                        item.HandlingType = itemDTO.HandlingType;
					    //item.Images = itemDTO.Images;

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
					    item.Videos = itemDTO.Videos;
                        item.IsActive = itemDTO.IsActive;
                        item.UpdatedDate = DateTime.Now;

                        _itemRepo.Update(item);
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
				List<HandlingType> handlingTypes = _dbContext.HandlingTypes.Where(h => h.Deleted == false).ToList();
				List<GST> gsts = _dbContext.GSTs.Where(g => g.Deleted == false).ToList();
				List<Item> items = _dbContext.Items.Where(i  => i.Deleted == false).ToList();

				foreach (var item in items)
				{
					HandlingType handlingType = handlingTypes.FirstOrDefault(h => h.HandlingTypeId == Convert.ToInt32(item.HandlingType));
					GST gst = gsts.FirstOrDefault(g => g.GSTId == Convert.ToInt32(item.CGST));


					item.HandlingType = handlingType != null ? handlingType.HandlingTypeName : null;
					item.CGST = gst != null ? gst.GSTValue : null;
				}

					return items;
			}
			catch
			{
				throw;
			}
		}
    }
}
