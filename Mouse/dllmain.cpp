// dllmain.cpp : Определяет точку входа для приложения DLL.
// для Вовы
#include "pch.h"
#include "dllmain.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}


// mydll.cpp
#include "dllmain.h"
#include <iostream>
#include <string>

const int screenWidth = GetSystemMetrics(SM_CXSCREEN), screenHeight = GetSystemMetrics(SM_CYSCREEN);

// Функция сложения
MYDLL_API int add(int a, int b) {
    return a + b;
}

// Функция умножения
MYDLL_API int multiply(int a, int b) {
    return a * b;
}

// Функция приветствия
MYDLL_API void greet(const char* name) {
    std::cout << "Привет, " << name << "!" << std::endl;
} 


//Устанавливает позицию курсора на координаты (x, y) в пикселях
MYDLL_API void SetCursorPosition(int x, int y)
{
    x = min(x, screenWidth);
    x = max(x, 0);
    y = min(y, screenHeight);
    y = max(y, 0);
    SetCursorPos(x, y);
}
//Нажимает ЛКМ
MYDLL_API  void LeftСlick()
{
    INPUT input[2];
    ZeroMemory(&input, sizeof(input));
    input[0].type = INPUT_MOUSE;
    input[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
    input[1].type = INPUT_MOUSE;
    input[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;
    SendInput(2, input, sizeof(INPUT));
}
//Нажимает ПКМ
MYDLL_API  void RightClick()
{
    INPUT input[2];
    ZeroMemory(&input, sizeof(input));
    input[0].type = INPUT_MOUSE;
    input[0].mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
    input[1].type = INPUT_MOUSE;
    input[1].mi.dwFlags = MOUSEEVENTF_RIGHTUP;
    SendInput(2, input, sizeof(INPUT));
}
//Возвращает ширину окна в пикселях
MYDLL_API int GetWindowWidth()
{
    RECT rect;
    GetWindowRect(GetForegroundWindow(), &rect);
    return rect.right - rect.left;
}
//Возвращает высоту окна в пикселях
MYDLL_API int GetWindowHeight()
{
    RECT rect;
    GetWindowRect(GetForegroundWindow(), &rect);
    return rect.bottom - rect.top;
}

