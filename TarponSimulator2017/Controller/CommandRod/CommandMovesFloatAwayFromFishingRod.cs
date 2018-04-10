using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandMovesFloatAwayFromFishingRod : CommandRod
	{
		public CommandMovesFloatAwayFromFishingRod (FishingRod f) : base (f)
		{
		}

		override public void execute ()
		{
			FishingRod.MoveAwayFloat ();
		}
	}
}

