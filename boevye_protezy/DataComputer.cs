using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vectors;
using NeuroSDK;

namespace boevye_protezy
{
	public class DataComputer
	{
		public DataComputer() { }
		private MouseController mouse = new MouseController();
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
		public void Calibrate()
		{
			compensation = GetCompensation(lastEnd, new vec3(0, -1, 0));
			Console.WriteLine(compensation.w);
			Console.WriteLine(compensation.x);
			Console.WriteLine(compensation.y);
			Console.WriteLine(compensation.z);
		}
		vec3 lastEnd = new vec3(0, 0, 1);
		private quaternion compensation = new quaternion(1, 0, 0, 0);
		private vec2 ComplicatedCalculations(quaternion q)
		{
			vec3 start = new vec3(0, 0, 1);
			vec3 end = compensation.Rotate(q.Rotate(start));
			lastEnd = end;
			return new vec2(end.x, end.z);
		}
		private quaternion GetCompensation(vec3 value, vec3 required)
		{
			value = value.Normalize();
			required = required.Normalize();
			vec3 u = vec3.Cross(required, value);
			u = u.Normalize();

			double theta = Math.Acos(vec3.Dot(required, value));

			double w = Math.Cos(theta / 2);
			double x = Math.Sin(theta / 2) * u.x;
			double y = Math.Sin(theta / 2) * u.y;
			double z = Math.Sin(theta / 2) * u.z;

			return new quaternion(w, x, y, z).Invert();
		}
		private void MouseControl(vec2 v)
		{
			int width = mouse.GetScreenWidth();
			int height = mouse.GetScreenHeight();
			v *= 1;
			int x = (int)(v.x * width + width / 2);
			int y = (int)(-v.y * height + height / 2);
			mouse.SetCursorPosition(x, y);
		}
	}
}
