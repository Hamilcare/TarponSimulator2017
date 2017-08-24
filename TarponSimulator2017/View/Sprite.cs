using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

using Core;

namespace TarponSimulator2017
{	public class Sprite
	{
		public Texture2D Texture { get; set;}



		public virtual void Initialize()
		{
			
		}


		public virtual void LoadContent(GraphicsDevice graphics, string filename)
		{
			this.Texture = LoadPicture (graphics, filename);
		}


		static public Texture2D LoadPicture(GraphicsDevice graphics, string Filename)
		{
			FileStream setStream = File.Open(Filename, FileMode.Open);
			//StreamReader reader = new StreamReader(setStream);
			Texture2D NewTexture = Texture2D.FromStream(graphics, setStream);
			setStream.Dispose();
			return NewTexture;
		}

	}

}

