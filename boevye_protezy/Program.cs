using System;
using CppClasses;
namespace boevye_protezy
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			MouseController mc = new MouseController();
			Console.WriteLine(mc.GetHelloWorld());
		}
	}
}
