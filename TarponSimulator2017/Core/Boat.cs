using System;
using System.IO;
using System.Collections;
using System.Windows;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace Core
{
	public class Boat
	{
		public float TurnAngleSpeed { get; private set; }
		public float TurnAngle { get; private set; }
		public Vector2 Orientation { get; private set; }
		
		public Vector2 Acceleration { get; private set; }
		public Vector2 Speed { get; private set; }
		public Vector2 MotorPosition { get; private set; }

		public Vector2 CentralPosition { get; private set; }

		public const float FrictionForce = 0.0015f;
		public const float AccelerationForce = 0.001f;
		public const float TurnSpeed = 0.0001f;
		public const float MaxTurnAngle = 0.8f;

		int elapsedTime; // in milliseconds

		public Boat()
		{
			CentralPosition = new Vector2(200, 300);
			MotorPosition = new Vector2(200, 363);
			Orientation = new Vector2(0, -1);
		}

		public float OrientiationFloat()
		{
			return (float)Math.Atan2(Orientation.X, -Orientation.Y);
		}

		public void HandleInput(KeyboardState _keyboardState,KeyboardState _oldKeyboardState ,MouseState mouseState)
		{
			// Init
			Acceleration = new Vector2(0, 0);
			TurnAngleSpeed = 0f;

			if (_keyboardState.IsKeyDown(Keys.Up))
			{
				Acceleration = Orientation * AccelerationForce;
			}
			else if (_keyboardState.IsKeyDown(Keys.Down))
			{
				//You cannot really brake on a boat, you have to reverse the engine rotation
			}

			if (_keyboardState.IsKeyDown(Keys.Right))
			{
				TurnAngleSpeed = TurnSpeed;
			}
			else if (_keyboardState.IsKeyDown(Keys.Left))
			{
				TurnAngleSpeed = -TurnSpeed;
			}
		}

		private void ComputeMovement(GameTime gameTime)
		{
			int now = gameTime.ElapsedGameTime.Milliseconds;
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
			Vector2 newOrientiation = Vector2.Normalize(Speed);
			if (!float.IsNaN(newOrientiation.X) && !float.IsNaN(newOrientiation.Y)) Orientation = newOrientiation;

			//Matrix.CreateFromAxisAngle();
		}

		public void Update(GameTime gameTime,KeyboardState keyboardState,KeyboardState oldKeyboardState ,MouseState mouseState){
			HandleInput (keyboardState, oldKeyboardState, mouseState);
			ComputeMovement(gameTime);
		}
	}
}