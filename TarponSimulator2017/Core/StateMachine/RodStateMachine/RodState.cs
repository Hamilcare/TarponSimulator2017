using System;

namespace Tarpon.Core
{
	public abstract class RodState
	{
		public FishingRod Rod { get; set; }

		public RodState (FishingRod Rod)
		{
			this.Rod = Rod;
		}

		/// <summary>
		/// Moves the float away.
		/// </summary>
		public abstract void MoveAwayFloat ();

		/// <summary>
		/// Brings the float closer.
		/// </summary>
		public abstract void BringFloatCloser ();

		/// <summary>
		/// Throws the or get back the float, depending of Rod's current State.
		/// </summary>
		public abstract void ThrowOrGetBack ();
	}
}

