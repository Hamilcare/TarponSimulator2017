using System;
using Tarpon.Controller;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


using Tarpon.Utils;
using Tarpon.Core;

namespace Tarpon.Controller
{
	public sealed class SceneInGame : Scene
	{
		private static readonly Lazy<SceneInGame> lazy = new Lazy<SceneInGame> (() => new SceneInGame ());

		public static SceneInGame Instance { get { return lazy.Value; } }

		private SceneInGame () : base ()
		{
			
		}

		public SceneInGame (World world) : base ()
		{
			Scene.world = world;
			this.ContiniousActions.Add (Keys.Up, new CommandAccelerate (world.playerBoat));
			this.ContiniousActions.Add (Keys.Right, new CommandTurn (world.playerBoat, Direction.Right));
			this.ContiniousActions.Add (Keys.Left, new CommandTurn (world.playerBoat, Direction.Left));
			this.ContiniousActions.Add (Keys.Q, new CommandMovesFloatAwayFromFishingRod (world.playerBoat.FishingRod));
			this.ContiniousActions.Add (Keys.D, new CommandBringFloatCloser (world.playerBoat.FishingRod));
			this.OneTimeActions.Add (Keys.Space, new CommandThrowOrGetBack (world.playerBoat.FishingRod));
		}



	}
}
