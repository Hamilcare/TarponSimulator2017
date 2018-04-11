using System;
using Microsoft.Xna.Framework;

namespace Tarpon.Core
{
	public interface IUpdatable
	{
		void Update (int now);

		void Update (Vector2 vector, Vector2 anotherVector);
	}
}
