﻿using System;
using Tarpon.Controller;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


using Tarpon.Utils;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public sealed class SceneInGame : Scene
	{
		private static readonly Lazy<SceneInGame> lazy = new Lazy<SceneInGame>(() => new SceneInGame());

		public static SceneInGame Instance { get { return lazy.Value; } }

		private SceneInGame()
		{
			actions = new Dictionary<Keys,Command>();
			//this.actions.Add(Keys.Up, new CommandAccelerate(world.playerBoat));
			//this.actions.Add(Keys.Right, new CommandTurn (world.playerBoat));
			//this.actions.Add(Keys.Left, new CommandTurn (world.playerBoat));
		}

		public SceneInGame(World world){
			actions = new Dictionary<Keys,Command> ();
			Scene.world = world;
			this.actions.Add (Keys.Up, new CommandAccelerate (world.playerBoat));
			this.actions.Add(Keys.Right, new CommandTurn (world.playerBoat, Direction.Right));
			this.actions.Add(Keys.Left, new CommandTurn (world.playerBoat, Direction.Left));
		}



	}
}