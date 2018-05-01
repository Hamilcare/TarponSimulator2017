using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tarpon.Draw
{
	public class MapDrawer : IDrawer
	{
		Texture2D Texture;
		Rectangle TextureRegion;
		int width;
		int height;

		public MapDrawer (int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public void LoadContent (ContentManager content)
		{
			Texture = content.Load<Texture2D> ("Content/img/tilesheet");
			TextureRegion = new Rectangle (1024, 512, 128, 128);
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			for (int i = 0; i < width; i += 128) {
				for (int j = 0; j < height; j += 128) {
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

