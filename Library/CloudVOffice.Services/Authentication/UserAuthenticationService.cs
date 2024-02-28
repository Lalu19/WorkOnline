using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Security;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.Users;

namespace CloudVOffice.Services.Authentication
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ApplicationDBContext _context;
        private readonly ISqlRepository<User> _userRepo;
        private readonly ISqlRepository<SellerRegistration> _sellerRegistrationRepo;
        private readonly IUserService _userService;
        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly IDistributorRegistrationService _distributorRegistrationService;

        public UserAuthenticationService(ApplicationDBContext context, ISqlRepository<User> userRepo, IUserService userService, ISqlRepository<SellerRegistration> sellerRegistrationRepo, ISellerRegistrationService sellerRegistrationService, IDistributorRegistrationService distributorRegistrationService)
        {
            _context = context;
            _userRepo = userRepo;
            _userService = userService;
            _sellerRegistrationService = sellerRegistrationService;
            _sellerRegistrationRepo = sellerRegistrationRepo;
			_distributorRegistrationService = distributorRegistrationService;
		}


        public async Task<UserLoginResults> ValidateUserAsync(string EmailId, string Password)
        {
            var user = await _userService.GetUserByEmailAsync(EmailId);
            if (user == null)
                return UserLoginResults.UserNotExist;
            if (user.Deleted)
                return UserLoginResults.Deleted;
            if (!user.IsActive)
                return UserLoginResults.NotActive;
            if (user.Password != Encrypt.EncryptPassword(Password, EmailId))
                return UserLoginResults.WrongPassword;

            user.FailedLoginAttempts = 0;
            user.LastLoginDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return UserLoginResults.Successful;
        }
        public async Task<UserLoginResults> SellerValidateUserAsync(string UserMobileNumber, string Password)
        {
            var users = await _sellerRegistrationService.GetSellerAsyncss(UserMobileNumber);

            if (users == null)
                return UserLoginResults.UserNotExist;
            if (users.Deleted)
                return UserLoginResults.Deleted;
            if (users.Password != Password)
                return UserLoginResults.WrongPassword;

            await _context.SaveChangesAsync();

            return UserLoginResults.Successful;
        }

        public async Task<UserLoginResults> DistributorValidateUserAsync(string UserMobileNumber, string Password)
        {
            var users = await _distributorRegistrationService.GetDistributorAsyncss(UserMobileNumber);

            if (users == null)
                return UserLoginResults.UserNotExist;
            if (users.Deleted)
                return UserLoginResults.Deleted;
            if (users.Password != Password)
                return UserLoginResults.WrongPassword;

            await _context.SaveChangesAsync();

            return UserLoginResults.Successful;
        }



    }
}
