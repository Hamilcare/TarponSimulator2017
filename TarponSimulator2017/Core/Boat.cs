﻿using System;
using Microsoft.Xna.Framework;

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


		public Boat (int StartAbscisse, int StartOrdinate) : base (FrictionForceBoat, AccelerationForceBoat, TurnSpeedBoat, MaxTurnAngleBoat, StartAbscisse, StartOrdinate)
		{
			this.FishingRod = new FishingRod (this.CentralPosition);
		}


		public void Update (int now)
		{
			ComputeMovement (now);
			this.FishingRod.Update (this.ApplicationPoint, this.Orientation);
		}

		public void Update (Vector2 vector, Vector2 anotherVector)
		{
			throw new Exception ("Unsupported Operation Exception");
		}
			


	}
}