using CppClasses;
using NeuroSDK;
using System;
using Vectors;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main()
		{

			//CallibriSensor sensor = Sensor.GetSensor(4000);
			//Console.WriteLine(sensor);

			//sensor.ExecCommand(SensorCommand.CommandResetQuaternion);

			//sensor.EventQuaternionDataRecived += Sensor_EventQuaternionDataRecived;
			//sensor.ExecCommand(SensorCommand.CommandStartAngle);

			//sensor.ExecCommand(SensorCommand.CommandResetQuaternion);
			//Console.Clear();
			//System.Threading.Thread.Sleep(1000000);
			//sensor.EventQuaternionDataRecived -= Sensor_EventQuaternionDataRecived;
			//sensor.ExecCommand(SensorCommand.CommandStopAngle);



			//sensor.Disconnect();
			//sensor.Dispose();
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
				double w = data[i].W;
				double x = data[i].X;
				double y = data[i].Y;
				double z = data[i].Z;

				quaternion q = new quaternion(w, x, y, z);
				vec3 v = 100 * q.Rotate(new vec3(0, 0, 1));
				Console.Write((int)v.x);
				Console.Write("\t");
				Console.WriteLine((int)v.z);
			}
		}
	}
}
