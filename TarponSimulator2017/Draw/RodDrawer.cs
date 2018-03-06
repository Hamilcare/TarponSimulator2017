using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tarpon.Draw
{
	public class RodDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Texture2D Texture;
		float RotationShift;
		public static Vector2 printShift = new Vector2 (80, 250);//shit origin of draw to correctly place the fishing rod

		public RodDrawer (Core.Boat boat)
		{
			CoreBoat = boat;
		//	RotationShift = (float)Math.PI;
			RotationShift = 0;
		}

		public void LoadContent(ContentManager content)
		{
			Texture = content.Load<Texture2D> ("Content/img/fishing_resize");
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(
				Texture,						// Texture of the road 
				CoreBoat.fishingRod.Position, 		// Position
				null, 
				Color.White, 
				CoreBoat.OrientiationFloat() + RotationShift, 
				printShift,
				1, 
				SpriteEffects.None, 
				0); 
		}

	}
}

