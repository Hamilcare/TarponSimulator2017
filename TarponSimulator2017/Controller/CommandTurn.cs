using System;
using Tarpon.Controller;
using Tarpon.Core;
using Tarpon.Utils;

namespace Tarpon.Controller
{
	public class CommandTurn : Command
	{
		Boat boat;
		Direction direction;

		public CommandTurn (Boat b, Direction d)
		{
			boat = b;
			direction = d;
		}

		public void execute()
		{
			boat.Turn (direction);
		}
	}
}

