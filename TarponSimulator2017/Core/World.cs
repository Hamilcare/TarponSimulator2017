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

		public World ()
		{
			playerBoat = new Boat (200, 300);
			playerBoat.FrameOfReference = this;
			FirstFish = new Fish (400, 400);
			FirstFish.FrameOfReference = this;
			toUpdate = new List<IUpdatable> ();
			toUpdate.Add (playerBoat);
			toUpdate.Add (FirstFish);
		}

		public void Update (int now)
		{
			//@FIXME 
			FirstFish.Update (this.playerBoat.FishingRod.FishingFloat.AbsolutePosition, Vector2.Zero);
			toUpdate.ForEach (tu => tu.Update (now));
			ComputeTree (this.TotalTransformation);
		}
	}
}
