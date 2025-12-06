using CppClasses;
using NeuroSDK;
using System;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			CallibriSensor sensor = Sensor.GetSensor(3000);
			Console.WriteLine(sensor);

			var commands = sensor.Commands;


			sensor.Disconnect();
			sensor.Dispose();
		}
	}
}
