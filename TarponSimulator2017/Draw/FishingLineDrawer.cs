using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw
{
	public class FishingLineDrawer : IDrawer
	{
		Core.Boat CoreBoat;
		Core.FishingRod FishingRod;
		Texture2D Texture;
		float RotationShift;

		public FishingLineDrawer (Core.Boat Boat, Core.FishingRod FishingRod, GraphicsDevice gd)
		{
			this.CoreBoat = Boat;
			this.FishingRod = FishingRod;
			this.Texture = drawLine (gd);
			RotationShift = -(float)Math.PI/2;
		}

		Texture2D drawLine(GraphicsDevice gd){
			Texture2D Line = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
			Line.SetData (new Color []{Color.Black});
			return Line;
		}

		public void LoadContent(ContentManager content)
		{
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			int LineLenght = (int)RodDrawer.printShift.Length () + (int)FishingRod.FishingFloatShift.X + (int)2.5*FishingFloatDrawer.radius;
			spriteBatch.Draw (
				Texture,
				FishingRod.Position,
				new Rectangle ((int)FishingRod.Position.X, (int)FishingRod.Position.Y, LineLenght,1),
				Color.Black,
				CoreBoat.OrientiationFloat() + RotationShift,
				Vector2.Zero,
				1.0f,
				SpriteEffects.None,
				0
			);
	
		}
		
	}
}

