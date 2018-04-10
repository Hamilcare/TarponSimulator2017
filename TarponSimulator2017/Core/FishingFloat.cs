using System;
using Microsoft.Xna.Framework;

/// <summary>
/// Fishing float.
/// Handle the behaviour of the fishing float.
/// </summary>

namespace Tarpon.Core
{
	public class FishingFloat : IUpdatable
	{
		/// <summary>
		/// Gets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector2 Position { get; private set; }

		/// <summary>
		/// Gets the old rod position.
		/// </summary>
		/// <value>The old rod position.</value>
		public Vector2 OldRodPosition{ get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tarpon.Core.FishingFloat"/> class.
		/// </summary>
		/// <param name="FishingRod">Fishing rod.</param>
		public FishingFloat (Vector2 FishingRodPosition)
		{
			this.Position = FishingRodPosition;
			this.OldRodPosition = FishingRodPosition;
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
			Console.WriteLine ("Updating Float");
			Console.WriteLine ("Rod Position: " + FishingRodPosition);

			Vector2 NewPosition = FishingRodPosition;

			if (NewPosition != OldRodPosition) {

				Vector2 RodDirection = Vector2.Normalize (boatOrientation);

				Console.WriteLine ("Direction: " + RodDirection);

				this.Position = FishingRodPosition + 140 * RodDirection;
				//this.Position = NewPosition;

				this.OldRodPosition = FishingRodPosition;
			}
		}


	}
}

