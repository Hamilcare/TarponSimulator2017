using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tarpon.Draw
{
	public class BoatDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Texture2D Texture;

		public BoatDrawer(Core.Boat boat)
		{
			CoreBoat = boat;
		}

		public void LoadContent(ContentManager content)
		{
			Texture = content.Load<Texture2D> ("Content/Sprites/boat");
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(
				Texture,						// Texture of the boat 
				CoreBoat.ApplicationPoint, 		// Position 
				null, 
				Color.White, 
				CoreBoat.OrientiationFloat(), 
				new Vector2(34, 0), 
				1, 
				SpriteEffects.None, 
				0);
		}
	}
}


