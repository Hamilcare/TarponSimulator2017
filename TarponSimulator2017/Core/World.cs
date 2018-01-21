using System.Collections.Generic;
using System.Linq;
namespace Tarpon.Core
{
	public class World
	{
		public Boat playerBoat { get; private set; }
		public List<IUpdatable> toUpdate { get; private set; }

		public World()
		{
			playerBoat = new Boat (200, 300);
			toUpdate = new List<IUpdatable>();
			toUpdate.Add (playerBoat);
		}

		public void Update(int now)
		{
			toUpdate.ForEach(tu => tu.Update(now));
		}


	}
}
