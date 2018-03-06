using System;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandBringCloser : CommandFishingRod
	{
		public CommandBringCloser (FishingRod FishingRod) :base(FishingRod)
		{
		}

		override public void execute(){
			FishingRod.bringCloserFloat ();
		}
	}
}

