using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandBringFloatCloser: CommandRod
	{
		public CommandBringFloatCloser (FishingRod f) : base (f)
		{
		}

		override public void execute ()
		{
			FishingRod.BringFloatCloser ();
		}
	}
}

