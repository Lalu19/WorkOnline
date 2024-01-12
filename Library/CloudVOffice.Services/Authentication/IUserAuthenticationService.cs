﻿using CloudVOffice.Core.Domain.Users;

namespace CloudVOffice.Services.Authentication
{
    public interface IUserAuthenticationService
    {
        public Task<UserLoginResults> ValidateUserAsync(string EmailId, string Password);
		public Task<UserLoginResults> SellerValidateUserAsync(string UserMobileNumber, string Password);

	}
}
