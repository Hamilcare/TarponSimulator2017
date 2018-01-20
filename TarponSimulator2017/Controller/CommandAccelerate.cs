using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandAccelerate : Command
	{
		readonly Boat boat;

		public CommandAccelerate (Boat boat)
		{
			this.boat = boat;
		}

		public void execute()
		{
			boat.Accelerate();
		}
	}
}