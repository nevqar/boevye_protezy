using System;
namespace Vectors
{
	struct vec3
	{
		public double x, y, z;
		
		public vec3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public vec3(double a)
		{
			this.x = a;
			this.y = a;
			this.z = a;
		}

		public static vec3 operator +(vec3 a, vec3 b)
		{
			return new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static vec3 operator -(vec3 a, vec3 b)
		{
			return new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static vec3 operator *(double d, vec3 v)
		{
			return new vec3(d * v.x, d * v.y, d * v.z);
		}
		public static vec3 operator /(vec3 a, double b)
		{
			return new vec3(a.x / b, a.y / b, a.z / b);
		}
		
		public double Length()
		{
			return Math.Sqrt(x * x + y * y + z * z);
		}
		public double MaxComp()
		{
			return Math.Max(x, Math.Max(y, z));
		}
		public vec3 Normalize()
		{
			return this / this.Length();
		}
		public vec3 Abs()
		{
			return new vec3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}

		public static double Dot(vec3 a, vec3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}
		public static vec3 Max(vec3 a, double b)
		{
			return new vec3(Math.Max(a.x, b), Math.Max(a.y, b), Math.Max(a.z, b));
		}

		override public string ToString()
		{
			return "[" + x + ",\t" + y + ",\t" + z + "]";
		}
	}
}