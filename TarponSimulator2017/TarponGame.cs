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
		public SpriteBatch spriteBatch { get; private set; }

		GraphicsDeviceManager graphics;
		KeyboardState keyboardState;
		KeyboardState oldKeyboardState;
		MouseState mouseState;

		World world;
		List<IDrawer> toDraw;
		IController toControl;
		Scene scene;

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
			graphics.IsFullScreen = false;
			graphics.ApplyChanges ();
		}


		protected override void Initialize ()
		{
			HEIGHT = Window.ClientBounds.Height;
			WIDTH = Window.ClientBounds.Width;

			World world = new World (); 

			//Deso Lucie, j'ai mis un bye a ton singleton, je sais pas comment ça marche ptdr
			scene = new SceneInGame (world);
			toDraw = new List<IDrawer> ();
			toControl = new MasterController (world, scene);


			// Extraction of elements to draw should be done in the "Draw" folder
			// Note that the order in the list is important => items at the beginning will be drawn fist
			//toDraw.AddRange(world.Boats.Select(b => new BoatDrawer(b)));
			toDraw.Add (new MapDrawer (graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
			toDraw.Add (new BoatDrawer (world.playerBoat));
			toDraw.Add (new FishingFloatDrawer (world.playerBoat, world.playerBoat.FishingRod.FishingFloat, this.GraphicsDevice));

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
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
			spriteBatch.Begin ();

			//Draw elements
			toDraw.ForEach (td => td.Draw (spriteBatch, gameTime));

			// Stop drawing
			spriteBatch.End ();
		}

		public static void Main ()
		{
			var game = new TarponGame ();
			game.Run ();
		}
	}
}
