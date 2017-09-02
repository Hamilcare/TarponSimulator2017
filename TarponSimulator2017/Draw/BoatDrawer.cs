using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw
{
	public class BoatDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Texture2D Texture;
		string filename;

		public BoatDrawer(Core.Boat boat)
		{
			CoreBoat = boat;
			this.filename = "Content/boat.png";
		}

		public void LoadContent(GraphicsDevice graphics)
		{
			Texture = Utils.PictureLoader.LoadPicture(graphics, filename);
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(
				Texture,						// Texture of the boat 
				CoreBoat.MotorPosition, 		// Position 
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

