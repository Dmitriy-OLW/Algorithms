
/*
#include <iostream>

int U(int n, long& s)
{
    int i, j, k, m, x = 5;
    for (i = n + 1; i <= (5 * n); i += 2)
    {
        j = i;
        do
        {
            x += 2;
            j += 2;

        } while (j <= 3 * n);
        for (int h = 1; h <= 4 * n; h = h * 2)
            s = s + h * j;
    }
    return x;
}

void UU(void)
{
    int t, a = -1, b = -1;
    long S = 0;
    int n;  std::cout << "n = "; std::cin >> n;
    for (t = 2 * n + 1; t <= 4 * n; t += 2)
    {
        if (U(150, S) > U(t / 2, S)) {
            a = U(t, S);
            printf("%s", "y");
        }
        else {
            b = U(n, S) + U(20, S);
            printf("%s", "n");
        }
           
    }
    std::cout << "\na = " << a << "   b = " << b;
    std::cout << "   S = " << S << "\n";
}

int main()
{
    UU();
}

//75
//150







#include <iostream>

int D(int n, long s)
{
    int i, j, k, m, x = 10;
    for (i = 1; i <= (2 * n); i += 2, x += 4)
    {
        for (j = 1; j <= n; j += 1, x++)
            s = s + i * j;
    }
    while (j <= 3 * n)
    {
        j = j + j;
        s = s + j;
    }
    printf("%d", x);
    printf("%s", " ");
    return x;
}


int main()
{
    D(1, 100);
    D(2, 100);
    D(3, 100);
    D(4, 100);
    D(5, 100);
    D(6, 100);
    D(7, 100);
    D(8, 100);
    D(9, 100);
    D(10, 100);
}
*//*
#include <iostream>
int D(int n, long s)
{
    int i, j, k, m, x = 5;
    for (i = n + 1; i <= (5 * n); i += 2)
    {
        printf("%s", "1");
        j = i;
        do
        {
            x += 2;
            j += 2;
            printf("%s", "2");

        } while (j <= 3 * n);
        for (int h = 1; h <= 4 * n; h = h * 2)
            s = s + h * j;

        //printf("%s", "i");
    }
    //printf("%d", x);
    printf("%s", " ");
    return x;
}


int U(int n, long s)
{
    int i, j, k, m, x = 5;
    x = x + 3 * n + n * n;
    //printf("%d", x);
    //printf("%s", " ");
    return x;
}
int main()
{


    D(1, 100);
    D(2, 100);
    D(3, 100);
    D(4, 100);
    D(5, 100);
    D(6, 100);
    D(7, 100);
    D(8, 100);
    D(9, 100);
    D(10, 110);

}


#include <iostream>
int D(int n, long s)
{
    int i, j, k, m, x = 5;
    for (i = n + 1; i <= (5 * n); i += 2)
    {
        //printf("%s", "1");
        j = i;
        while (j <= 3 * n)
        {
            x += 2;
            j += 2;
            //printf("%s", "2");

        } 
        for (int h = 1; h <= 4 * n; h = h * 2)
            s = s + h * j;

        //printf("%s", "i");
    }
    printf("%d", x);
    printf("%s", " ");
    return x;
}


int U(int n, long s)
{
    int i, j, k, m, x = 5;
    //x = x + 3 * n + n * n;
    x = x + n * n - n;
    printf("%d", x);
    printf("%s", " ");
    return x;
}
int main()
{


    for (int i = 0; i < 100; i++) {


        if (U(i, 103) == D(i, 10)) {

            printf("%s", "+++");
        }
        else
        {
            printf("%s", "--------------------------------------------");
        }
        printf("%s", "\n");
    }

    U(1, 100);
    U(2, 100);
    U(3, 100);
    U(4, 100);
    U(5, 100);
    U(6, 100);
    U(7, 100);
    U(8, 100);
    U(9, 100);
    U(10, 100);

    D(1, 100);
    D(2, 100);
    D(3, 100);
    D(4, 100);
    D(5, 100);
    D(6, 100);
    D(7, 100);
    D(8, 100);
    D(9, 100);
    D(10, 110);

}




#include <iostream>
int D(int n, long s)
{
    int count = 0;
    count += 2;
    int i, j, k, m, x = 5; count += 1;
    
    count += 4;
    for (i = n + 1; i <= (5 * n); i += 2)
    {
        count += 4;
        j = i; count += 1;
        do
        {
            x += 2; count += 1;
            j += 2; count += 1;
            count += 2;
        } while (j <= 3 * n);
        count += 3;
        for (int h = 1; h <= 4 * n; h = h * 2) {
            count += 7;
            s = s + h * j;
        }
    }
    count += 1; //return x;
    printf("%d", n);
    printf("%s", " - ");
    printf("%d", count);
    printf("%s", "\n");
    return x;
}


int main()
{

    D(1, 100);
    D(2, 100);
    D(3, 100);
    D(4, 100);
    D(5, 100);
    D(6, 100);
    D(7, 100);
    D(8, 100);
    D(9, 100);
    D(10, 110);
    D(11, 100);
    D(12, 100);
    D(13, 100);
    D(14, 110);
    D(15, 110);
    D(16, 100);
    D(17, 100);
    D(18, 100);
    D(19, 110);

}



#include <iostream>
#include <cmath>
int count = 0;

int U(int n, long s)
{
    //count = 0;
    count += 2;
    int i, j, k, m, x = 5; count += 1;

    count += 4;
    for (i = n + 1; i <= (5 * n); i += 2)
    {
        count += 4;
        j = i; count += 1;
        do
        {
            x += 2; count += 1;
            j += 2; count += 1;
            count += 2;
        } while (j <= 3 * n);
        count += 3;
        for (int h = 1; h <= 4 * n; h = h * 2) {
            count += 7;
            s = s + h * j;
        }
    }
    count += 1; //return x;
    //printf("%d", n);
    //printf("%s", " - ");
    //printf("%d", count);
    return x;
}
void UU(int n)
{
    int t, a = -1, b = -1; count += 2;
    long S = 0; count += 1;
    count += 4;
    //int n;  std::cout << "n = "; std::cin >> n;
    count += 5;
    for (t = 2 * n + 1; t <= 4 * n; t += 2)
    {
        count += 3;
        count += 9;
        if (U(150, S) > U(t / 2, S)) {
            count += 5;
            a = U(t, S);
            //printf("%d", t);
            //printf("%s", " yes\n");
        }
        else {
            count += 10;
            b = U(n, S) + U(20, S);
            //printf("%d", t);
            //printf("%s", " no\n");
        }

    }
    count += 11;
    //std::cout << "\na = " << a << "   b = " << b;
    //std::cout << "   S = " << S << "\n";
}





int main()
{

    for (int i = 500; i <= 510; i++) {
        count = 0;
        UU(i);
        printf("%d", i);
        printf("%s", " - ");
        printf("%d", count);

        printf("%s", "\n");
    }


}






#include <iostream>

int f(int n)
{

    int s = 6, x = 2, у = -5; 
    for (int ii = 0; ii < 4 * n; ii++) s = s + 2 * ii; у += s;
    if (n < 2) return (s + x + у);
    s = s + x * f(n - 1) + f(n - 1);
    for (int ј = 0; ј < 3; ј++) s = s + x * f(n - 2);
    for (int k = 0; k < 4; k += 2) s++;
    return s;
}

int main()
{
    f(2);
    //std::cout<<f(2);


}

#include <iostream>
int count = 0;
int f(int n)
{
   
    count += 1;
    
    int s = 6, x = 2, у = -5; count += 6;
    for (int ii = 0; ii < 4 * n; ii++) { s = s + 2 * ii; count += 6; }
    у += s; count += 2;
    if (n < 2) { count += 3; return (s + x + у);  }
    count += 8;
    s = s + x * f(n - 1) + f(n - 1);
    count += 2;
    for (int ј = 0; ј < 3; ј++) { s = s + x * f(n - 2); count += 7; }
    count += 2;
    for (int k = 0; k < 4; k += 2) { s++; count += 3;}
    count += 1;
    return s;
}

int main()
{
    count = 0;
    f(3);
    std::cout<< count;


}

*/
#include <stdio.h> 
#include <conio.h> 
#include "iostream" 
#include <windows.h> 

