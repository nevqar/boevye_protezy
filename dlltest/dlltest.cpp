#include <iostream>
#include <windows.h>

// Определяем типы функций
typedef int (*ADD_FUNC)(int, int);
typedef int (*MULTIPLY_FUNC)(int, int);
typedef void (*GREET_FUNC)(const char*);

int main() {
    // Загружаем DLL
    HINSTANCE hDll = LoadLibrary(L"mydll.dll"); // Убедитесь, что DLL в той же папке

    if (!hDll) {
        std::cerr << "Не удалось загрузить DLL!" << std::endl;
        return 1;
    }

    // Получаем указатели на функции
    ADD_FUNC addFunc = (ADD_FUNC)GetProcAddress(hDll, "add");
    MULTIPLY_FUNC multiplyFunc = (MULTIPLY_FUNC)GetProcAddress(hDll, "multiply");
    GREET_FUNC greetFunc = (GREET_FUNC)GetProcAddress(hDll, "greet");

    if (!addFunc || !multiplyFunc || !greetFunc) {
        std::cerr << "Не удалось найти функции в DLL!" << std::endl;
        FreeLibrary(hDll);
        return 1;
    }

    // Используем функции
    int sum = addFunc(5, 3);
    int product = multiplyFunc(4, 6);

    std::cout << "Сумма: " << sum << std::endl;
    std::cout << "Произведение: " << product << std::endl;

    greetFunc("Вова");

    // Освобождаем DLL
    FreeLibrary(hDll);

    return 0;
}