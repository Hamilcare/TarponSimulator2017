using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class Fish : Physics, IUpdatable
	{
		public const float FrictionForceFish = 0.0010f;
		public const float AccelerationForceFish = 0.0002f;
		public const float TurnSpeedFish = 0.0001f;
		public const float MaxTurnAngleFish = 0.02f;

		public Fish (int StartAbscisse, int StartOrdinate) : base (FrictionForceFish, AccelerationForceFish, TurnSpeedFish, MaxTurnAngleFish, StartAbscisse, StartOrdinate)
		{
			this.RelativePosition = new Vector2 (StartAbscisse, StartOrdinate);
		}

		public void Update (int now)
		{
			this.Accelerate ();
			this.ComputeMovement (now);
		}

		/// <summary>
		/// Update the Fish.
		/// </summary>
		/// <param name="FishingFloatPosition">Fishing float position,
		/// should be given in world frame of reference</param>
		/// <param name="anotherVector">Another vector.</param>
		public void Update (Vector2 FishingFloatPosition, Vector2 anotherVector)
		{
			this.Orientation = Vector2.Subtract (FishingFloatPosition, this.AbsolutePosition);
		}
	}
}

