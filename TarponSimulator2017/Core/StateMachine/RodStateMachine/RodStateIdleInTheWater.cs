using System;

namespace Tarpon.Core
{
	public class RodStateIdleInTheWater : RodState
	{
	
		const int STEP = 2;

		public RodStateIdleInTheWater (FishingRod Rod) : base (Rod)
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
			this.Rod.CurrentState = new RodStateReadyToLaunch (this.Rod);
		}
	}
}

