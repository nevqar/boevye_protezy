#pragma once
#ifndef MYDLL_H
#define MYDLL_H

// Если компилируем DLL, экспортируем функции
#ifdef MYDLL_EXPORTS
#define MYDLL_API __declspec(dllexport)
#else
#define MYDLL_API __declspec(/*dllimport*/)
#endif

// Простые функции для примера
extern "C" MYDLL_API int add(int a, int b);
extern "C" MYDLL_API int multiply(int a, int b);
extern "C" MYDLL_API void greet(const char* name);

extern "C" MYDLL_API void SetCursorPosition(int x, int y);
extern "C" MYDLL_API void LeftСlick();
extern "C" MYDLL_API void RightClick();
extern "C" MYDLL_API int GetWindowWidth();
extern "C" MYDLL_API int GetWindowHeight();

#endif