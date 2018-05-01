using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Tarpon.Core;

namespace Tarpon.Draw
{
	public class FishingFloatDrawer : IDrawer
	{
		Texture2D Texture;
		int radius = 30;
		Core.FishingFloat FishingFloat;
		Core.Boat Boat;
		float RotationShift = (float)Math.PI;

		public FishingFloatDrawer (Core.Boat b, Core.FishingFloat FishingFloat, GraphicsDevice gd)
		{
			this.Boat = b;
			this.FishingFloat = FishingFloat;
			this.Texture = createCircleText (radius, gd);
		}

		Texture2D createCircleText (int radius, GraphicsDevice gd)
		{
			Texture2D texture = new Texture2D (gd, radius, radius);
			Color[] colorData = new Color[radius * radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

			for (int x = 0; x < radius; x++) {
				for (int y = 0; y < radius; y++) {
					int index = x * radius + y;
					Vector2 pos = new Vector2 (x - diam, y - diam);
					if (pos.LengthSquared () <= diamsq) {
						colorData [index] = Color.White;
					} else {
						colorData [index] = Color.Transparent;
					}
				}
			}

			texture.SetData (colorData);
			return texture;
		}

		public void LoadContent (ContentManager content)
		{
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			Color color;
			if (this.Boat.FishingRod.CurrentState.GetType () == typeof(RodStateIdleInTheWater)) {
				color = Color.Green;
			} else if (this.Boat.FishingRod.CurrentState.GetType () == typeof(RodStateHookedTheFish)) {
				color = Color.Peru;
			} else {
				color = Color.Red;
			}

			spriteBatch.Draw (
				Texture,						// Texture of the float
				FishingFloat.AbsolutePosition,		
				null, 
				color, // Change lightening atmosphere
				this.Boat.AbsoluteOrientation + RotationShift,  //Rotation
				new Vector2 (15, -15), //Shift 
				1, //Scale
				SpriteEffects.None, 
				0); //layerDepth
		}


	}
}

