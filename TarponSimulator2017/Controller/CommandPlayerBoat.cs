using System;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public abstract class CommandPlayerBoat : Command
	{

		protected Boat boat;

		public CommandPlayerBoat (Boat boat)
		{
			this.boat = boat;
		}

		public void execute()
		{
			
		}
	}
}

