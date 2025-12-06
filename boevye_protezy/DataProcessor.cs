using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vectors;
using NeuroSDK;

namespace boevye_protezy
{
	internal class DataProcessor
	{
		public DataProcessor() { }
		public vec2 Process(quaternion q)
		{
			vec3 v = new vec3(1);
			v = q.Rotate(v);
			Console.WriteLine(v);
			return new vec2(0);
		}
	}
}
