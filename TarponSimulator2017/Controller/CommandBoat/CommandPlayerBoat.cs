using System;
using Tarpon.Core;
/// <summary>
/// Command player boat.
/// Mother class to every command related to the player boat
/// </summary>
namespace Tarpon.Controller
{
	public abstract class CommandPlayerBoat : ICommand
	{

		protected Boat boat;

		public CommandPlayerBoat (Boat boat)
		{
			this.boat = boat;
		}

		abstract public void execute();
	}
}

