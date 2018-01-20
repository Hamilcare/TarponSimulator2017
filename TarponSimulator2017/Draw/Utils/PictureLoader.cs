using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Tarpon.Draw.Utils
{	
	public class PictureLoader
	{
		static public Texture2D LoadPicture(GraphicsDevice graphics, string Filename)
		{
			FileStream setStream = File.Open(Filename, FileMode.Open);
			Texture2D NewTexture = Texture2D.FromStream(graphics, setStream);
			setStream.Dispose();
			return NewTexture;
		}
	}
}