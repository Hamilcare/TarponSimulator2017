using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw
{
	public interface IDrawer
	{
		void LoadContent(GraphicsDevice graphics);
		void Draw(SpriteBatch spriteBatch, GameTime gameTime);
	}
}
