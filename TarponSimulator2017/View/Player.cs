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



		public Boat Boat { get; private set;}
		public Texture2D[] Tab_chiffre { get; private set;}

		public void Initialize(Boat boat)
		{
			this.Boat = boat;
            Tab_chiffre = new Texture2D[10];
		}


		public override void LoadContent(GraphicsDevice graphics, string filename)
		{
			this.Texture = LoadPicture(graphics, filename);
            for (int i = 0; i < 10;i++){
                Tab_chiffre[i] = LoadPicture(graphics,"Content/" + i + ".png");
            }
		}


		public  void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(Texture, new Vector2((float)Boat.Position.X,(float)Boat.Position.Y), Color.White);
			printSpeed (spriteBatch);
		}

		private void printSpeed(SpriteBatch spriteBatch){
			String speed = Boat.Speed.ToString();
			for (int i = 0; i < speed.Length; i++) {
				char current = speed[i];
				if ((int)Char.GetNumericValue(current) < 0)
					current = '0';
				Console.Write (current);
				spriteBatch.Draw (Tab_chiffre [(int)Char.GetNumericValue(current)], new Vector2 ( i * 256.0f, 0.0f), Color.White);
			}
		}


	}
}

