using System;
using Tarpon.Controller;

namespace Tarpon.Controller
{
	public sealed class SceneInGame : Scene
	{
		private static readonly Lazy<SceneInGame> lazy = new Lazy<SceneInGame>(() => new SceneInGame());

		public static SceneInGame Instance { get { return lazy.Value; } }

		private SceneInGame ()
		{
		}
	}
}
