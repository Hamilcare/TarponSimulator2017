using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tarpon.Draw
{
	public class FishDrawer : IDrawer
	{

		Texture2D Texture;
		int radius = 30;

		float RotationShift = (float)Math.PI;
		Core.Fish fish;

		public FishDrawer (Core.Fish fish, GraphicsDevice gd)
		{
			this.fish = fish;
		}

		public void LoadContent (ContentManager content)
		{
			Texture = content.Load<Texture2D> ("Content/img/tarpon");
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw (
				Texture,						// Texture of the float
				fish.AbsolutePosition,		
				null, 
				Color.White, // Change lightening atmosphere
				this.fish.OrientationFloat () + this.RotationShift,  //Rotation
				new Vector2 (36, 50), //Shift 
				1, //Scale
				SpriteEffects.None, 
				0); //layerDepth
		}
	}
}

