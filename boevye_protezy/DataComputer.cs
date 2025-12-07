using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vectors;
using NeuroSDK;
using System.Diagnostics;

namespace boevye_protezy
{
	public class DataComputer
	{
		public DataComputer() { }
		private MouseController mouse = new MouseController();
		matrix3x3 matrix;
		private matrix3x3 onCenter = new matrix3x3(
			0, 0, -1,
			0, 1, 0,
			1, 0, 0);
		private matrix3x3 compensation = matrix3x3.identity;
		public void Calibrate()
		{
			compensation = onCenter * matrix.Inverse();
		}
		private vec3 lforward = new vec3(1, 0, 0);
		private matrix3x3 lmatrix = matrix3x3.identity;
		public void ComputeQuaternion(ISensor sensor, QuaternionData[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				double w = data[i].W;
				double x = data[i].X;
				double y = data[i].Y;
				double z = data[i].Z;

				quaternion q = new quaternion(w, x, y, z);
				matrix = q.ToMatrix();
				vec3 forward = compensation * (matrix * new vec3(0, 0, -1));

				compensation = matrix3x3.ZRotation(0.00036) * compensation;

				vec2 v = new vec2(-forward.y, -forward.z);
				MouseControl(v);
			}
		}
		double sum;
		Queue<double> lastNSamples = new Queue<double>();
		int n = 1000;
		Stopwatch sw = Stopwatch.StartNew();
		int delay = 600;
		public void ComputeEMG(ISensor sensor, CallibriSignalData[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				var samples = data[i].Samples;
				for (int j = 0; j < samples.Length; j++)
				{
					double sample = Math.Abs(samples[j] * 10000);
					lastNSamples.Enqueue(sample);
					sum += sample;

					if (lastNSamples.Count > n)
					{
						sum -= lastNSamples.Dequeue();
					}

					double average = sum / lastNSamples.Count;
					double difference = sample - average;
					double square = difference * difference;

					if (square >= 8)
					{
						if (sw.ElapsedMilliseconds >= delay)
						{
							mouse.LeftClick();
							sw.Restart();
						}
					}
				}
			}
		}
		private void MouseControl(vec2 v)
		{
			int width = mouse.GetScreenWidth();
			int height = mouse.GetScreenHeight();
			v *= 1;
			int x = (int)(v.x * width + width / 2);
			int y = (int)(-v.y * width + height / 2);
			mouse.SetCursorPosition(x, y);
		}
	}
}
