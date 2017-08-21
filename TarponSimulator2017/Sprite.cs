using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace TarponSimulator2017
{
	public class Sprite
	{
		public Texture2D Texture
		{
			get { return _texture; }
			set { _texture = value; }
		}
		private Texture2D _texture;

		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}
		protected Vector2 _position;

		public Vector2 Direction
		{
			get { return _direction; }
			set { _direction = Vector2.Normalize(value); }
		}
		private Vector2 _direction;

		public float Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}
		private float _speed;

		public virtual void Initialize()
		{
			_position = Vector2.Zero;
			_direction = Vector2.Zero;
			_speed = 0;
		}


		public virtual void LoadContent(GraphicsDevice graphics, string filename)
		{
			this._texture = LoadPicture (graphics, filename);
		}


		public virtual void Update(GameTime gameTime)
		{
			_position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		}


		public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
		{
		}


		public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(_texture, _position, Color.White);
		}

				static public Texture2D LoadPicture(GraphicsDevice graphics, string Filename)
		{
			FileStream setStream = File.Open(Filename, FileMode.Open);
			//StreamReader reader = new StreamReader(setStream);
			Texture2D NewTexture = Texture2D.FromStream(graphics, setStream);
			setStream.Dispose();
			return NewTexture;
		}

	}



}

