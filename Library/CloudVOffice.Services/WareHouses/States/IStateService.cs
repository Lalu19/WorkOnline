using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.States
{
	public interface IStateService
	{
		public MessageEnum StateCreate(StateDTO stateDTO);
		public State GetStateById(Int64 StateId);
		public List<State> GetStateList();
		public MessageEnum StateUpdate(StateDTO stateDTO);
		public MessageEnum StateDelete(Int64 StateId, Int64 DeletedBy);
	}
}
