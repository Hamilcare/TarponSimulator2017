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
		public Boat ()
		{
		}

		public Vector PositionFront { get; private set; }

		public Vector PositionRear { get; private set; }

		public Vector Direction { get; private set; }

		public double Speed { get; private set;}

		public double MaxSpeed{ get; private set; }

		public double Friction{ get; set; }//Could be changed by weather or ect...

		public void Initialize()
		{
			PositionFront = new Vector(100,100);
			PositionRear = new Vector (100, 150);
			Direction = Vector.Subtract(PositionFront,PositionRear);
			Direction.Normalize ();
			Speed = 0;
			MaxSpeed = 0.1;
			Friction = 0.98;
		}

		public void HandleInput(KeyboardState _keyboardState,KeyboardState _oldKeyboardState ,MouseState mouseState)
		{
			if (_keyboardState.IsKeyDown(Keys.Up))
			{
				if (Speed < MaxSpeed) Speed+=0.01;
			}
			else if (_keyboardState.IsKeyDown(Keys.Down))
			{
				//You cannot really brake on a boat, you have to reverse the engine rotation
			}

			if (_keyboardState.IsKeyDown(Keys.Right))
			{
				PositionRear = rotateVector(PositionFront,(float)(Math.PI*1/180),PositionRear);
			}
			else if (_keyboardState.IsKeyDown(Keys.Left))
			{
				PositionRear = rotateVector(PositionFront,(float)(Math.PI*-1/180),PositionRear);
			}
		}

		private double handleFriction(){
			double newSpeed = Speed * Friction;
			if (newSpeed<0.00001)
				newSpeed = 0.0;
			return newSpeed;
		}

		//Rotate target Vector around axe by angle in radians
		private Vector rotateVector(Vector axe, float angle, Vector target){
			double xnew = Math.Cos(angle) * (target.X - axe.X) - Math.Sin(angle) *(target.Y-axe.Y) + axe.X;
			double ynew = Math.Sin(angle) * (target.X-axe.X) + Math.Cos(angle)*(target.Y-axe.Y) + axe.Y;
			return new Vector(xnew,ynew);
		}

		public void Update(GameTime gameTime,KeyboardState keyboardState,KeyboardState oldKeyboardState ,MouseState mouseState){
			//PositionFront = Vector.Add (PositionFront,Direction);
			Direction = Vector.Subtract(PositionFront,PositionRear);
			Direction.Normalize ();
			PositionFront = Vector.Add (PositionFront, Direction*Speed);
			PositionRear = Vector.Add (PositionRear, Direction*Speed);
			Speed = handleFriction();
			HandleInput (keyboardState, oldKeyboardState, mouseState);
		}
	}
}