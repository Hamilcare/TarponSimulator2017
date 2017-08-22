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

		public Vector Position
		{
			get { return _position; }
			set { _position = value; }
		}
		protected Vector _position;

		protected Vector Direction
		{
			get { return _direction; }
			set { _direction = value; }
		}
		protected Vector _direction;

		public int Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}
		protected int _speed;

		public void Initialize()
		{
			_position = new Vector(0,0);
			_direction = new Vector(1,1);
			_speed = 0;

		}

		public void HandleInput(KeyboardState _keyboardState,KeyboardState _oldKeyboardState ,MouseState mouseState)
		{


			if (_keyboardState.IsKeyDown(Keys.Up))
			{
				this._position.Y-=_speed;
			}
			else if (_keyboardState.IsKeyDown(Keys.Down))
			{
				this._position.Y+=_speed;
			}

			if (_keyboardState.IsKeyDown(Keys.Right))
			{
				this._position.X+=_speed;
			}
			else if (_keyboardState.IsKeyDown(Keys.Left))
			{
				this._position.X-=Speed;
			}

			if(_keyboardState.IsKeyDown(Keys.A))
			{
				this._speed++;
			}

			if(_keyboardState.IsKeyDown(Keys.Q))
			{
				this._speed--;
			}


		}

	}
}