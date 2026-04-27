namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: UsrAdd3RentalsToYachtMethodsWrapper

	/// <exclude/>
	public class UsrAdd3RentalsToYachtMethodsWrapper : ProcessModel
	{

		public UsrAdd3RentalsToYachtMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			Guid yachtId = Get<Guid>("YachtId");
			
			if (yachtId == Guid.Empty) {
				return true;
			}
			
			DateTime startDate = DateTime.Now.AddDays(7);
			
			for (int i = 0; i < 3; i++) {
				DateTime endDate = startDate.AddDays(1);
			
				var rental = UserConnection.EntitySchemaManager
					.GetInstanceByName("UsrYachtRentals")
					.CreateEntity(UserConnection);
			
				rental.SetDefColumnValues();
				rental.SetColumnValue("UsrParentYacht", yachtId);
				rental.SetColumnValue("UsrStartDate", startDate);
				rental.SetColumnValue("UsrEndDate", endDate);
				rental.SetColumnValue("UsrCustomerId", "C4ED336C-3E9B-40FE-8B82-5632476472B4");
				rental.Save();
			
				startDate = endDate;
			}
			
			return true;
		}

		#endregion

	}

	#endregion

}

