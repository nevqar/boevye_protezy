#pragma once
//#ifndef DLLMAIN_H
//#define DLLMAIN_H
#include <windows.h>
// Если компилируем DLL, экспортируем функции
//#ifdef DLLMAIN_EXPORTS
//#define DLLMAIN_API __declspec(dllexport)
//#else
//#define DLLMAIN_API __declspec(dllimport)
//#endif

// Простые функции для примера
///*extern "C"*/ __declspec(dllimport) int add(int a, int b);
///*extern "C"*/ __declspec(dllimport) int multiply(int a, int b);
///*extern "C"*/ __declspec(dllimport) void greet(char name);

/*extern "C"*/ __declspec(dllimport) void SetCursorPosition(int x, int y);
extern "C" __declspec(dllimport) void LeftСlick();
/*extern "C"*/ __declspec(dllimport) void RightClick();
/*extern "C"*/ __declspec(dllimport) int GetWindowWidth();
/*extern "C"*/ __declspec(dllimport) int GetWindowHeight();

//#endif