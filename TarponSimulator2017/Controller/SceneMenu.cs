using System;
using Tarpon.Controller;

namespace Tarpon.Controller
{
	public class SceneMenu : Scene
	{
		private static readonly Lazy<SceneMenu> lazy = new Lazy<SceneMenu>(() => new SceneMenu());

		public static SceneMenu Instance { get { return lazy.Value; } }

		private SceneMenu ()
		{
		}
	}
}

