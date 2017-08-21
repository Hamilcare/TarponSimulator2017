﻿using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace TarponSimulator2017
{
	public class Player : Sprite
	{
		public Player ()
		{
		}



		public override void HandleInput(KeyboardState _keyboardState, MouseState mouseState)
		{
			
			// On teste si les touches directionnelles sont enfoncées puis on modifie la position de Zozor en fonction de ça
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

