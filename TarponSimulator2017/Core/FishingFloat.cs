using System;
using Microsoft.Xna.Framework;

/// <summary>
/// Fishing float.
/// Handle the behaviour of the fishing float.
/// </summary>

namespace Tarpon.Core
{
	public class FishingFloat : GameObject, IUpdatable
	{
		/// <summary>
		/// minimal distance between rod and float
		/// </summary>
		public const int MINIMAL_DISTANCE = 15;

		/// <summary>
		/// maximal distance between rod and float
		/// </summary>
		public const int MAXIMAL_DISTANCE = 250;

		/// <summary>
		/// The current distance between the rod and the float
		/// </summary>
		public int CurrentDistance = MINIMAL_DISTANCE;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tarpon.Core.FishingFloat"/> class.
		/// </summary>
		/// <param name="StartPosition">Start position. !! Must be given in parent's frame of reference. !!</param>
		public FishingFloat (Vector2 StartPosition)
		{
			this.RelativePosition = StartPosition;
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
		/// Update the float using RodPosition.
		/// ATM, the float should always be aligned with the rod
		/// </summary>
		/// <param name="RodPosition">Rod position.</param>
		public void Update (Vector2 FishingRodPosition, Vector2 boatOrientation)
		{
			this.RelativePosition = new Vector2 (0, -CurrentDistance);
		}

		public void MoveAway (int step)
		{
			if (CurrentDistance + step <= MAXIMAL_DISTANCE) {
				this.CurrentDistance += step;
			} else {
				this.CurrentDistance = MAXIMAL_DISTANCE;
			}
		}

		public void ComeCloser (int step)
		{
			if (CurrentDistance - step >= MINIMAL_DISTANCE) {
				this.CurrentDistance -= step;
			} else {
				this.CurrentDistance = MINIMAL_DISTANCE;
			}
		}
	}
}

