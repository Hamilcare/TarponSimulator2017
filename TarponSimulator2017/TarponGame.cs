using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;



using TarponSimulator2017;

using Core;

namespace TarponSimulator2017
{
	public class TarponGame : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;

		public SpriteBatch spriteBatch { get; private set; }

		private Player player;
		private Boat boat;

		private KeyboardState keyboardState;
		private KeyboardState oldKeyboardState;
		private MouseState mouseState;

		static public int WIDTH;
		static public int HEIGHT;



		public TarponGame ()
		{
			graphics = new GraphicsDeviceManager(this);

			//Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;
			//Window.AllowUserResizing = true;
			Window.Title = "TARPON";
			Window.Position = new Microsoft.Xna.Framework.Point(0, 0);
			Window.IsBorderless = false;

			//graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			//graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			graphics.ApplyChanges();


		}


		protected override void Initialize()
		{
			HEIGHT = Window.ClientBounds.Height;
			WIDTH = Window.ClientBounds.Width;

			boat = new Boat ();
			boat.Initialize ();
			player = new Player ();
			player.Initialize (boat);

			base.Initialize();
		}
			

		protected override void LoadContent(){
			spriteBatch = new SpriteBatch(GraphicsDevice);

			player.LoadContent (graphics.GraphicsDevice,"Content/chirac.png");

			
		}

		protected override void Update(GameTime gameTime)
		{
			keyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState ();

			boat.HandleInput(keyboardState, oldKeyboardState, mouseState);

			oldKeyboardState = keyboardState;



			base.Update(gameTime);
		}



		protected override void Draw(GameTime gameTime) {
			graphics.GraphicsDevice.Clear(Color.DarkGray);
			base.Draw(gameTime);

			// Start drawing
			spriteBatch.Begin();
			// Draw the Player

			player.Draw(spriteBatch, gameTime);


			// Stop drawing
			spriteBatch.End();
		}

		public Texture2D LoadPicture(string Filename)
		{
			FileStream setStream = File.Open(Filename, FileMode.Open);
			//StreamReader reader = new StreamReader(setStream);
			Texture2D NewTexture = Texture2D.FromStream(graphics.GraphicsDevice, setStream);
			setStream.Dispose();
			return NewTexture;
		}


		public static void Main() {
			var game = new TarponGame ();
			game.Run ();
		}
	}
}
