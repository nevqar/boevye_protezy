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

}
//Нажимает ЛКМ
MYDLL_API  void LeftСlick()
{

}
//Нажимает ПКМ
MYDLL_API  void RightClick()
{

}
//Возвращает ширину окна в пикселях
MYDLL_API int GetWindowWidth()
{
    return -1;
}
//Возвращает высоту окна в пикселях
MYDLL_API int GetWindowHeight()
{
    return -1;
}

