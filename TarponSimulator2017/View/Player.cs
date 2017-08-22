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
        protected Texture2D[] _tab_chiffre;

		public void Initialize(Boat boat)
		{
			this.boat = boat;
            _tab_chiffre = new Texture2D[10];
		}


		public override void LoadContent(GraphicsDevice graphics, string filename)
		{
			this._texture = LoadPicture(graphics, filename);
            for (int i = 0; i < 10;i++){
                _tab_chiffre[i] = LoadPicture(graphics,"Content/" + i + ".png");
            }
		}


		public  void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(_texture, new Vector2((float)boat.Position.X,(float)boat.Position.Y), Color.White);
			printSpeed (spriteBatch);
		}

		private void printSpeed(SpriteBatch spriteBatch){
			String speed = boat.Speed.ToString();
			for (int i = 0; i < speed.Length; i++) {
				char current = speed[i];
				if ((int)Char.GetNumericValue(current) < 0)
					current = '0';
				Console.Write (current);
				spriteBatch.Draw (_tab_chiffre [(int)Char.GetNumericValue(current)], new Vector2 ( i * 256.0f, 0.0f), Color.White);
			}



		}


	}
}

