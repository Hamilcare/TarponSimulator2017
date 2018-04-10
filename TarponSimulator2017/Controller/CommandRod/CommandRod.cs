using System;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public abstract class CommandRod : Command
	{
		public FishingRod FishingRod{ get; private set; }

		public CommandRod (FishingRod f)
		{
			this.FishingRod = f;
		}

		abstract public void execute ();
	}
}

