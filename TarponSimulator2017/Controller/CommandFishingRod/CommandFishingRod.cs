using System;
using Tarpon.Core;
/// <summary>
/// Command fishing rod.
/// Mother class to every command related to the fishing rod
/// </summary>
namespace Tarpon.Controller
{
	abstract public class CommandFishingRod : ICommand
	{
		protected FishingRod FishingRod;
		public CommandFishingRod (FishingRod FishingRod)
		{
			this.FishingRod = FishingRod;
		}

		abstract public void execute();
	}
}