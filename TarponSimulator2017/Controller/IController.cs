using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Tarpon.Controller
{
	public interface IController
	{
		void Update(GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState);
	}
}
