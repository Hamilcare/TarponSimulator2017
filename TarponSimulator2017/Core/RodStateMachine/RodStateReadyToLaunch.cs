using System;

namespace Tarpon.Core
{
	public class RodStateReadyToLaunch : RodState
	{
		const int STEP = 10;

		public RodStateReadyToLaunch (FishingRod Rod) : base (Rod)
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
			this.Rod.CurrentState = new RodStateIdleInTheWater (this.Rod);
		}
			


	}
}

