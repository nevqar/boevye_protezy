using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Vectors;
namespace Vectors
{
	public struct quaternion
	{
		public double w;
		public double x;
		public double y;
		public double z;
		public quaternion(double w, double x, double y, double z)
		{
			this.w = w;
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public double Length()
		{
			return Math.Sqrt(w * w + x * x + y * y + z *z);
		}
		public quaternion Normalize()
		{
			return (1 / this.Length()) * this;
		}
		public quaternion Invert()
		{
			return (new quaternion(w, -x, -y, -z)).Normalize();
		}
		static public quaternion operator *(double a, quaternion q)
		{
			return new quaternion(a * q.w, a * q.x, a * q.y, a * q.z);
		}
		static public quaternion operator *(quaternion a, quaternion b)
		{
			return new quaternion(
				a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z,
				a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
				a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
				a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w);
		}
		public vec3 Rotate(vec3 v)
		{
			quaternion q = new quaternion(0, v.x, v.y, v.z);
			quaternion resq = (this * q) * this.Invert();
			return new vec3(resq.x, resq.y, resq.z);
		}
	}
}
