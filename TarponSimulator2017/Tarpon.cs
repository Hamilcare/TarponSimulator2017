using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace TarponSimulator2017
{
	public class Tarpon : Sprite
	{
		public Tarpon ()
		{
		}

		public override void Initialize ()
		{
			_position = Vector2.Zero;
			_direction = Vector2.One;
			_speed = 1;
		}

		public override void Update (GameTime gameTime)
		{
			if( _position.X+this.Texture.Width > TarponGame.WIDTH || _position.X < 0){
				_direction.X *= -1;
			}
			if( _position.Y + this.Texture.Height > TarponGame.HEIGHT || _position.Y < 0){
				_direction.Y *= -1;
			}

			_position += _direction * Speed;
			
		}
	}
}

