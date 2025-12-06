using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vectors;
using NeuroSDK;

namespace boevye_protezy
{
	internal class DataComputer
	{
		public DataComputer() { }
		public void Compute(ISensor sensor, QuaternionData[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				double w = data[i].W;
				double x = data[i].X;
				double y = data[i].Y;
				double z = data[i].Z;

				quaternion q = new quaternion(w, x, y, z);

				vec2 v = ComplicatedCalculations(q);

				MouseControl(v);
			}
		}
		private vec2 ComplicatedCalculations(quaternion q)
		{
			vec3 one = new vec3(0, 0, 1);
			vec3 v = q.Rotate(one);
			return new vec2(v.x, v.z);
		}
		private void MouseControl(vec2 v)
		{
			v *= 3;
		}
	}
}
