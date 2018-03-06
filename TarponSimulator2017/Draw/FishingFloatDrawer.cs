using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw
{
	public class FishingFloatDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Texture2D Texture;
		public static int radius = 30;

		public FishingFloatDrawer (Core.Boat boat, GraphicsDevice gd)
		{
			CoreBoat = boat;
			Texture = this.createCircleText (radius, gd);
		}

		Texture2D createCircleText(int radius, GraphicsDevice gd)
		{
			Texture2D texture = new Texture2D(gd, radius, radius);
			Color[] colorData = new Color[radius*radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

			for (int x = 0; x < radius; x++)
			{
				for (int y = 0; y < radius; y++)
				{
					int index = x * radius + y;
					Vector2 pos = new Vector2(x - diam, y - diam);
					if (pos.LengthSquared() <= diamsq)
					{
						colorData[index] = Color.White;
					}
					else
					{
						colorData[index] = Color.Transparent;
					}
				}
			}

			texture.SetData(colorData);
			return texture;
		}


		public void LoadContent(ContentManager content)
		{
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(
				Texture,						// Texture of the float 
				CoreBoat.ApplicationPoint, 		// Position 
				null, 
				Color.Red, // Change lightening atmosphere
				CoreBoat.OrientiationFloat(), //Angle
				new Vector2(radius/2 , 250 + 3 * radius + CoreBoat.fishingRod.FishingFloatShift.Y), //shift //250 = rod length
				1, //Scale
				SpriteEffects.None, // Flip or not the sprite
				0); //layer Depth
		}
	}
}

