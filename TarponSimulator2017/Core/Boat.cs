using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public class Boat : Physics, IUpdatable
	{

		public  const float FrictionForceBoat = 0.0010f;
		public  const float AccelerationForceBoat = 0.0005f;
		public  const float TurnSpeedBoat = 0.0001f;
		public  const float MaxTurnAngleBoat = 0.02f;


		public Boat(int AbscisseDepart, int OrdonneeDepart) : base (FrictionForceBoat, AccelerationForceBoat, TurnSpeedBoat, MaxTurnAngleBoat, AbscisseDepart, OrdonneeDepart)
		{
			

		}
			

		public void Update(int now)
		{
			ComputeMovement(now);


		}
			


	}
}