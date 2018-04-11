using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;

/// <summary>
/// Game object.
/// ############
/// 11 21 31 41
/// 12 22 32 42
/// 13 23 33 34
/// 14 24 34 44
/// ############
///
/// cos -sin 0 x
/// sin  cos 0 y
///  0    0  1 0
///  0    0  0 1
/// </summary>

namespace Tarpon.Core
{
	public class GameObject
	{

		public List<GameObject> FrameOfReferenceFor{ get; private set; }

		public Matrix TotalTransformation{ get; private set; }

		public Matrix PartialTransformation{ get; set; }

		public GameObject FrameOfReference { 
			get { return null; } 
			set { value.FrameOfReferenceFor.Add (this); }
		}

		public Vector2 RelativePosition {
			get {
				return ExtractPosition (this.PartialTransformation);
			}
			set { 
				Vector3 scale;
				Quaternion rotation;
				Vector3 translation;
				PartialTransformation.Decompose (out scale, out rotation, out translation);
				Vector3 Position = new Vector3 (value.X, value.Y, 0);
				PartialTransformation = Matrix.CreateFromQuaternion (rotation)
				* Matrix.CreateTranslation (Position);
			}
		}

		public float RelativeOrientation {
			get { 
				return ExtractOrientation (this.PartialTransformation);
			}
			set { 
				Vector3 scale;
				Quaternion rotation;
				Vector3 translation;
				PartialTransformation.Decompose (out scale, out rotation, out translation);
				rotation = Quaternion.CreateFromAxisAngle (Vector3.UnitZ, value);
				PartialTransformation = Matrix.CreateScale (scale) * Matrix.CreateFromQuaternion (rotation) * Matrix.CreateTranslation (translation);
			}
		}

		public Vector2 AbsolutePosition {
			get {
				return ExtractPosition (this.TotalTransformation);
			}
		}

		public float AbsoluteOrientation {
			get { return ExtractOrientation (this.TotalTransformation); }
		}

		public GameObject ()
		{
			FrameOfReferenceFor = new List<GameObject> ();	
			TotalTransformation = Matrix.Identity;
			PartialTransformation = Matrix.Identity;
		}

		public void ComputeTree (Matrix ParentTransformation)
		{
			this.TotalTransformation = this.PartialTransformation * ParentTransformation;
			FrameOfReferenceFor.ForEach (currentObject => currentObject.ComputeTree (this.TotalTransformation));
		}

		private static Vector2 ExtractPosition (Matrix m)
		{
			Vector3 scale;
			Quaternion rotation;
			Vector3 translation;
			m.Decompose (out scale, out rotation, out translation);
			return new Vector2 (translation.X, translation.Y);
		}

		private static float ExtractOrientation (Matrix m)
		{
			return (float)Math.Atan2 (m.M12, m.M11);
		}
			
	}
}
