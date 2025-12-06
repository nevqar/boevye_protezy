using System;
using CppClasses;
using NeuroSDK;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			CallibriSensor sensor = Sensor.GetSensor(4000);
			DataComputer computer = new DataComputer();
			Sensor.Start(sensor, computer);
		}
	}
}
