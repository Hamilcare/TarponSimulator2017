using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tarpon.Core
{
	public class FishingRod : GameObject, IUpdatable
	{

		public RodState CurrentState{ get; set; }

		/// <summary>
		/// Gets the fishing float.
		/// </summary>
		/// <value>The fishing float.</value>
		public FishingFloat FishingFloat { get; private set; }

		/// <summary>
		/// Gets the list of fishes.
		/// </summary>
		/// <value>The list of fishes.</value>
		public IList<Fish> ListOfFishes { get; private set; }

		/// <summary>
		/// Gets or sets the caught fish.
		/// </summary>
		/// <value>The caught fish.</value>
		public Fish CaughtFish { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tarpon.Core.FishingRod"/> class.
		/// </summary>
		/// <param name="Position">Position. !! Must be given in parent's frame of reference. !!</param>
		public FishingRod (Vector2 Position, IList<Fish> ListOfFishes)
		{
			this.RelativePosition = Position;
			this.FishingFloat = new FishingFloat (Position);
			this.FishingFloat.FrameOfReference = this;
			this.CurrentState = new RodStateReadyToLaunch (this);
			this.ListOfFishes = ListOfFishes;
		}

		/// <summary>
		/// Update Float using elapsed time.
		/// Unsupported ATM.
		/// </summary>
		/// <param name="now">Now.</param>
		public void Update (int now)
		{
			throw new Exception ("Unsupported Operation Exception");
		}


		/// <summary>
		/// Update the rod using boatPosition.
		/// ATM the rod cannot move, hence rod Position and boat
		/// CentralPosition are considered equals
		/// </summary>
		/// <param name="boatPosition">Boat position.</param>
		public void Update (Vector2 boatPosition, Vector2 boatOrientation)
		{
			this.FishingFloat.Update (this.RelativePosition, boatOrientation);
			if (this.CurrentState.GetType () == typeof(RodStateIdleInTheWater)) {
				this.CheckIfFishCanCatchTheHook ();
			}
		}

		/// <summary>
		/// Checks if A fish can catch the hook.
		/// </summary>
		public void CheckIfFishCanCatchTheHook ()
		{
			foreach (Fish f in this.ListOfFishes) {
				if (this.FishingFloat.IsFishCanCatchTheHook (f)) {
					this.CurrentState = new RodStateHookedTheFish (this);
					Console.WriteLine ("MANG2");
					this.CaughtFish = f;
					break;
				}
			}
		}
	}
}

