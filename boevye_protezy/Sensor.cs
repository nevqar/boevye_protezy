using System;
using System.Collections.Generic;
using System.Text;
using NeuroSDK;

namespace boevye_protezy
{
	public static class Sensor
	{
		public static IReadOnlyList<SensorInfo> Scan(int delay)
		{
			Scanner scanner = new Scanner(SensorFamily.SensorLECallibri);
			scanner.Start();
			System.Threading.Thread.Sleep(delay);
			scanner.Stop();
			return scanner.Sensors;
			scanner.Dispose();
		}
	}
}
