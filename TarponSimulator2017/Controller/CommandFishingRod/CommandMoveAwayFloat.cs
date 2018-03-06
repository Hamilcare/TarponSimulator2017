using System;
using Tarpon.Core;
/// <summary>
/// Command move away float.
/// Move away the float on key press
/// </summary>
namespace Tarpon.Controller
{
	public class CommandMoveAwayFloat : CommandFishingRod
	{

		public CommandMoveAwayFloat (FishingRod FishingRod): base(FishingRod)
		{
		}


		override public void execute(){
			FishingRod.moveAwayFloat ();
		}
	}
}

