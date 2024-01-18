using Web.API.DTO;

namespace Web.API.Model.Buyers
{
	public interface IBuyerProvider
    {
        public BuyerViewModel BuyerregCreate(BuyerNewDTO buyerNewDTO);
    }
}
