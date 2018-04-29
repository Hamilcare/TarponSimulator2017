using System;
using Tarpon.Controller;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public class CommandThrowOrGetBack : CommandRod
	{
		public CommandThrowOrGetBack (FishingRod f) : base (f)
		{
		}

		override public void execute ()
		{
			FishingRod.CurrentState.ThrowOrGetBack ();
		}
	}
}

