using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class Fish : Physics, IUpdatable
	{


		public const float FrictionForceFish = 0.0010f;
		public const float AccelerationForceFish = 0.000001f;
		public const float TurnSpeedFish = 0.0000001f;
		public const float MaxTurnAngleFish = 0.00002f;

		public FishState CurrentState { get; private set; }

		public Fish (int StartAbscisse, int StartOrdinate) : base (FrictionForceFish, AccelerationForceFish, TurnSpeedFish, MaxTurnAngleFish, StartAbscisse, StartOrdinate)
		{
			this.RelativePosition = new Vector2 (StartAbscisse, StartOrdinate);
			this.CurrentState = new FishStateTriggered (this);
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

