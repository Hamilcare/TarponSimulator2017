using System;
using System.IO;
using System.Collections;
using System.Windows;

using Microsoft.Xna.Framework.Input;

namespace Core
{
	public class Boat
	{
		public Boat ()
		{
		}

		public Vector Position { get; private set; }

		public Vector Direction { get; private set; }

		public int Speed { get; private set;}

		public void Initialize()
		{
			Position = new Vector(0,0);
			Direction = new Vector(1,1);
			Speed = 0;

		}

		public void HandleInput(KeyboardState _keyboardState,KeyboardState _oldKeyboardState ,MouseState mouseState)
		{


			if (_keyboardState.IsKeyDown(Keys.Up))
			{
				this.Position=new Vector(this.Position.X,this.Position.Y-Speed);
			}
			else if (_keyboardState.IsKeyDown(Keys.Down))
			{
				this.Position=new Vector(this.Position.X,this.Position.Y+Speed);
			}

			if (_keyboardState.IsKeyDown(Keys.Right))
			{
				this.Position=new Vector(this.Position.X+Speed,this.Position.Y);
			}
			else if (_keyboardState.IsKeyDown(Keys.Left))
			{
				this.Position=new Vector(this.Position.X-Speed,this.Position.Y);
			}

			if(_keyboardState.IsKeyDown(Keys.A) && !_oldKeyboardState.IsKeyDown(Keys.A))
			{
				this.Speed++;
			}

			if(_keyboardState.IsKeyDown(Keys.Q) && !_oldKeyboardState.IsKeyDown(Keys.Q) && this.Speed>0)
			{
				this.Speed--;
			}


		}

	}
}