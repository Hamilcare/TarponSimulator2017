using System;
using System.Collections.Generic;
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

		/// <summary>
		/// The state of the list of accepted.
		/// If a state is accepted, the fishing line must be drawn
		/// </summary>
		IList<Type> ListOfAcceptedState;

		public FishingLineDrawer (Core.Boat Boat, Core.FishingRod FishingRod, GraphicsDevice gd)
		{
			this.CoreBoat = Boat;
			this.FishingRod = FishingRod;
			this.Texture = drawLine (gd);
			RotationShift = -(float)Math.PI / 2;
			this.FillAcceptedStateList ();
		}

		/// <summary>
		/// Fills the accepted state list.
		/// </summary>
		private void FillAcceptedStateList ()
		{
			this.ListOfAcceptedState = new List<Type> ();
			ListOfAcceptedState.Add (typeof(Core.RodStateHookedTheFish));
			ListOfAcceptedState.Add (typeof(Core.RodStateIdleInTheWater));
		}

		Texture2D drawLine (GraphicsDevice gd)
		{
			Texture2D Line = new Texture2D (gd, 1, 1, false, SurfaceFormat.Color);
			Line.SetData (new Color []{ Color.Black });
			return Line;
		}

		public void LoadContent (ContentManager content)
		{
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			if (this.ListOfAcceptedState.Contains (this.CoreBoat.FishingRod.CurrentState.GetType ())) {
				//30 = float radius
				int LineLenght = (int)((FishingRod.FishingFloat.AbsolutePosition - FishingRod.AbsolutePosition).Length () + 30);
				spriteBatch.Draw (
					Texture,
					FishingRod.AbsolutePosition,
					new Rectangle ((int)FishingRod.AbsolutePosition.X, (int)FishingRod.AbsolutePosition.Y, LineLenght, 1),
					Color.Black,
					this.CoreBoat.AbsoluteOrientation + RotationShift,
					Vector2.Zero,
					1.0f,
					SpriteEffects.None,
					0
				);

			}
		}
	}
}