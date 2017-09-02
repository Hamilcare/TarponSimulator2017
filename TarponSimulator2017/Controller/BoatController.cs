using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tarpon.Controller
{
	public class BoatController : IController
	{
		readonly Core.Boat boat;
		public BoatController(Core.Boat boat)
		{
			this.boat = boat;
		}

		public void Update(GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState)
		{
			if (_keyboardState.IsKeyDown(Keys.Up))
			{
				boat.Accelerate();
			}
			else if (_keyboardState.IsKeyDown(Keys.Down))
			{
				//You cannot really brake on a boat, you have to reverse the engine rotation
			}

			if (_keyboardState.IsKeyDown(Keys.Right))
			{
				boat.Turn(Core.Boat.Direction.Right);
			}
			else if (_keyboardState.IsKeyDown(Keys.Left))
			{
				boat.Turn(Core.Boat.Direction.Left);
			}
		}
	}
}
