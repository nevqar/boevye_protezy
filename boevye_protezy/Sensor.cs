using NeuroSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace boevye_protezy
{
	public static class Sensor
	{
		static Scanner scanner;
		static List<SensorInfo> sensors = new List<SensorInfo>();
		public static CallibriSensor GetSensor()
		{
			Console.Write("Создание сканера... ");
			scanner = new Scanner(SensorFamily.SensorLECallibri);
			Console.WriteLine("DONE");
			scanner.Start();
			PrintSensorsList();
			scanner.EventSensorsChanged += ScannerFounded;
			int sensorId;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out sensorId))
				{
					if (sensorId >= 0 && sensorId < sensors.Count)
					{
						break;
					}
					Console.WriteLine("Сенсор с таким id не существует");
					Console.Write("Введите id сенсора >> ");
				}
				else
				{
					Console.WriteLine("Не число");
					Console.Write("Введите id сенсора >> ");
				}
			}

			CallibriSensor sensor = scanner.CreateSensor(sensors[sensorId]) as CallibriSensor;
			scanner.EventSensorsChanged -= ScannerFounded;
			Console.Write("Освобождение ресурсов сканера... ");
			scanner.Dispose();
			Console.WriteLine("DONE");
			return sensor;
		}
		private static void ScannerFounded(IScanner scanner, IReadOnlyList<SensorInfo> foundedSensors)
		{
			sensors = foundedSensors.ToList<SensorInfo>();
			PrintSensorsList();
		}
		private static void PrintSensorsList()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Поиск");
			Console.WriteLine("id \tname \t\t\tMAC");
			for (int i = 0;	i < sensors.Count; i++)
			{
				SensorInfo sensorInfo = sensors[i];
				string name = sensorInfo.Name;
				switch (name)
				{
					case "Callibri_Red":
						Console.ForegroundColor = ConsoleColor.Red;
						break;
					case "Callibri_Yellow":
						Console.ForegroundColor = ConsoleColor.Yellow;
						break;
					case "Callibri_Blue":
						Console.ForegroundColor = ConsoleColor.Blue;
						break;
					case "Callibri_White":
						Console.ForegroundColor = ConsoleColor.White;
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Gray;
						break;
				}
				Console.Write(i);
				Console.Write("\t");
				Console.Write(name);
				Console.Write("\t\t");
				Console.WriteLine(sensorInfo.Address);
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Введите id сенсора >> ");
		}
		public static void Start(CallibriSensor sensor, DataComputer dataComputer) 
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);

			Console.Write("Настройка датчика ... ");
			sensor.ExecCommand(SensorCommand.CommandResetQuaternion);
			sensor.SignalTypeCallibri = CallibriSignalType.EMG;

			sensor.EventQuaternionDataRecived += dataComputer.ComputeQuaternion;
			sensor.ExecCommand(SensorCommand.CommandStartAngle);
			sensor.EventCallibriSignalDataRecived += dataComputer.ComputeEMG;
			sensor.ExecCommand(SensorCommand.CommandStartSignal);
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Запущено. Для помощи введите 'h'");
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
					case 'h': //help
						Console.WriteLine();
						Console.WriteLine("Помощь");
						Console.WriteLine("\t's' --- Отключение датчика");
						Console.WriteLine("\t'с' --- Калибровка. Курсор будет перемещён в центр");
						Console.WriteLine("\t'h' --- Вывод подсказки");
						break;
				}
			}
			sensor.ExecCommand(SensorCommand.CommandStopAngle);
			sensor.EventQuaternionDataRecived -= dataComputer.ComputeQuaternion;
			sensor.ExecCommand(SensorCommand.CommandStopSignal);
			sensor.EventCallibriSignalDataRecived -= dataComputer.ComputeEMG;
			sensor.Disconnect();
			sensor.Dispose();
		}
	}
}
