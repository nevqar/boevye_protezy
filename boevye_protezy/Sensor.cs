using System;
using System.Collections.Generic;
using System.Text;
using NeuroSDK;

namespace boevye_protezy
{
	public static class Sensor
	{
		public static CallibriSensor GetSensor(int delay)
		{
			Console.Write("Создание сканера... ");
			Scanner scanner = new Scanner(SensorFamily.SensorLECallibri);
			Console.WriteLine("DONE");
			scanner.Start();
			Console.Write("Поиск... ");
			System.Threading.Thread.Sleep(delay);
			scanner.Stop();
			Console.WriteLine("DONE");
			IReadOnlyList<SensorInfo> sensors = scanner.Sensors;
			if (sensors.Count == 0)
				throw new Exception("No sensors found!");
			Console.WriteLine("Найдены сенсоры:");
			for (int i = 0; i < sensors.Count; i++)
			{
				Console.WriteLine(i + "\t" + sensors[i].Name + "\t" + sensors[i].Address);
			}
			Console.Write("Выберите сенсор >> ");
			int sensorNumber = int.Parse(Console.ReadLine());
			SensorInfo sensorInfo = sensors[sensorNumber];
			Console.Write("Получение сенсора... ");
			CallibriSensor sensor = scanner.CreateSensor(sensorInfo) as CallibriSensor;
			Console.WriteLine("DONE");
			Console.Write("Освобождение ресурсов сканера... ");
			scanner.Dispose();
			Console.WriteLine("DONE");
			return sensor;
		}
		public static void Start(CallibriSensor sensor, DataComputer dataComputer) 
		{
			sensor.ExecCommand(SensorCommand.CommandResetQuaternion);
			sensor.EventQuaternionDataRecived += dataComputer.Compute;
			sensor.ExecCommand(SensorCommand.CommandStartAngle);
			bool stop = false;
			while (!stop)
			{
				char c = (char)Console.Read();
				switch (c)
				{
					case 's': //stop
						stop = true;
						break;
					case 'c': //cancel
						dataComputer.Calibrate();
						break;
				}
			}
			sensor.EventQuaternionDataRecived -= dataComputer.Compute;
			sensor.ExecCommand(SensorCommand.CommandStopAngle);
			sensor.Disconnect();
			sensor.Dispose();
		}
	}
}
