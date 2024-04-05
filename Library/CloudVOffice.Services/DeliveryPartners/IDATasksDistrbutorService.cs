﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.Distributor;

namespace CloudVOffice.Services.DeliveryPartners
{
	public interface IDATasksDistrbutorService
	{

		public Task<MessageEnum> CreateDATasksDistributor(DSODTO dSODTO);
		public List<DATasksDistributor> GetDistributorTaskListByAssignedCode(string assignedCode);

	}
}
