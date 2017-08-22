using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

using Core;

namespace TarponSimulator2017
{
	public class Player : Sprite
	{
		public Player ()
		{
		}



		protected Boat boat;


		public virtual void Initialize(Boat boat)
		{
			this.boat = boat;
		}


		public  void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(_texture, new Vector2((float)boat.Position.X,(float)boat.Position.Y), Color.White);
		}

		private void printSpeed(SpriteBatch spriteBatch){
			int speed = boat.Speed;

		}


	}
}

