using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class RodStateHookedTheFish : RodState
	{
		const int STEP = 1;

		public RodStateHookedTheFish (FishingRod Rod) : base (Rod)
		{
		}

		public override void MoveAwayFloat ()
		{
			this.Rod.FishingFloat.MoveAway (STEP);
		}

		public override void BringFloatCloser ()
		{
			this.Rod.FishingFloat.ComeCloser (STEP);
		}

		public override void ThrowOrGetBack ()
		{
			double distance = Vector2.Distance (this.Rod.FishingFloat.RelativePosition, Vector2.Zero);

			if (distance <= this.Rod.FishingFloat.MinimalDistance + 5) {			
				this.Rod.CurrentState = new RodStateReadyToLaunch (this.Rod);
				World.Instance.RemoveAFish (this.Rod.CaughtFish);
				this.Rod.CaughtFish = null;
			}
		}
	}
}

