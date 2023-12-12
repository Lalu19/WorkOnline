using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public class SectorService : ISectorService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Sector> _SectorRepo;
        public SectorService(ApplicationDBContext dbContext, ISqlRepository<Sector> SectorRepo)
        {
            _dbContext = dbContext;
            _SectorRepo = SectorRepo;
        }
        public MessageEnum SectorCreate(SectorDTO sectorDTO)
        {

            try
            {
                var objcheck = _dbContext.Sectors.SingleOrDefault(opt => opt.Deleted == false && opt.SectorName == sectorDTO.SectorName);
                if (objcheck == null)
                {
                    Sector sc = new Sector();
                    sc.SectorName = sectorDTO.SectorName;
                    sc.CreatedBy = sectorDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _SectorRepo.Insert(sc);
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
        public List<Sector> GetSectorList()
        {
            try
            {
                return _dbContext.Sectors.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }

        public List<Sector> GetSectorListforFarmerProduces()
        {
            try
            {
                return _dbContext.Sectors
                    .Where(x => x.SectorName == "Farmer Produces")
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public Sector GetSectorById(int SectorId)
        {
            return _dbContext.Sectors.Where(x => x.SectorId == SectorId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum SectorUpdate(SectorDTO sectorDTO)
        {
            try
            {
                var updateSector = _dbContext.Sectors.Where(x => x.SectorId != sectorDTO.SectorId && x.SectorName == sectorDTO.SectorName && x.Deleted == false).FirstOrDefault();
                if (updateSector == null)
                {
                    var a = _dbContext.Sectors.Where(x => x.SectorId == sectorDTO.SectorId).FirstOrDefault();
                    if (a != null)
                    {
                        a.SectorName = sectorDTO.SectorName;
                        a.UpdatedBy = sectorDTO.CreatedBy;
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

        public MessageEnum DeleteSector(int SectorId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Sectors.Where(x => x.SectorId == SectorId).FirstOrDefault();
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
    }
}
