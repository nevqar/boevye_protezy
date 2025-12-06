using CppClasses;
using NeuroSDK;
using System;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			MouseController mc = new MouseController();
			Console.WriteLine(mc.GetHelloWorld());

			IReadOnlyList<SensorInfo> sensors = Sensor.Scan(1500);
			if (sensors.Count == 0)
				throw new Exception("No sensors found!");
			for (int i = 0; i < sensors.Count; i++)
			{
				Console.WriteLine(i + "\t" + sensors[i].Name + "\t" + sensors[i].Address);
			}
			Console.Write("Выберите сенсор >> ");
			SensorInfo sensor = sensors[int.Parse(Console.ReadLine())];

		}
	}
}
