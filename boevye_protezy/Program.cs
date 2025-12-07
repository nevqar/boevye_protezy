using System;
using CppClasses;
using NeuroSDK;
using Vectors;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			matrix3x3 a = new matrix3x3(
			0, 0, -1,
			0, 1, 0,
			1, 0, 0);
			matrix3x3 b = a.Inverse();

			CallibriSensor sensor = Sensor.GetSensor(4000);
			DataComputer computer = new DataComputer();
			Sensor.Start(sensor, computer);
		}
	}
}
