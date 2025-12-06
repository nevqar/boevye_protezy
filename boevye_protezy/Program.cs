using CppClasses;
using NeuroSDK;
using System;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{
			CallibriSensor sensor = Sensor.GetSensor(4000);
			Console.WriteLine(sensor);

			//sensor.EventMEMSDataRecived += Sensor_EventMEMSDataRecived;
			//sensor.ExecCommand(SensorCommand.CommandStartMEMS);

			//Console.Clear();

			//System.Threading.Thread.Sleep(1000000);

			//sensor.EventMEMSDataRecived -= Sensor_EventMEMSDataRecived;
			//sensor.ExecCommand(SensorCommand.CommandStopMEMS);


			sensor.EventQuaternionDataRecived += Sensor_EventQuaternionDataRecived;
			sensor.ExecCommand(SensorCommand.CommandStartAngle);
			Console.Clear();
			System.Threading.Thread.Sleep(1000000);
			sensor.EventQuaternionDataRecived -= Sensor_EventQuaternionDataRecived;
			sensor.ExecCommand(SensorCommand.CommandStopAngle);



			sensor.Disconnect();
			sensor.Dispose();
		}
		static private void Sensor_EventMEMSDataRecived(ISensor sensor, MEMSData[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(data[i].Accelerometer.X);
				Console.WriteLine(data[i].Accelerometer.Y);
				Console.WriteLine(data[i].Accelerometer.Z);
				Console.WriteLine();
			}
		}
		private static void Sensor_EventQuaternionDataRecived(ISensor sensor, QuaternionData[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(data[i].W);
				Console.WriteLine(data[i].X);
				Console.WriteLine(data[i].Y);
				Console.WriteLine();

			}
		}
	}
}
