using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Buyers
{
    public class BuyerRegistrationDTO
    {
        public Int64? BuyerRegistrationId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Int64 PinCodeId { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string PrimaryPhone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? MailId { get; set; }
        public string SalesExecutiveUniqueNumber { get; set; }
        public string SalesExecutiveContact { get; set; }
        public string? GSTNumber { get; set; }
        public Int64? WareHuoseId { get; set; }
        //public string? Password { get; set; }
		public bool FirstLogin { get; set; }
		public int? SectorId { get; set; } 
		public string? ShopImage { get; set; }
		public Int64 CreatedBy { get; set; }
        public IFormFile? imageUpload { get; set; }
    }

    public class BuyerUpdateDTO
    {
		public Int64? BuyerRegistrationId { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public Int64 PinCodeId { get; set; }
		public string? Country { get; set; }
		public string? State { get; set; }
		public string PrimaryPhone { get; set; }
		public string? AlternatePhone { get; set; }
		public string? MailId { get; set; }
		public string SalesExecutiveUniqueNumber { get; set; }
		public string SalesExecutiveContact { get; set; }
		public string? GSTNumber { get; set; }
		public Int64? WareHuoseId { get; set; }
		public string? Password { get; set; }
		public bool FirstLogin { get; set; }
		public int? SectorId { get; set; }
		public string? ShopImage { get; set; }
		public Int64 CreatedBy { get; set; }
	}

}
