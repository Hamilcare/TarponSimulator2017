using System;
using System.IO;
using System.Windows;

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



		public Boat Boat; 
		public Texture2D[] Tab_chiffre { get; private set;}
		public Texture2D SpriteTexture { get; private set;}
		public Vector2 origin;
		public Vector2 screenpos;

		public void Initialize(Boat boat)
		{
			this.Boat = boat;
            Tab_chiffre = new Texture2D[10];
			origin = new Vector2();
			screenpos = new Vector2();
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
			
			float RotationAngle = (float)(((Vector.AngleBetween (Boat.Direction, new Vector (0.0, 1.0))) * Math.PI / 180.0)-Math.PI);

			if (Boat.Direction.X >= 0)//Because AngleBetween give an answer between 0 and pi
				RotationAngle*=-1;

			spriteBatch.Draw (Texture,
				new Vector2 ((float)Boat.PositionFront.X + Texture.Width/2, (float)Boat.PositionFront.Y),
				null,
				null,
				null,
				RotationAngle,
				null,
				null);
			
//			printSpeed (spriteBatch);
			Console.WriteLine(Boat.Direction);
			Console.WriteLine (RotationAngle);
			Console.WriteLine (Boat.Speed);
		}

		private void printSpeed(SpriteBatch spriteBatch){
			String speed = (Boat.Speed * 100).ToString ();
			if (Boat.Speed > 0)
				speed = speed.Substring (0, 2);


			for (int i = 0; i < speed.Length; i++) {
				char current = speed[i];
				if ((int)Char.GetNumericValue(current) < 0)
					current = '0';
				Console.Write (current);
				spriteBatch.Draw (Tab_chiffre [(int)Char.GetNumericValue(current)], new Vector2 ( i * 96.0f, 0.0f), Color.White);
			}
		}


	}
}

