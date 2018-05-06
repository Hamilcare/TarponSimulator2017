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

		private static World UniqueInstance;

		public static World Instance {
			get {
				if (UniqueInstance == null) {
					UniqueInstance = new World ();
				}
				return UniqueInstance;
			}
		}


		public void InitWorld ()
		{
			playerBoat = new Boat (950, 540);
			playerBoat.FrameOfReference = this;
			toUpdate = new List<IUpdatable> ();
			toUpdate.Add (playerBoat);
			//Handle Fish Generation
			IList<Fish> ListOfFishes = FishFactory.Instance.InitFish (1);
			this.AddAListOfFish (ListOfFishes);
		}

		public void AddAfFish (Fish f)
		{
			f.FrameOfReference = this;
			playerBoat.ListOfFishes.Add (f);
			toUpdate.Add (f);
			TarponGame.AddAFishToDraw (f);
		}

		public void AddAListOfFish (IList<Fish> List)
		{
			foreach (Fish f in List) {
				AddAfFish (f);	
			}

		}

		public void RemoveAFish (Fish f)
		{
			TarponGame.RemoveAFishToDraw (f);
			UniqueInstance.playerBoat.ListOfFishes.Remove (f);
			UniqueInstance.toUpdate.Remove (f);
			AddAfFish (FishFactory.Instance.CreateRandomFish ());
		}



		public void Update (int now)
		{
			toUpdate.ForEach (tu => tu.Update (now));
			ComputeTree (this.TotalTransformation);
		}
	}
}
