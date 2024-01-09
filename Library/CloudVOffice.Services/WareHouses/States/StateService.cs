using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.States;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.States
{
	public class StateService: IStateService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<State> _stateRepo;

		public StateService(ApplicationDBContext dbContext,
								   ISqlRepository<State> stateRepo

									)
		{
			_dbContext = dbContext;
			_stateRepo = stateRepo;

		}
		public MessageEnum StateCreate(StateDTO stateDTO)
		{
			try
			{
				var objcheck = _dbContext.States.SingleOrDefault(opt => opt.Deleted == false && opt.StateName == stateDTO.StateName);
				if (objcheck == null)
				{
					State sc = new State();
					sc.StateName = stateDTO.StateName;
					sc.CreatedBy = stateDTO.CreatedBy;
					sc.CreatedDate = System.DateTime.Now;
					var obj = _stateRepo.Insert(sc);
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
		public List<State> GetStateList()
		{
			try
			{
				return _dbContext.States.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum StateUpdate(StateDTO stateDTO)
		{
			try
			{
				var updateState = _dbContext.States.Where(x => x.StateId != stateDTO.StateId && x.StateName == stateDTO.StateName && x.Deleted == false).FirstOrDefault();
				if (updateState == null)
				{
					var a = _dbContext.States.Where(x => x.StateId == stateDTO.StateId).FirstOrDefault();
					if (a != null)
					{
						a.StateName = stateDTO.StateName;
						a.UpdatedBy = stateDTO.CreatedBy;
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
		public State GetStateById(Int64 StateId)
		{
			return _dbContext.States.Where(x => x.StateId == StateId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum StateDelete(Int64 StateId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.States.Where(x => x.StateId == StateId).FirstOrDefault();

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
