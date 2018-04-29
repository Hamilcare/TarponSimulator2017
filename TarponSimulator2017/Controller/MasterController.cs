using System;
using Tarpon.Controller;
using Tarpon.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tarpon.Controller
{
	public class MasterController : IController
	{
		Scene scene;

		public MasterController (World world, Scene scene)
		{
			this.scene = scene;
		}

		public void ChangeScene (Scene newScene)
		{
		}

		public void Update (GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState)
		{
			scene.SceneInputs (gameTime, _keyboardState, _oldKeyboardState, mouseState);
		}
	}
}

