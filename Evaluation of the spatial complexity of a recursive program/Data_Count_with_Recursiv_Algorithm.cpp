#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <windows.h>
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <cstdlib>
#include <ctime>

long long stack_size = 0; // Счетчик размера стека
int countAddress;
const int numVariables = 1000000;
int* addresses[numVariables];

int f(int n)
{
    addresses[countAddress] = &n;
    countAddress++;
    //std::cout << "Адрес памяти: " << &n << std::endl;
    stack_size += sizeof(int) * 7; // Увеличиваем счетчик на размер переменных
  

    int s = 6, x = 2, у = -5;
    addresses[countAddress] = &s;
    countAddress++;
    addresses[countAddress] = &x;
    countAddress++;
    addresses[countAddress] = &у;
    countAddress++;
    //std::cout << "Адрес памяти: " << &s << std::endl;
    //std::cout << "Адрес памяти: " << &x << std::endl;
    //std::cout << "Адрес памяти: " << &у << std::endl;
    for (int ii = 0; ii < 4 * n; ii++) { s = s + 2 * ii;
    //std::cout << "Адрес памяти: " << &ii << std::endl;
    addresses[countAddress] = &ii;
    countAddress++;
    }
    у += s;
    if (n < 2) return (s + x + у);
    s = s + x * f(n - 1) + f(n - 1);
    for (int ј = 0; ј < 3; ј++) { s = s + x * f(n - 2);
    //std::cout << "Адрес памяти: " << &ј << std::endl;
    addresses[countAddress] = &ј;
    countAddress++;
    }
    for (int k = 0; k < 4; k += 2) { s++;
    //std::cout << "Адрес памяти: " << &k << std::endl;
    addresses[countAddress] = &k;
    countAddress++;
    }
    return s;
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int N = 10;
    stack_size = 0;
    countAddress = 0;
    f(N);
    printf("%s", "\nN: "); printf("%d", N);  printf("%s", " Размер стека: ");    printf("%d", stack_size);

    std::cout << "\nЗначения и их адреса:" << std::endl;
    /*for (int i = 0; i < countAddress; i++) {
        std::cout << " Адрес: " << addresses[i] << std::endl;
    }*/
     std::unordered_set<int*> uniqueAddresses;;
    for (int i = 0; i < countAddress; ++i) {
        uniqueAddresses.insert(addresses[i]);
    }
    std::cout << "\nЗначения и их адреса:" << std::endl;

    std::unordered_map<int*, int> addressCount; // Для подсчета повторений адресов
    for (int i = 0; i < countAddress; ++i) {
        addressCount[addresses[i]]++;
    }

    // Вывод таблицы
    std::cout << "\nТаблица повторений адресов:\n";
    std::cout << "Адрес\t\tКоличество\n";
    for (const auto& pair : addressCount) {
        std::cout << pair.first << "\t" << pair.second << std::endl;
    }

    std::cout << "Количество уникальных значений: " << uniqueAddresses.size() << std::endl;
    std::cout << "Количество Байт необходимых для выполнения программы: " << uniqueAddresses.size() * sizeof(int) << std::endl;

   
}
//1 = 16
//1 = 20
//2 = 48
//3 = 76
//4 = 104
//5 = 132
//6 = 160
//7 = 188
//8 = 216
//9 = 244
//10 = 272
