using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tarpon.Core
{
	public class Boat : Physics, IUpdatable
	{

		public  const float FrictionForceBoat = 0.0010f;
		public  const float AccelerationForceBoat = 0.0005f;
		public  const float TurnSpeedBoat = 0.0001f;
		public  const float MaxTurnAngleBoat = 0.02f;

		/// <summary>
		/// Gets or sets the fishing rod.
		/// </summary>
		/// <value>The fishing rod.</value>
		public FishingRod FishingRod{ get; private set; }

		/// <summary>
		/// Gets the list of fishes. The list is shared with the float and the world.
		/// </summary>
		/// <value>The list of fishes.</value>
		public IList<Fish> ListOfFishes { get; private set; }

		public Boat (int StartAbscisse, int StartOrdinate) : base (FrictionForceBoat, AccelerationForceBoat, TurnSpeedBoat, MaxTurnAngleBoat, StartAbscisse, StartOrdinate)
		{
			this.ListOfFishes = new List<Fish> ();
			this.FishingRod = new FishingRod (new Vector2 (0, -80), ListOfFishes);
			this.FishingRod.FrameOfReference = this;

		}


		public void Update (int now)
		{
			ComputeMovement (now);
			this.FishingRod.Update (this.RelativePosition, this.Orientation);
			foreach (Fish f in ListOfFishes) {
				f.Update (this.FishingRod.FishingFloat.AbsolutePosition, Vector2.Zero);
			}
		}

		public void Update (Vector2 vector, Vector2 anotherVector)
		{
			throw new Exception ("Unsupported Operation Exception");
		}
			


	}
}