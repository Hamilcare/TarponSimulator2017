﻿using System.Collections.Generic;
using System.Linq;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public abstract class Scene
	{
		/// <summary>
		/// Gets or sets the continious actions.
		/// </summary>
		/// <value>The continious actions like accelerate or turn.</value>
		public Dictionary<Keys,Command> ContiniousActions { get; protected set; }

		/// <summary>
		/// Gets or sets the one time actions.
		/// </summary>
		/// <value>The one time actions such as change rod state</value>
		public Dictionary<Keys,Command> OneTimeActions { get; protected set; }


		//ptrdr pour passer le bateau aux commandes
		public static World world { get; set; }

		public Scene ()
		{
			ContiniousActions = new Dictionary<Keys,Command> ();
			OneTimeActions = new Dictionary<Keys, Command> ();
		}

		public void SceneInputs (GameTime gameTime, KeyboardState _keyboardState, KeyboardState _oldKeyboardState, MouseState mouseState)
		{
			ContiniousActions.Keys
				.Where (currentKey => _keyboardState.IsKeyDown (currentKey))
				.ToList ().ForEach (currentKey => ContiniousActions [currentKey].execute ());

			OneTimeActions.Keys
				.Where (currentKey => _keyboardState.IsKeyDown (currentKey) && _oldKeyboardState.IsKeyUp (currentKey)) 
				.ToList ().ForEach (currentKey => OneTimeActions [currentKey].execute ());

			world.Update (gameTime.ElapsedGameTime.Milliseconds);
		}

	}
}

