﻿using System;
using Microsoft.Xna.Framework;
using Tarpon.Utils;

namespace Tarpon.Core
{

	public class Physics : GameObject
	{
		
		public float FrictionForce{ get; private set; }

		public float AccelerationForce{ get; private set; }

		public float TurnSpeed{ get; private set; }

		public float MaxTurnAngle{ get; private set; }

		public Vector2 Orientation { get; set; }

		/** computed each turn **/
		public Vector2 Acceleration { get; private set; }


		public Vector2 Speed { get; private set; }

		/**Le point de l'objet où la physique s'applique**/
		public Vector2 ApplicationPoint { get; private set; }


		public float TurnAngleSpeed { get; private set; }


		public float TurnAngle { get; private set; }

		public Physics ()
		{
		}

		public Physics (float FrictionForce, float AccelerationForce, float TurnSpeed, float MaxTurnAngle,
		                int AbscisseDepart, int OrdonneeDepart)
		{
			this.FrictionForce = FrictionForce;
			this.AccelerationForce = AccelerationForce;
			this.TurnSpeed = TurnSpeed;
			this.MaxTurnAngle = MaxTurnAngle;

			ApplicationPoint = new Vector2 (AbscisseDepart, OrdonneeDepart);

			Orientation = new Vector2 (0, -1);
		}

		public float OrientationFloat ()
		{
			return (float)Math.Atan2 (Orientation.X, -Orientation.Y);
		}

		public void Accelerate ()
		{
			Acceleration = Orientation * AccelerationForce;
		}

		public void Turn (Utils.Direction d)
		{
			TurnAngleSpeed = (int)d * TurnSpeed;
		}

		public void ComputeMovement (int elapsedTime)
		{
			
			// Friction
			Acceleration += -Speed * FrictionForce;

			/*
			 * Consequently the rotation speed of the boat
			 * depends of its speed 
			 */
			TurnSpeed = (Math.Abs (Speed.X) + Math.Abs (Speed.Y));


			// Compute TurnAngle
			if (Math.Abs (TurnAngleSpeed) < float.Epsilon && Math.Abs (TurnAngle) > float.Epsilon) {
				int sign = TurnAngle > 0 ? 1 : -1;
				TurnAngle -= elapsedTime * sign * TurnSpeed;
				int newSign = TurnAngle > 0 ? 1 : -1;
				TurnAngle = sign == newSign ? TurnAngle : 0f; // We don't want to flip between left and right
			} else {
				TurnAngle = elapsedTime * TurnAngleSpeed * TurnSpeed;
			}


			// Apply limitations to turn angle
			TurnAngle = Math.Max (Math.Min (TurnAngle, MaxTurnAngle), -MaxTurnAngle);

			// Update old speed according to turn angles 
			Speed = Vector2.Transform (Speed, Matrix.CreateRotationZ (TurnAngle));

			// Add the new acceleration to the speed
			Speed += Acceleration * elapsedTime;

			// Add the new speed to the position
			ApplicationPoint += Speed * elapsedTime;

			//Set Speed to zero under a certain limit
			if (Math.Abs (Speed.X) < float.Epsilon)
				Speed = new Vector2 (0, Speed.Y);
			if (Math.Abs (Speed.Y) < float.Epsilon)
				Speed = new Vector2 (Speed.X, 0);
				

			// Update orientation
			Vector2 newOrientation = Vector2.Normalize (Speed);
			if ((!float.IsNaN (newOrientation.X) && !float.IsNaN (newOrientation.Y)) &&
			    (Math.Abs (newOrientation.X) > float.Epsilon && Math.Abs (newOrientation.Y) > float.Epsilon)) {
				Orientation = newOrientation;
			}
	
			//Must be reset at the end of computation
			Acceleration = new Vector2 (0, 0);
			TurnAngleSpeed = 0f;

			//Using GameObject logic 
			this.RelativePosition = ApplicationPoint;
			this.RelativeOrientation = this.OrientationFloat ();
		}
	}
}