#define VAR 536   // номер варианта задания 

long long k = 2, N, r, q, N_op, k_0 = 1;

int count = 0;

long long f(int n)
{
    if (n >= k)   // k - порядок рекурсии 
    {    // внутренний узел дерева рекурсии 
        //r++;  // Подсчет числа внутренних узлов дерева рекурсии   

        // здесь указать рекуррентную формулу роста трудоемкости алгоритма: 
        return 22 + 24*n + 2*f(n - 1) + 21 + 3 * f(n - 2) + 6;
       //return 22 + 24 * n + (f(n - 1) * f(n - 1)) + 21 + f(n - 2) * f(n - 2) * f(n - 2) + 6; //Модификация программы для правильного подсчёта листьев и узлов
    }
    else     // начальное условие, лист дерева рекурсии 
    {
        //q++;  // Подсчет числа листьев дерева рекурсии   

        // здесь указать формулу роста трудоемкости алгоритма в листьях дерева рекрсии 
        return 12 + 24 * n;
    }
}
long long fg(int n)
{
    printf("%d", n); printf("%s", " ");
    if (n >= k)   // k - порядок рекурсии 
    {    // внутренний узел дерева рекурсии 
        r++;  // Подсчет числа внутренних узлов дерева рекурсии   

        // здесь указать рекуррентную формулу роста трудоемкости алгоритма: 
        //return 22 + 24*n + 2*f(n - 1) + 21 + 3 * f(n - 2) + 6;
        return 22 + 24 * n + (fg(n - 1) * fg(n - 1)) + 21 + fg(n - 2) * fg(n - 2) * fg(n - 2) + 6; //Модификация программы для правильного подсчёта листьев и узлов
    }
    else     // начальное условие, лист дерева рекурсии 
    {
        q++;  // Подсчет числа листьев дерева рекурсии   
        
        // здесь указать формулу роста трудоемкости алгоритма в листьях дерева рекрсии 
        return 12 + 24 * n;
    }
}

