using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//using Microsoft.Xna.Framework.Media;
//using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

using Tarpon.Core;
using Tarpon.Draw;
using Tarpon.Controller;
using System.Linq;

namespace Tarpon
{
	public class TarponGame : Game
	{
		private static TarponGame UniqueInstance;

		public SpriteBatch spriteBatch { get; private set; }

		GraphicsDeviceManager graphics;
		KeyboardState keyboardState;
		KeyboardState oldKeyboardState;
		MouseState mouseState;

		MapDrawer MapDrawer;

		/// <summary>
		/// The fish dictionnary.
		/// Using it to add and remove fish to draw
		/// </summary>
		IDictionary<Fish,IDrawer> FishDictionnary;

		/// <summary>
		/// Everything to draw but fishes
		/// </summary>
		List<IDrawer> toDraw;
		IController toControl;
		Scene scene;
		FollowingCamera worldCamera;

		static public int WIDTH;
		static public int HEIGHT;

		public TarponGame ()
		{
			Window.Title = "TARPON";
			Window.Position = new Point (0, 0);
			Window.IsBorderless = false;

			graphics = new GraphicsDeviceManager (this);
			graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges ();
			FishDictionnary = new Dictionary<Fish, IDrawer> ();
			UniqueInstance = this;
		}


		protected override void Initialize ()
		{
			HEIGHT = Window.ClientBounds.Height;
			WIDTH = Window.ClientBounds.Width;

			World world = World.Instance;
			world.InitWorld ();

			//Deso Lucie, j'ai mis un bye a ton singleton, je sais pas comment ça marche ptdr
			scene = new SceneInGame (world);
			toDraw = new List<IDrawer> ();
			toControl = new MasterController (world, scene);

			worldCamera = new FollowingCamera (graphics, world.playerBoat);

			// Extraction of elements to draw should be done in the "Draw" folder
			// Note that the order in the list is important => items at the beginning will be drawn fist
			MapDrawer = new MapDrawer (graphics, world);
			toDraw.Add (new BoatDrawer (world.playerBoat));
			toDraw.Add (new FishingFloatDrawer (world.playerBoat, world.playerBoat.FishingRod.FishingFloat, this.GraphicsDevice));
			toDraw.Add (new FishingLineDrawer (world.playerBoat, world.playerBoat.FishingRod, this.GraphicsDevice));

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			MapDrawer.LoadContent (Content);
			FishDictionnary.Keys.ToList ().ForEach (currentKey => FishDictionnary [currentKey].LoadContent (Content));
			toDraw.ForEach (td => td.LoadContent (Content));
		}

		protected override void Update (GameTime gameTime)
		{
			keyboardState = Keyboard.GetState ();
			mouseState = Mouse.GetState ();

			toControl.Update (gameTime, keyboardState, oldKeyboardState, mouseState);

			oldKeyboardState = keyboardState;
			base.Update (gameTime);
		}



		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			base.Draw (gameTime);

			// Start drawing
			// samplerState is needed, otherwise some lines are drawm between sea tiles
			// https://gamedev.stackexchange.com/a/25121
			spriteBatch.Begin (samplerState: SamplerState.PointClamp, transformMatrix: worldCamera.TransformMatrix);

			//Draw elements
			MapDrawer.Draw (spriteBatch, gameTime);
			FishDictionnary.Keys.ToList ().ForEach (currentFish => FishDictionnary [currentFish].Draw (spriteBatch, gameTime));
			toDraw.ForEach (td => td.Draw (spriteBatch, gameTime));

			// Stop drawing
			spriteBatch.End ();
		}

		public static void AddAFishToDraw (Fish f)
		{
			FishDrawer fd = new FishDrawer (f, UniqueInstance.GraphicsDevice);
			fd.LoadContent (UniqueInstance.Content);
			UniqueInstance.FishDictionnary.Add (f, fd);
		}

		public static void RemoveAFishToDraw (Fish f)
		{
			UniqueInstance.FishDictionnary.Remove (f);
		}

		public static void Main ()
		{
			var game = new TarponGame ();
			game.Run ();
		}
	}
}
