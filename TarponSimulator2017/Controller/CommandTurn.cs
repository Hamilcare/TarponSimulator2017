using System;
using Tarpon.Controller;
using Tarpon.Core;
using Tarpon.Utils;

namespace Tarpon.Controller
{
	public class CommandTurn : CommandPlayerBoat
	{
		Direction direction;

		public CommandTurn (Boat b, Direction d):base(b)
		{
			
			direction = d;
		}


		override public void execute()
		{
			boat.Turn (direction);
		}
	}
}

