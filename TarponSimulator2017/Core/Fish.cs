using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	/// <summary>
	/// Fish.
	/// Should be abstract in the future
	/// </summary>
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

		/// <summary>
		/// Creates the random fish.
		/// </summary>
		/// <returns>The random fish.</returns>


		/// <summary>
		/// Changes the state to caught the hook if allowed.
		/// </summary>
		public void ChangeStateToCaughtTheHook ()
		{
			if (IsStateTransitionAllowed (typeof(FishStateCaughtTheHook))) {
				this.CurrentState = new FishStateCaughtTheHook (this);
			}
		}

		/// <summary>
		/// Determines whether this instance can set its current state to desired state
		/// </summary>
		/// <returns><c>true</c> if this instance can set is current state to desired state; otherwise, <c>false</c>.</returns>
		/// <param name="TypeOfNextState">Type of next state.</param>
		public Boolean IsStateTransitionAllowed (Type TypeOfNextState)
		{
			return true;
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

