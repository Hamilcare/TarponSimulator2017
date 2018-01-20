using System.Collections.Generic;
using System.Linq;
namespace Tarpon.Core
{
	public class World
	{
		public List<Boat> Boats { get; private set; }
		private List<IUpdatable> toUpdate;

		public World()
		{
			Boats = new List<Boat>();
			toUpdate = new List<IUpdatable>();
		}

		public Boat AddBoat()
		{
			Boat b = new Boat();
			Boats.Add(b);
			toUpdate.Add(b);

			return b;
		}

		public void Update(int now)
		{
			toUpdate.ForEach(tu => tu.Update(now));
		}
	}
}
