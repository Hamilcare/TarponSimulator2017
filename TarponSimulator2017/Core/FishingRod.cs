using System;
using Microsoft.Xna.Framework;
/// <summary>
/// Fishing rod.
/// Handle all the fishing rod behaviour
/// </summary>
namespace Tarpon.Core
{
	public class FishingRod
	{
		/// <summary>
		/// Rod position, for now should be equals to boat central position
		/// </summary>
		public Vector2 Position { get; private set; }

		/// <summary>
		/// The shift between the float and the rod
		/// </summary>
		public Vector2 FishingFloatShift { get; private set; } //ATM x_shift is not use

		/// <summary>
		/// The shift applied to the float each time his position is updated.
		/// </summary>
		public const float Shift = 5.0f;

		/// <summary>
		/// The minimal distance between float and boat.
		/// those hard coded values are dependant from the rod sprite which is
		///definitly a bad idea. How could we change that ?
		/// </summary>
		public Vector2 MinimalFloatDistance = new Vector2 (-60, -60);

		/** Builders **/
		public FishingRod (float abscisse, float ordinate)
		{
			Position = new Vector2 (abscisse, ordinate);
			FishingFloatShift = new Vector2 (150,150);
		}

		public FishingRod (Vector2 pos){
			Position = pos;
			FishingFloatShift = new Vector2 (150, 150);
		}


		public void updatePosition(Vector2 newPos){
			Position= newPos;
		}


		public void updatePosition(float abs, float ord){
			Position = new Vector2 (abs, ord);
		}


		public void moveAwayFloat(){
			this.FishingFloatShift = FishingFloatShift + new Vector2 (Shift, Shift);
		}

		public void bringCloserFloat(){
			this.FishingFloatShift = Vector2.Max(MinimalFloatDistance, FishingFloatShift - new Vector2 (Shift, Shift));
		}


	}
}

