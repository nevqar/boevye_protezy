using System;
namespace Vectors
{
	public struct vec2
	{
		public double x, y;
		
		public vec2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
		public vec2(double a)
		{
			this.x = a;
			this.y = a;
		}
		public static vec2 operator +(vec2 a, vec2 b)
		{
			return new vec2(a.x + b.x, a.y + b.y);
		}
		public static vec2 operator -(vec2 a, vec2 b)
		{
			return new vec2(a.x - b.x, a.y - b.y);
		}
		public static vec2 operator *(vec2 a, double b)
		{
			return new vec2(a.x * b, a.y * b);
		}
		public static vec2 operator *(double a, vec2 b)
		{
			return new vec2(a * b.x, a * b.y);
		}
		public static vec2 operator /(vec2 a, double b)
		{
			return new vec2(a.x / b, a.y / b);
		}
		public double Length()
		{
			return Math.Sqrt(x * x + y * y);
		}
		public vec2 Normalize()
		{
			return this / this.Length();
		}
	}
}