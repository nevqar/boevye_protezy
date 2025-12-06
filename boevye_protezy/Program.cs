using CppClasses;
using NeuroSDK;
using System;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			CallibriSensor s = Sensor.GetSensor(3000);
			Console.WriteLine(s);
		}
	}
}
