using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandAccelerate : CommandPlayerBoat
	{

		public CommandAccelerate (Boat boat) :base(boat)
		{
		}

		new public void execute()
		{
			boat.Accelerate();
		}
	}
}