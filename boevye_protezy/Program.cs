using System;
using CppClasses;
using NeuroSDK;
using Vectors;
using System.IO;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			CallibriSensor sensor = Sensor.GetSensor();
			DataComputer computer = new DataComputer();
			Sensor.Start(sensor, computer);
		}
	}
}
