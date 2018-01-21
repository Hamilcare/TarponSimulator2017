using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw
{
	public interface IDrawer
	{
		void LoadContent(ContentManager content);
		void Draw(SpriteBatch spriteBatch, GameTime gameTime);
	}
}
