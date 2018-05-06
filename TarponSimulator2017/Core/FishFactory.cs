using System;
using System.Collections.Generic;

namespace Tarpon.Core
{
	public class FishFactory
	{
		private static FishFactory UniqueInstance = null;

		/// <summary>
		/// Kind of Singleton
		/// </summary>
		/// <value>The instance.</value>
		public static FishFactory Instance {
			get {
				if (UniqueInstance == null) {
					UniqueInstance = new FishFactory ();
					return UniqueInstance;
				}
				return UniqueInstance;
			}
		}

		private Random rnd = new Random ();

		private FishFactory ()
		{
		}

		/// <summary>
		/// Creates the random fish.
		/// </summary>
		/// <returns>The random fish.</returns>
		public Fish CreateRandomFish ()
		{
			int StartAbscisse = rnd.Next (0, 1000);
			int StartOrdinate = rnd.Next (0, 1000);

			return new Fish (StartAbscisse, StartOrdinate);
		}

		/// <summary>
		/// Inits the fish.
		/// </summary>
		/// <returns>The fish.</returns>
		/// <param name="NbFish">Nb fish.</param>
		public IList<Fish> InitFish (int NbFish)
		{
			List<Fish> ListOfFishes = new List<Fish> ();
			for (int i = 0; i < NbFish; i++) {
				ListOfFishes.Add (CreateRandomFish ());
			}
			return ListOfFishes;
		}


	}
}

