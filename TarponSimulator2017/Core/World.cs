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

		}

		public void UpdateUpdatables()
		{
			
		}
	}
}
