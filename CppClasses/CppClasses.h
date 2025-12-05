#pragma once

using namespace System;

namespace CppClasses
{
	public ref class MouseController
	{
		//for limlet
	public:
		//Тестовый метод, не убирайте
		//Возвращает "MouseController >> Hello World!"
		String^ GetHelloWorld()
		{
			return gcnew String("MouseController >> Hello World!");
		}
		//Устанавливает позицию курсора на координаты (x, y) в пикселях
		void SetCursorPosition(int x, int y)
		{

		}
		//Нажимает ЛКМ
		void LeftСlick()
		{

		}
		//Нажимает ПКМ
		void RightClick()
		{

		}
		//Возвращает ширину окна в пикселях
		int GetWindowWidth()
		{
			return -1;
		}
		//Возвращает высоту окна в пикселях
		int GetWindowHeight()
		{
			return -1;
		}
	};
}