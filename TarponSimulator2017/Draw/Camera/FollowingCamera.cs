using System;
using Microsoft.Xna.Framework;
using Tarpon.Core;

namespace Tarpon.Draw
{
	public class FollowingCamera
	{
		protected GraphicsDeviceManager Graphics;
		protected GameObject TargetObject;

		public Matrix TransformMatrix {
			get { 
				Matrix invert = Matrix.Invert (TargetObject.TotalTransformation);
				Vector3 scale;
				Quaternion rotation;
				Vector3 translation;
				invert.Decompose (out scale, out rotation, out translation);
				translation.X += Graphics.PreferredBackBufferWidth / 2;
				translation.Y += Graphics.PreferredBackBufferHeight / 2;
				return 
					Matrix.CreateScale (scale) * 
					Matrix.CreateFromQuaternion (rotation) *
					Matrix.CreateTranslation (translation);
			}
		}

		public FollowingCamera (GraphicsDeviceManager graphics, GameObject target)
		{
			TargetObject = target;
			Graphics = graphics;
		}
	}
}

