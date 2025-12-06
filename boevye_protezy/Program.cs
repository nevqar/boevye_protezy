using System;
using System.Runtime.InteropServices;
//using CppClasses;
namespace boevye_protezy
{
	internal class Program
	{
		[DllImport("Mouse.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static private extern void LeftСlick();
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			LeftСlick();
			//MouseController mc = new MouseController();
			//Console.WriteLine(mc.GetHelloWorld());
		}
	}
}
