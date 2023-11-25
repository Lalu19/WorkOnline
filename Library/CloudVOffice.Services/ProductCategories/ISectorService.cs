using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudVOffice.Services.ProductCategories
{
    public interface ISectorService
    {
        public MessageEnum SectorCreate(SectorDTO sectorDTO);
        public MessageEnum SectorUpdate(SectorDTO sectorDTO);
        public MessageEnum DeleteSector(int SectorId, Int64 DeletedBy);
        public List<Sector> GetSectorList();
        public Sector GetSectorById(int SectorId);
    }
}
