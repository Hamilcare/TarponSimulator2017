using NUnit.Framework;
using Tarpon.Core;

namespace Tarpon.Test
{

	[TestFixture]
	public class BoatTest
	{
		[Test]
		public void CheckOrientation() {
			Boat b = new Boat();
			Assert.AreEqual (-1, b.Orientation.Y);
			Assert.AreEqual (0, b.Orientation.X);
		}
	}
}