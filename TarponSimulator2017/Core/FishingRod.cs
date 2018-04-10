using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class FishingRod : GameObject, IUpdatable
	{
		/// <summary>
		/// Gets the fishing float.
		/// </summary>
		/// <value>The fishing float.</value>
		public FishingFloat FishingFloat { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tarpon.Core.FishingRod"/> class.
		/// </summary>
		/// <param name="Position">Position. !! Must be given in parent's frame of reference. !!</param>
		public FishingRod (Vector2 Position)
		{
			this.RelativePosition = Position;
			this.FishingFloat = new FishingFloat (Position);
			this.FishingFloat.FrameOfReference = this;

		}

		/// <summary>
		/// Update Float using elapsed time.
		/// Unsupported ATM.
		/// </summary>
		/// <param name="now">Now.</param>
		public void Update (int now)
		{
			throw new Exception ("Unsupported Operation Exception");
		}


		/// <summary>
		/// Update the rod using boatPosition.
		/// ATM the rod cannot move, hence rod Position and boat
		/// CentralPosition are considered equals
		/// </summary>
		/// <param name="boatPosition">Boat position.</param>
		public void Update (Vector2 boatPosition, Vector2 boatOrientation)
		{
			this.FishingFloat.Update (this.RelativePosition, boatOrientation);
		}

		public void MoveAwayFloat ()
		{
			FishingFloat.MoveAway ();
		}

		public void BringFloatCloser ()
		{
			FishingFloat.ComeCloser ();
		}
	}
}

