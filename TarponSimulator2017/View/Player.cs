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


		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{

			//float RotationAngle = (float) Math.PI;

			spriteBatch.Draw(Texture, Boat.MotorPosition, null, Color.AliceBlue, Boat.OrientiationFloat(), new Vector2(34, 0), 1, SpriteEffects.None, 0);
			//spriteBatch.Draw(Texture, Boat.CentralPosition(), null, null, RotationAngle, null, null, null, 0);
		}
	}
}

