using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Tarpon.Core;
using System;

namespace Tarpon.Draw
{
	public class MapDrawer : IDrawer
	{
		Texture2D Texture;
		Rectangle TextureRegion;
		GraphicsDeviceManager Graphics;
		World CoreWorld;

		public MapDrawer (GraphicsDeviceManager graphics, World coreWorld)
		{
			CoreWorld = coreWorld;
			Graphics = graphics;
		}

		public void LoadContent (ContentManager content)
		{
			Texture = content.Load<Texture2D> ("Content/img/tilesheet");
			TextureRegion = new Rectangle (1024, 512, 128, 128);
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			int demiSquareSide = System.Math.Max (Graphics.PreferredBackBufferHeight, Graphics.PreferredBackBufferWidth);
			float startX = CoreWorld.playerBoat.AbsolutePosition.X - demiSquareSide;
			float startY = CoreWorld.playerBoat.AbsolutePosition.Y - demiSquareSide;

			for (float i = startX - startX % 128; i < startX+2*demiSquareSide; i += 128) {
				for (float j = startY - startY % 128; j < startY+2*demiSquareSide; j += 128) {
					spriteBatch.Draw (
						Texture,				    // Water PNG 
						new Vector2 (i, j), 		// Position 
						TextureRegion, 
						Color.White, 
						0f, 
						new Vector2 (0, 0), 
						1, 
						SpriteEffects.None, 
						0); 
				}
			}
		}
	}
}

