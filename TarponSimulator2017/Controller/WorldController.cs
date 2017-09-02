using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tarpon.Controller
{
	public class WorldController : IController
	{
		private Core.World world;

		public WorldController(Core.World world)
		{
			this.world = world;
		}

		public void Update(GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState)
		{
			world.Update(gameTime.ElapsedGameTime.Milliseconds);
		}
	}
}
