using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.RetailerModel;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.RetailerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.RetailerModel
{
    public interface IRetailModelService
    {
        public MessageEnum RetailModelCreate(RetailModelDTO retailModelDTO);
        public List<RetailModel> GetRetailModelList();
        public MessageEnum RetailModelUpdate(RetailModelDTO retailModelDTO);
        public MessageEnum DeleteRetailModel(int RetailModelId, Int64 DeletedBy);
        public RetailModel GetRetailModelById(int RetailModelId);
    }
}
