using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class World : GameObject
	{
		public Boat playerBoat { get; private set; }

		public Fish FirstFish{ get; private set; }

		public List<IUpdatable> toUpdate { get; private set; }

		public static World UniqueInstance;

		public World ()
		{
			playerBoat = new Boat (200, 300);
			playerBoat.FrameOfReference = this;
			FirstFish = new Fish (400, 400);
			FirstFish.FrameOfReference = this;
			playerBoat.ListOfFishes.Add (FirstFish);
			toUpdate = new List<IUpdatable> ();
			toUpdate.Add (playerBoat);
			toUpdate.Add (FirstFish);

			UniqueInstance = this;
		}


		public static void RemoveAFish (Fish f)
		{
			UniqueInstance.playerBoat.FishingRod.CaughtFish = null;
			UniqueInstance.playerBoat.ListOfFishes.Remove (f);
			UniqueInstance.toUpdate.Remove (f);
		}

		public void Update (int now)
		{
			toUpdate.ForEach (tu => tu.Update (now));
			ComputeTree (this.TotalTransformation);
		}
	}
}
