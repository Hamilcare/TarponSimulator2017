using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class FishingRod : IUpdatable
	{
		/// <summary>
		/// Gets the fishing float.
		/// </summary>
		/// <value>The fishing float.</value>
		public FishingFloat FishingFloat { get; private set; }

		/// <summary>
		/// Position the specified .
		/// </summary>
		/// <param name="">.</param>
		public Vector2 Position { get; private set; }

		public FishingRod (Vector2 Position)
		{
			this.Position = Position;
			this.FishingFloat = new FishingFloat (this.Position);
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
			this.Position = new Vector2 (boatPosition.X, boatPosition.Y);
			this.FishingFloat.Update (this.Position, boatOrientation);
		}
	}
}

