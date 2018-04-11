using System.Collections.Generic;
using System.Linq;
using System;

namespace Tarpon.Core
{
	public class World : GameObject
	{
		public Boat playerBoat { get; private set; }

		public List<IUpdatable> toUpdate { get; private set; }

		public World ()
		{
			playerBoat = new Boat (200, 300);
			playerBoat.FrameOfReference = this;
			toUpdate = new List<IUpdatable> ();
			toUpdate.Add (playerBoat);
		}

		public void Update (int now)
		{
			ComputeTree (this.TotalTransformation);
			toUpdate.ForEach (tu => tu.Update (now));
			ComputeTree (this.TotalTransformation);
		}
	}
}
