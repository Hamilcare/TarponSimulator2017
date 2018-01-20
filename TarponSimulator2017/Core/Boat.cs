using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class Boat : IUpdatable
	{
		public enum Direction { Left = -1, Right = 1 }

		public float TurnAngleSpeed { get; private set; }
		public float TurnAngle { get; private set; }
		public Vector2 Orientation { get; private set; }
		
		public Vector2 Acceleration { get; private set; }
		public Vector2 Speed { get; private set; }
		public Vector2 MotorPosition { get; private set; }

		public Vector2 CentralPosition { get; private set; }

		public const float FrictionForce = 0.0010f;
		public const float AccelerationForce = 0.0005f;
		public const float TurnSpeed = 0.0001f;
		public const float MaxTurnAngle = 0.02f;

		int elapsedTime; // in milliseconds

		public Boat()
		{
			CentralPosition = new Vector2(200, 300);
			MotorPosition = new Vector2(200, 300);
			Orientation = new Vector2(0, -1);
		}

		public float OrientiationFloat()
		{
			return (float)Math.Atan2(Orientation.X, -Orientation.Y);
		}

		public void Update(int now)
		{
			ComputeMovement(now);

			// Init
			Acceleration = new Vector2(0, 0);
			TurnAngleSpeed = 0f;
		}

		public void Accelerate()
		{
			Acceleration = Orientation * AccelerationForce;
		}

		public void Turn(Direction d)
		{
			TurnAngleSpeed = (int)d * TurnSpeed;
		}

		void ComputeMovement(int now)
		{
			int interval = now - elapsedTime;
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
			MotorPosition += Speed * elapsedTime;

			// Update orientation
			Vector2 newOrientation = Vector2.Normalize(Speed);
			if (!float.IsNaN(newOrientation.X) && !float.IsNaN(newOrientation.Y)) Orientation = newOrientation;

			//Matrix.CreateFromAxisAngle();
		}
	}
}