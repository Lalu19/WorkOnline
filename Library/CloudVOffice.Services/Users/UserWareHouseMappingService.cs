using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.Users;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.WareHouses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Users
{
    public class UserWareHouseMappingService : IUserWareHouseMappingService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<UserWareHouseMapping> _UserWareHouseMappingRepo;
        private readonly IWareHouseService _IWareHouseService;
        private readonly IUserService _userService;
        public UserWareHouseMappingService(ApplicationDBContext dbContext,
            ISqlRepository<UserWareHouseMapping> UserWareHouseMappingRepo,
            IUserService userService,
            IWareHouseService WareHouseService)
        {
            _dbContext = dbContext;
            _UserWareHouseMappingRepo = UserWareHouseMappingRepo;
            _IWareHouseService = WareHouseService;
            _userService = userService;
        }
        public MessageEnum UserWareHouseMappingCreate(UserWareHouseMappingDTO UserWareHouseMappingDTO)
        {
            try
            {
                var objcheck = _dbContext.UserWareHouseMappings.SingleOrDefault(opt => opt.Deleted == false && opt.UserId == UserWareHouseMappingDTO.UserId && opt.WareHuoseId == UserWareHouseMappingDTO.WareHuoseId);
                if (objcheck == null)
                {
                    UserWareHouseMapping UserWareHouseMapping = new UserWareHouseMapping();
                    UserWareHouseMapping.WareHuoseId = UserWareHouseMappingDTO.WareHuoseId;
                    UserWareHouseMapping.UserId = UserWareHouseMappingDTO.UserId;
                    UserWareHouseMapping.CreatedBy = UserWareHouseMappingDTO.CreatedBy;
                    UserWareHouseMapping.CreatedDate = System.DateTime.Now;
                    var obj = _UserWareHouseMappingRepo.Insert(UserWareHouseMapping);
                    return MessageEnum.Success;

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
        public List<UserWareHouseMapping> UserWareHouseMappingList()
        {
            return _dbContext.UserWareHouseMappings
               .Include(s => s.User)
               .Include(s => s.WareHuose)
               .Where(x => x.Deleted == false).ToList();
        }
        public MessageEnum UserWareHouseMappingUpdate(UserWareHouseMappingDTO UserWareHouseMappingDTO)
        {
            try
            {
                var updateUserWareHouseMapping = _dbContext.UserWareHouseMappings.Where(x => x.UserWareHouseMappingId != UserWareHouseMappingDTO.UserWareHouseMappingId && x.UserId == UserWareHouseMappingDTO.UserId && x.WareHuoseId == UserWareHouseMappingDTO.WareHuoseId && x.Deleted == false).FirstOrDefault();

                if (updateUserWareHouseMapping == null)
                {
                    var a = _dbContext.UserWareHouseMappings.Where(x => x.UserWareHouseMappingId == UserWareHouseMappingDTO.UserWareHouseMappingId).FirstOrDefault();
                    if (a != null)
                    {
                        a.WareHuoseId = UserWareHouseMappingDTO.WareHuoseId;
                        a.UserId = UserWareHouseMappingDTO.UserId;
                        a.UpdatedBy = UserWareHouseMappingDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
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
        public UserWareHouseMapping UserWareHouseMappingById(int UserWareHouseMappingId)
        {
            return _dbContext.UserWareHouseMappings
                .Include(s => s.User)
                .Include(s => s.WareHuose)
                .Where(x => x.UserWareHouseMappingId == UserWareHouseMappingId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum UserWareHouseMappingDelete(int UserWareHouseMappingId, Int64 DeletedBy)
        {
            try
            {
                var UserWareHouseMapping = _dbContext.UserWareHouseMappings.SingleOrDefault(x => x.UserWareHouseMappingId == UserWareHouseMappingId);

                if (UserWareHouseMapping != null)
                {
                    UserWareHouseMapping.Deleted = true;
                    UserWareHouseMapping.UpdatedBy = DeletedBy;
                    UserWareHouseMapping.UpdatedDate = DateTime.Now;
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

        public UserWareHouseMapping GetWareHouseByUserId(Int64 UserId)
        {
            return _dbContext.UserWareHouseMappings
                     .Include(s => s.WareHuose)
                     .Include(s => s.User)
                     .Where(x => x.UserId == UserId && x.Deleted == false).SingleOrDefault();
        }
        public UserWareHouseMapping GetListWareHouseByUserId(Int64 UserId)
        {
            return _dbContext.UserWareHouseMappings
                     .Include(s => s.WareHuose)
                     .Include(s => s.User)
                     .Where(x => x.UserId == UserId && x.Deleted == false).SingleOrDefault();
        }

        public List<UserWareHouseMapping> GetWareHouseByWareHuoseId(Int64 WareHuoseId)
        {
            return _dbContext.UserWareHouseMappings
                    .Include(s => s.WareHuose)
                    .Include(s => s.User)
                    .Where(x => x.WareHuoseId == WareHuoseId && x.Deleted == false).ToList();
        }
    }
}
