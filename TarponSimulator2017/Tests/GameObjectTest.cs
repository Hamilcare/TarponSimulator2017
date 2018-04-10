using System;
using NUnit.Framework;
using Tarpon.Core;
using Microsoft.Xna.Framework;

namespace Tarpon.Test
{
	[TestFixture]
	public class GameObjectTest
	{
		[Test]
		public void test1 ()
		{
			GameObject world = new GameObject ();
			GameObject Boat = new GameObject ();
			Boat.FrameOfReference = world;
			GameObject Rod = new GameObject ();
			Rod.FrameOfReference = Boat;

			Boat.RelativePosition = new Vector2 (5, -1);
			//Console.WriteLine (Boat.PartialTransformation);
			Assert.AreEqual (5, Boat.RelativePosition.X);
			Assert.AreEqual (-1, Boat.RelativePosition.Y);

			Boat.RelativeOrientation = (float)Math.PI / 2;
			Assert.AreEqual (Math.PI / 2, Boat.RelativeOrientation, 0.01);


			Rod.RelativePosition = new Vector2 (-3, 2);
			Rod.RelativeOrientation = (float)(Math.PI / 2);

			world.ComputeTree (world.TotalTransformation);

			Console.WriteLine (Rod.AbsolutePosition);

			//Console.WriteLine (Rod.TotalTransformation);
		}
	}
}

