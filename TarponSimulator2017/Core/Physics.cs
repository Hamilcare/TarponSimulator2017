using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{

	public class Physics
	{
		public enum Direction { Left = -1, Right = 1 }

		public float FrictionForce{ get; private set; }
		public float AccelerationForce{ get; private set; }
		public float TurnSpeed{ get; private set; }
		public float MaxTurnAngle{ get; private set; }

		public Vector2 Orientation { get; private set; }

		/** Est recalculé à chaque tour **/
		public Vector2 Acceleration { get; private set; }


		public Vector2 Speed { get; private set; }


		public Vector2 CentralPosition { get; private set; }


		/**Le point de l'objet où la physique s'applique**/
		public Vector2 ApplicationPoint { get; private set; }


		public float TurnAngleSpeed { get; private set; }


		public float TurnAngle { get; private set; }


		int elapsedTime; // in milliseconds


		public Physics(){
		}

		public Physics (float FrictionForce, float AccelerationForce, float TurnSpeed, float MaxTurnAngle,
			int AbscisseDepart, int OrdonneeDepart	)
		{
			this.FrictionForce = FrictionForce;
			this.AccelerationForce = AccelerationForce;
			this.TurnSpeed = TurnSpeed;
			this.MaxTurnAngle = MaxTurnAngle;

			CentralPosition = new Vector2 (AbscisseDepart, OrdonneeDepart);
			ApplicationPoint = new Vector2 (AbscisseDepart, OrdonneeDepart);

			Orientation = new Vector2(0, -1);



		}

		public float OrientiationFloat()
		{
			return (float)Math.Atan2(Orientation.X, -Orientation.Y);
		}

		public void Accelerate()
		{
			Acceleration = Orientation * AccelerationForce;
		}

		public void Turn(Direction d)
		{
			TurnAngleSpeed = (int)d * TurnSpeed;
		}

		public void ComputeMovement(int now)
		{
				
			elapsedTime = now;

			// Friction
			Acceleration += -Speed * FrictionForce;

			// Compute TurnAngle
			if (Math.Abs(TurnAngleSpeed) < float.Epsilon && Math.Abs(TurnAngle) > float.Epsilon)
			{
				int sign = TurnAngle > 0 ? 1 : -1;
				TurnAngle -= elapsedTime * sign * TurnSpeed;
				int newSign = TurnAngle > 0 ? 1 : -1;
				TurnAngle = sign == newSign ? TurnAngle : 0f; // We don't want to flip between left and right
			}
			else
			{
				TurnAngle += elapsedTime * TurnAngleSpeed;
			}

			// Apply limitations to turn angle
			TurnAngle = Math.Max(Math.Min(TurnAngle, MaxTurnAngle), -MaxTurnAngle);

			// Update old speed according to turn angles 
			Speed = Vector2.Transform(Speed, Matrix.CreateRotationZ(TurnAngle));

			// Add the new acceleration to the speed
			Speed += Acceleration* elapsedTime;

			// Add the new speed to the position
			ApplicationPoint += Speed * elapsedTime;

			// Update orientation
			Vector2 newOrientation = Vector2.Normalize(Speed);
			if (!float.IsNaN(newOrientation.X) && !float.IsNaN(newOrientation.Y)) Orientation = newOrientation;
	
			//Must be reset at the end of computation
			Acceleration = new Vector2(0, 0);
			TurnAngleSpeed = 0f;
		}
	}
}

