using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public abstract class Scene
	{
		//Pour éviter le switch case
		public Dictionary<Keys,Command> actions {get; protected set;}
		//ptrdr pour passer le bateau aux commandes
		public static World world {get; set;}

		public Scene ()
		{
			actions = new Dictionary<Keys,Command>();
		}

		public void SceneInputs(GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState)
		{
			actions.Keys
				.Where (currentKey => _keyboardState.IsKeyDown (currentKey))
				.ToList().ForEach (currentKey => actions [currentKey].execute ());
		}

	}
}

