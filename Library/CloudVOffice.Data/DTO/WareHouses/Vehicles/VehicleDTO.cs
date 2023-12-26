namespace CloudVOffice.Data.DTO.WareHouses.Vehicles
{
    public class VehicleDTO
    {
        public Int64? VehicleId { get; set; }
        public string VehicleName { get; set; }
		public string? VehicleNumber { get; set; }
		public string? BrandName { get; set; }
		public string? ChasisNo { get; set; }
		public string? FuelType { get; set; }
		public string? DL { get; set; }
		public string? RC { get; set; }
		public string? InsuranceDetails { get; set; }
		public DateTime? PurchaseYear { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