int FFF(int n)
{
    printf("%d", count);
    count += 1;

    int s = 6, x = 2, у = -5; count += 6;
    for (int ii = 0; ii < 4 * n; ii++) { s = s + 2 * ii; count += 6; }
    у += s; count += 2;
    if (n < 2) { count += 3;  return (s + x + у); }
    count += 8;
    s = s + x * FFF(n - 1) + FFF(n - 1);
    count += 2;
    for (int ј = 0; ј < 3; ј++) { s = s + x * FFF(n - 2); count += 7; }
    count += 2;
    for (int k = 0; k < 4; k += 2) { s++; count += 3; }
    count += 1;
    return s;
}


int main(void)
{
    for (N = 0; N <= 5; N++)
    {
        fg(N);
        printf("%s", "\n");
    }
   for (int i = 0; i < 30; i++) {
        count = 0;
        FFF(i);
        printf("%d", count); printf("%s", " : "); printf("%d", f(i));
        
        if (count == f(i)) {
            printf("%s", "\nyes: "); 

        }
        else {
            printf("%s", "\nno: ");
        }
    }

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    std::cout << "\n";

    int N,    // Глубина рекурсии 
        N_max;  // Максимальная глубина рекурсии  
    N_max = 30;   // Указать значение, такое что время работы рекурсивного алгоритма  
    // составляло бы порядок 10^14 числа операций 
    long long t1, t2;

    for (N = 0; N <= N_max; N++)
    {
        r = 0;    // Общее количество внутренних узлов 
        q = 0;    // Общее количество листьев 
        t1 = GetTickCount(); // фиксируем момент начала выполнения рекурсивной функции 

        N_op = f(N); // Общее количество инструкций 
        fg(N);
        t2 = GetTickCount(); // фиксируем момент завершения выполнения рекурсивной функции 
        
        std::cout << "  N = " << N << " r = " << r << " q = " << q << " r+q = " << r + q;
        std::cout << " N_op = " << N_op << " T = " << t2 - t1 << "\n";
    }
    std::cout << "\n Для завершения нажмите любую клавишу...";
    //getch();
   
}

