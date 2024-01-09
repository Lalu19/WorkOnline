using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Months
{
    public class MonthService: IMonthService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Month> _monthRepo;

        public MonthService(ApplicationDBContext dbContext,
                                   ISqlRepository<Month> monthRepo

                                    )
        {
            _dbContext = dbContext;
            _monthRepo = monthRepo;

        }
        public MessageEnum MonthCreate(MonthDTO monthDTO)
        {
            try
            {
                var objcheck = _dbContext.Months.SingleOrDefault(opt => opt.Deleted == false && opt.MonthName == monthDTO.MonthName);
                if (objcheck == null)
                {
                    Month sc = new Month();
                    sc.MonthName = monthDTO.MonthName;
                    sc.CreatedBy = monthDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _monthRepo.Insert(sc);
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
        public List<Month> GetMonthList()
        {
            try
            {
                return _dbContext.Months.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum MonthUpdate(MonthDTO monthDTO)
        {
            try
            {
                var updateMonth = _dbContext.Months.Where(x => x.MonthId != monthDTO.MonthId && x.MonthName == monthDTO.MonthName && x.Deleted == false).FirstOrDefault();
                if (updateMonth == null)
                {
                    var a = _dbContext.Months.Where(x => x.MonthId == monthDTO.MonthId).FirstOrDefault();
                    if (a != null)
                    {
                        a.MonthName = monthDTO.MonthName;
                        a.UpdatedBy = monthDTO.CreatedBy;
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
        public Month GetMonthById(Int64 MonthId)
        {
            return _dbContext.Months.Where(x => x.MonthId == MonthId && x.Deleted == false).SingleOrDefault();
        }

        public MessageEnum MonthDelete(Int64 MonthId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Months.Where(x => x.MonthId == MonthId).FirstOrDefault();

                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

        public Int64 GetMonthIdByName(string Name)
        {
            var a = _dbContext.Months.FirstOrDefault(mon => mon.MonthName == Name);
            return a.MonthId;
        }

	}
}
