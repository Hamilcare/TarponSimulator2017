using NUnit.Framework;
using Tarpon.Core;

namespace Tarpon.Test
{

	[TestFixture]
	public class BoatTest
	{
		[Test]
		public void CheckOrientation() {
			Boat b = new Boat(200,300);
			Assert.AreEqual (-1, b.Orientation.Y);
			Assert.AreEqual (0, b.Orientation.X);
		}

		[Test]
		public void CheckDeplacement(){
			Boat b = new Boat(200,300);
			b.Accelerate ();
			b.ComputeMovement (1000);
			Assert.AreEqual (b.ApplicationPoint.Y, -200);
		}
	}
}