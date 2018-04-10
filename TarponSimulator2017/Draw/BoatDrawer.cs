using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tarpon.Draw
{
	public class BoatDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Texture2D Texture;
		Rectangle TextureRegion;
		float RotationShift;

		public BoatDrawer (Core.Boat boat)
		{
			CoreBoat = boat;
			RotationShift = (float)Math.PI;
		}

		public void LoadContent (ContentManager content)
		{
			/*
			 * @FIXME: The spritesheet should be loaded in an external class
			 * Indeed, we'll use it for many other things
			 */
			Texture = content.Load<Texture2D> ("Content/img/spritesheet");
			TextureRegion = new Rectangle (204, 115, 66, 113);
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw (
				Texture,						// Texture of the boat 
				CoreBoat.AbsolutePosition, 		// Position 
				TextureRegion, 
				Color.White, 
				CoreBoat.AbsoluteOrientation + RotationShift, 
				new Vector2 (33, 0), 
				1, 
				SpriteEffects.None, 
				0); 
		}
	}
}


