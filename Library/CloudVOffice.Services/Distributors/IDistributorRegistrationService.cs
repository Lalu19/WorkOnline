using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Data.DTO.Distributor;

namespace CloudVOffice.Services.Distributors
{
	public interface IDistributorRegistrationService
	{
		public MessageEnum DistributorRegistrationCreate(DistributorRegistrationDTO distributorRegistrationDTO);
		public Task<DistributorRegistration> GetDistributorAsyncss(string UserMobileNumber);
		public Task<DistributorRegistration> GetDistributorLoginAsync(string UserMobileNumber, string Password);
	}
}
