using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandAccelerate : CommandPlayerBoat
	{

		public CommandAccelerate (Boat boat) :base(boat)
		{
			Console.WriteLine ("Command Accelerate created");
		}

		override public void execute()
		{
			Console.WriteLine ("Command Accelerate execute triggered");
			boat.Accelerate();
		}
	}
}