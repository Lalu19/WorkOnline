using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.GSTs
{
    public class GSTService: IGSTService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<GST> _GSTRepo;
        public GSTService(ApplicationDBContext dbContext, ISqlRepository<GST> GSTRepo)
        {
            _dbContext = dbContext;
            _GSTRepo = GSTRepo;
        }
        public MessageEnum GSTCreate(GSTDTO gstDTO)
        {

            try
            {
                var objcheck = _dbContext.GSTs.SingleOrDefault(opt => opt.Deleted == false && opt.GSTValue == gstDTO.GSTValue);
                if (objcheck == null)
                {
                    GST sc = new GST();
                    sc.GSTValue = gstDTO.GSTValue;
                    sc.CreatedBy = gstDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _GSTRepo.Insert(sc);
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
        public List<GST> GetGSTList()
        {
            try
            {
                return _dbContext.GSTs.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        public GST GetGSTByGSTId(Int64 gstId)
        {
            return _dbContext.GSTs.Where(x => x.GSTId == gstId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum GSTUpdate(GSTDTO gstDTO)
        {
            try
            {
                var updateGST = _dbContext.GSTs.Where(x => x.GSTId != gstDTO.GSTId && x.GSTValue == gstDTO.GSTValue && x.Deleted == false).FirstOrDefault();
                if (updateGST == null)
                {
                    var a = _dbContext.GSTs.Where(x => x.GSTId == gstDTO.GSTId).FirstOrDefault();
                    if (a != null)
                    {
                        a.GSTValue = gstDTO.GSTValue;
                        a.UpdatedBy = gstDTO.CreatedBy;
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

        public MessageEnum GSTDelete(Int64 gstId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.GSTs.Where(x => x.GSTId == gstId).FirstOrDefault();
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


        public string GetGstForSeller(int SellerRegistrationId)
        {
            try
            {
                var a = _dbContext.SellerRegistrations.Where(s => s.SellerRegistrationId == SellerRegistrationId).Select(x => x.State).FirstOrDefault();                
                if (a != null)
                {
                    a = a.Trim();

                    if (a == "Odisha")
                    {
                        return a;
                    }
                }
                else
                {
                    return null;
                }

                return null;

            }
            catch
            {
                throw;
            }
        }
        
    }
}
