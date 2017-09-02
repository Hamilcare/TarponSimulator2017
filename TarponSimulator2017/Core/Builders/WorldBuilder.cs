using System;

namespace Tarpon.Core
{
	public class WorldBuilder
	{
		public static World CreateSimpleWorld(int boatNumber)
		{
			World w = new World();
			for (int i = 0; i < boatNumber; i++)
			{
				w.AddBoat();
			}
			return w;
		}
	}
}
