using System;

namespace Tarpon.Core
{
	public class FishState
	{

		Fish relatedFish{ get; set; }

		public FishState (Fish f)
		{
			this.relatedFish = f;
		}
	}
}

