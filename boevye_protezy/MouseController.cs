using System.Runtime.InteropServices;
using System;

public class MouseController
{
	// Импорт функций из user32.dll
	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int x, int y);

	[DllImport("user32.dll")]
	private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

	[DllImport("user32.dll")]
	private static extern int GetSystemMetrics(int nIndex);

	// Константы для SendInput
	private const int INPUT_MOUSE = 0;
	private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
	private const uint MOUSEEVENTF_LEFTUP = 0x0004;
	private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
	private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
	private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

	// Константы для GetSystemMetrics
	private const int SM_CXSCREEN = 0;
	private const int SM_CYSCREEN = 1;

	// Размеры экрана
	private readonly int screenWidth;
	private readonly int screenHeight;

	// Структуры
	[StructLayout(LayoutKind.Sequential)]
	private struct INPUT
	{
		public uint type;
		public MOUSEINPUT mi;
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct MOUSEINPUT
	{
		public int dx;
		public int dy;
		public uint mouseData;
		public uint dwFlags;
		public uint time;
		public IntPtr dwExtraInfo;
	}

	// Конструктор
	public MouseController()
	{
		// Получаем размеры экрана один раз
		screenWidth = GetSystemMetrics(SM_CXSCREEN);
		screenHeight = GetSystemMetrics(SM_CYSCREEN);
	}

	// Устанавливает позицию курсора на координаты (x, y) в пикселях
	public void SetCursorPosition(int x, int y)
	{
		x = Math.Min(x, screenWidth);
		x = Math.Max(x, 0);
		y = Math.Min(y, screenHeight);
		y = Math.Max(y, 0);
		SetCursorPos(x, y);
	}

	private void SendMouseEvent(uint flags)
	{
		INPUT input = new INPUT
		{
			type = INPUT_MOUSE,
			mi = new MOUSEINPUT
			{
				dx = 0,
				dy = 0,
				mouseData = 0,
				dwFlags = flags,
				time = 0,
				dwExtraInfo = IntPtr.Zero
			}
		};

		INPUT[] inputs = new INPUT[] { input };
		SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
	}

	// Нажимает ЛКМ
	public void LeftClick()
	{
		SendMouseEvent(MOUSEEVENTF_LEFTDOWN);
		SendMouseEvent(MOUSEEVENTF_LEFTUP);
	}

	// Нажимает ПКМ
	public void RightClick()
	{
		SendMouseEvent(MOUSEEVENTF_RIGHTDOWN);
		SendMouseEvent(MOUSEEVENTF_RIGHTUP);
	}

	// Возвращает ширину экрана
	public int GetScreenWidth()
	{
		return screenWidth;
	}

	// Возвращает высоту экрана
	public int GetScreenHeight()
	{
		return screenHeight;
	}

	// Тестовый метод
	public string GetHelloWorld()
	{
		return "MouseController >> Hello World!";
	}
}