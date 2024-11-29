/*using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Al_Sort_Steck_Xoar_S_Pivot
{
    public class Item
    {
        public int value = 0;
        public Item next = null;
        public Item(int value = 0, Item next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    public class Stack
    {
        public int N_op = 0;
        private Item top = null;
        public int Disp_N()
        {
            int Nnew = N_op;
            N_op = 0;
            return Nnew;
        }

        //Проверка пуст ли стек
        public bool isEmpty()  //2
        {
            N_op += 2;
            return top == null;   //2
        }
        public void Del() //1+ Σ_1^n(1+1+1+1+1+1)
        {
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1+1+1)
            {
                N_op++;
                N_op++; current.value = 0; //1
                N_op++; current = current.next; //1
                N_op++; Item result = top; //1
                N_op++; top = top.next; //1

                result.next = null; //1
            }
            N_op++;

        }
        //Количество элементов в стеке
        public int stackLenght() //3+Σ_1^n(1+1+1)
        {
            N_op++; int count = 0; //1
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1)
            {
                N_op++;
                N_op++; count++; //1
                N_op++; current = current.next; //1
            }
            N_op++;
            N_op++; return count; //1
        }
        //извлечение элемента
        public Item Pop() //2+1+1+1+1 = 6 (в случае выполнения if +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            N_op++; Item result = top; //1
            N_op++; top = top.next; //1

            N_op++; result.next = null; //1
            N_op++; return result; //1
        }
        //добавление элемента
        public void Push(Item item) //4+1=5
        {
            if (!isEmpty()) //1+2
            {
                N_op++; item.next = top; //1
            }
            N_op++; top = item;//1
        }
        //Вывод всех значений
        public void Print() //3 + Σ_1^n(1+1+1+1)
        {
            N_op++; Console.Write("В стеке сейчас находится =>: "); //1
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1+1)
            {
                N_op++;
                N_op++; Console.Write(current.value); //1
                N_op++; Console.Write("; "); //1
                N_op++; current = current.next; //1
            }
            N_op++;
            N_op++; Console.WriteLine(); //1
        }
        //Получение значения из стека
        public int Get(int pos, Stack tmp) //2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            N_op++;
            for (int i = 0; i < pos; i++) //1+Σ_0^n(1+1+11)
            {
                N_op++;
                N_op++;
                N_op += 11;
                tmp.Push(Pop()); //5 + 6 = 11
            }
            N_op++;
            int result;
            N_op++; if (!isEmpty()) //3
            { N_op++; result = top.value; } //1
            else { N_op++; result = 0; }


            while (!tmp.isEmpty()) //  Σ_0^n(1+2 + 11)
            {
                N_op++;
                N_op += 11;
                Push(tmp.Pop());    //11
            }
            N_op++;
            N_op++; return result; //1
        }
        //записать новое значение
        public void Set(int pos, int newValue, Stack tmp) //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            for (int i = 0; i < pos; i++) //1+Σ_0^n(13)
            {
                N_op++;
                N_op++;
                N_op += 11;
                tmp.Push(Pop()); //11
            }
            N_op++;
            N_op++; top.value = newValue; //1
            while (!tmp.isEmpty()) //  Σ_0^n(1+2 + 11)
            {
                N_op++;
                N_op += 11;
                Push(tmp.Pop()); //11
            }
            N_op++;
        }
        public int this[int index]
        {
            get => Get(index, new Stack()); //2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
            set => Set(index, value, new Stack()); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        }

    }


    internal class Program
    {

        public static long N_op_all;
        //public static long[] N_op_Mass;
        //метод возвращающий индекс опорного элемента
        static int Partition(Stack stack, int minIndex, int maxIndex) //1+1+ {1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]} + {1+1+ [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]}
        {
            N_op_all++; Stack _tmp = new Stack(); //1
            N_op_all += 2; int pivot = minIndex - 1; //2
            N_op_all++;
            for (int i = minIndex; i < maxIndex; i++) //1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]
            {
                N_op_all++;
                N_op_all++;
                N_op_all++;
                if (stack.Get(i, _tmp) < stack.Get(maxIndex, _tmp)) //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                {
                    N_op_all++; pivot++; //1
                    N_op_all++; int tyter_1 = stack.Get(pivot, _tmp); //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                    stack.Set(pivot, stack.Get(i, _tmp), _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                    stack.Set(i, tyter_1, _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)
                }
            }

            N_op_all++; pivot++; //1
            N_op_all++; int tamer_2 = stack.Get(pivot, _tmp); //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
            stack.Set(pivot, stack.Get(maxIndex, _tmp), _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
            stack.Set(maxIndex, tamer_2, _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)

            N_op_all += _tmp.Disp_N();


            N_op_all++; return pivot; //1
        }

        //быстрая сортировка
        static Stack QuickSort(Stack stack, int minIndex, int maxIndex) // Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)
        {
            N_op_all++;
            if (minIndex >= maxIndex) //1
            {
                N_op_all++; return stack; //1
            }

            N_op_all++; N_op_all++; int pivotIndex = Partition(stack, minIndex, maxIndex); // 162n^2+477n+346 ==  //1+1+ {1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]} + {1+1+ [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]}
            N_op_all++; N_op_all++; QuickSort(stack, minIndex, pivotIndex - 1);// Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)
            N_op_all++; N_op_all++; QuickSort(stack, pivotIndex + 1, maxIndex);// Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)

            return stack; //1
        }

        static Stack QuickSort(Stack stack)
        {
            N_op_all++; N_op_all++; N_op_all++; return QuickSort(stack, 0, stack.stackLenght() - 1); //3+ Σ_0^log(n)(1+1+1+ 6 +  162n^2+477n+346)
        }

        static void Main(string[] args)
        {

            Stack _stack = new Stack();
            Stack _sohran = new Stack();
            Stack Best_sohran = new Stack();

            int i, t_f, t_s;

            Random rand = new Random();
            for (int j = 0; j < 1000; j++)
            {
                _sohran.Push(new Item(rand.Next(0, 1000)));
            }



           *//* for (int j = 0; j < 1000; j++)
            {
                _sohran.Push(new Item(j));
            }

            for (int j = 0; j < 1000; j++)
            {
                Best_sohran.Push(new Item(j));
            }
            for (int j = 0; j < 1000; j++)
            {
                _sohran.Push(Best_sohran.Pop());
            }*//*
            //_sohran.Print();


            //_sohran.Print();


            for (i = 0; i < 10; i++)
            {

                Stack _tmp_first = new Stack();
                for (int j = 0; j < 100 * (i + 1); j++)
                {
                    _stack.Push(new Item(_sohran.Get(j, _tmp_first)));
                }
                Console.WriteLine("Сортировка #{0} началась...", i + 1);
                _stack.Print();
                Console.WriteLine();
                N_op_all = 0;
                t_s = Environment.TickCount;
                QuickSort(_stack);
                t_f = Environment.TickCount;
                Console.WriteLine("Сортировка завершена//----------------------");
                //Console.WriteLine(_stack.stackLenght());
                //Console.WriteLine();

                _stack.Print();
                Console.WriteLine();

                N_op_all += _stack.Disp_N();

                Console.WriteLine("Данные сортировки #{0}", i + 1);
                Console.WriteLine("Количество отсортированных элементов: {0}", (i + 1) * 100);
                Console.WriteLine("Время сортировки (в милисикундах): {0}", t_f - t_s);
                Console.WriteLine("Колочество операций (N_op): {0}", N_op_all);

                _stack.Del();
                Console.WriteLine();
                Console.WriteLine("//---------------------------------\nНажмите любую кнопку для продолжения:\n");
                Console.ReadKey();
            }



            _stack.Del();
            _sohran.Del();


            


            Console.ReadLine();
        }


    }
}





*/










































/*


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Al_Sort_Steck_Xoar_S_Pivot
{
    public class Item
    {
        public int value = 0;
        public Item next = null;
        public Item(int value = 0, Item next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    public class Stack
    {
        public int N_op = 0;
        private Item top = null;
        public int Disp_N()
        {
            int Nnew = N_op;
            N_op = 0;
            return Nnew;
        }

        //Проверка пуст ли стек
        public bool isEmpty()  //2
        {
            N_op += 2;
            return top == null;   //2
        }
        public void Del() //1+ Σ_1^n(1+1+1+1+1+1)
        {
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1+1+1)
            {
                N_op++;
                N_op++; current.value = 0; //1
                N_op++; current = current.next; //1
                N_op++; Item result = top; //1
                N_op++; top = top.next; //1

                result.next = null; //1
            }
            N_op++;

        }
        //Количество элементов в стеке
        public int stackLenght() //3+Σ_1^n(1+1+1)
        {
            N_op++; int count = 0; //1
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1)
            {
                N_op++;
                N_op++; count++; //1
                N_op++; current = current.next; //1
            }
            N_op++;
            N_op++; return count; //1
        }
        //извлечение элемента
        public Item Pop() //2+1+1+1+1 = 6 (в случае выполнения if +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            N_op++; Item result = top; //1
            N_op++; top = top.next; //1

            N_op++; result.next = null; //1
            N_op++; return result; //1
        }
        //добавление элемента
        public void Push(Item item) //4+1=5
        {
            if (!isEmpty()) //1+2
            {
                N_op++; item.next = top; //1
            }
            N_op++; top = item;//1
        }
        //Вывод всех значений
        public void Print() //3 + Σ_1^n(1+1+1+1)
        {
            N_op++; Console.Write("В стеке сейчас находится =>: "); //1
            N_op++; Item current = top; //1
            while (current != null) //Σ_1^n(1+1+1+1)
            {
                N_op++;
                N_op++; Console.Write(current.value); //1
                N_op++; Console.Write("; "); //1
                N_op++; current = current.next; //1
            }
            N_op++;
            N_op++; Console.WriteLine(); //1
        }
        //Получение значения из стека
        public int Get(int pos, Stack tmp) //2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            N_op++;
            for (int i = 0; i < pos; i++) //1+Σ_0^n(1+1+11)
            {
                N_op++;
                N_op++;
                N_op += 11;
                tmp.Push(Pop()); //5 + 6 = 11
            }
            N_op++;
            int result;
            N_op++; if (!isEmpty()) //3
            { N_op++; result = top.value; } //1
            else { N_op++; result = 0; }


            while (!tmp.isEmpty()) //  Σ_0^n(1+2 + 11)
            {
                N_op++;
                N_op += 11;
                Push(tmp.Pop());    //11
            }
            N_op++;
            N_op++; return result; //1
        }
        //записать новое значение
        public void Set(int pos, int newValue, Stack tmp) //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        {
            if (isEmpty()) //2
            {
                N_op++; throw new Exception("Стек пуст!!!"); //1
            }
            for (int i = 0; i < pos; i++) //1+Σ_0^n(13)
            {
                N_op++;
                N_op++;
                N_op += 11;
                tmp.Push(Pop()); //11
            }
            N_op++;
            N_op++; top.value = newValue; //1
            while (!tmp.isEmpty()) //  Σ_0^n(1+2 + 11)
            {
                N_op++;
                N_op += 11;
                Push(tmp.Pop()); //11
            }
            N_op++;
        }
        public int this[int index]
        {
            get => Get(index, new Stack()); //2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
            set => Set(index, value, new Stack()); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + (в случае выполнения if ошибки +1)
        }

    }


    internal class Program
    {

        public static long N_op_all;
        //public static long[] N_op_Mass;
        //метод возвращающий индекс опорного элемента
        static int Partition(Stack stack, int minIndex, int maxIndex) //1+1+ {1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]} + {1+1+ [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]}
        {
            N_op_all++; Stack _tmp = new Stack(); //1
            N_op_all += 2; int pivot = minIndex - 1; //2
            N_op_all++;
            for (int i = minIndex; i < maxIndex; i++) //1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]
            {
                N_op_all++;
                N_op_all++;
                N_op_all++;
                if (stack.Get(i, _tmp) < stack.Get(maxIndex, _tmp)) //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                {
                    N_op_all++; pivot++; //1
                    N_op_all++; int tyter_1 = stack.Get(pivot, _tmp); //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                    stack.Set(pivot, stack.Get(i, _tmp), _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
                    stack.Set(i, tyter_1, _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)
                }
            }

            N_op_all++; pivot++; //1
            N_op_all++; int tamer_2 = stack.Get(pivot, _tmp); //1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
            stack.Set(pivot, stack.Get(maxIndex, _tmp), _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)
            stack.Set(maxIndex, tamer_2, _tmp); //2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)

            
            N_op_all += _tmp.Disp_N();


            N_op_all++; return pivot; //1
        }

        //быстрая сортировка
        static Stack QuickSort(Stack stack, int minIndex, int maxIndex) // Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)
        {
            N_op_all++;
            if (minIndex >= maxIndex) //1
            {
                N_op_all++; return stack; //1
            }

            N_op_all++; N_op_all++; int pivotIndex = Partition(stack, minIndex, maxIndex); // 162n^2+477n+346 ==  //1+1+ {1 + Σ_0^n(1+1 + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]} + {1+1+ [1] + [1 + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)] + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11) + 2+1+Σ_0^n(13) +3+1+1+Σ_0^n(1+2 + 11)]  + [2+1+Σ_0^n(13) +1+Σ_0^n(1+2 + 11)]}
            N_op_all++; N_op_all++; QuickSort(stack, minIndex, pivotIndex - 1);// Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)
            N_op_all++; N_op_all++; QuickSort(stack, pivotIndex + 1, maxIndex);// Σ_0^log(n)(  1+1+1+ 6 +  162n^2+477n+346)

            return stack; //1
        }

        static Stack QuickSort(Stack stack)
        {
            N_op_all++; N_op_all++; N_op_all++; return QuickSort(stack, 0, stack.stackLenght() - 1); //3+ Σ_0^log(n)(1+1+1+ 6 +  162n^2+477n+346)
        }

        static void Main(string[] args)
        {

            Stack _stack = new Stack();
            Stack _sohran = new Stack();
            Stack Best_sohran = new Stack();

            int i, t_f, t_s;

            *//*Random rand = new Random();
            for (int j = 0; j < 1000; j++)
            {
                _sohran.Push(new Item(rand.Next(0, 1000)));
            }*/

/*       for (int j = 0; j < 50; j++)
       {
           Best_sohran.Push(new Item(j));
       }
       for (int j = 0; j < 50; j++)
       {
           _sohran.Push(Best_sohran.Pop());
       }*//*

       for (int j = 0; j < 300; j++)
       {
           _sohran.Push(new Item(j));
       }




       for (i = 0; i < 10; i++)
       {

           Stack _tmp_first = new Stack();
           for (int j = 0; j < 30 * (i + 1); j++)
           {
               _stack.Push(new Item(_sohran.Get(j, _tmp_first)));
           }
           //Console.WriteLine("Сортировка #{0} началась...", i + 1);
           //_stack.Print();
           //Console.WriteLine();
           N_op_all = 0;
           t_s = Environment.TickCount;
           QuickSort(_stack);
           t_f = Environment.TickCount;
           //Console.WriteLine("Сортировка завершена//----------------------");
           //Console.WriteLine(_stack.stackLenght());
           //Console.WriteLine();

           //_stack.Print();
           //Console.WriteLine();

           N_op_all += _stack.Disp_N();

           Console.WriteLine("Данные сортировки #{0}", i + 1);
           Console.WriteLine("Количество отсортированных элементов: {0}", (i + 1) * 30);
           Console.WriteLine("Время сортировки (в милисикундах): {0}", t_f - t_s);
           Console.WriteLine("Колочество операций (N_op): {0}", N_op_all);

           _stack.Del();
           Console.WriteLine();
           //Console.WriteLine("//---------------------------------\nНажмите любую кнопку для продолжения:\n");
           //Console.ReadKey();
       }


       _stack.Del();
       _sohran.Del();





       Console.ReadLine();
   }


}
}



*/











/*
 using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Al_Sort_Steck_Xoar_S_Pivot
{
    public class Item
    {
        public int value = 0;
        public Item next = null;
        public Item(int value = 0, Item next = null)
        { 
            this.value = value;
            this.next = next;
        }
    }

    public class Stack
    {
        private Item top = null;
        //Проверка пуст ли стек
        public bool isEmpty()
        {
            return top == null; 
        }
        public void Del()
        {
            Item current = top;
            while (current != null)
            {
                current.value = 0;
                current = current.next;
                Item result = top;
                top = top.next;

                result.next = null;
            }

        }
        //Количество элементов в стеке
        public int stackLenght()
        {
            int count = 0;
            Item current = top;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
       //извлечение элемента
        public Item Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            Item result = top;
            top = top.next;

            result.next = null;
            return result;
        }
        //добавление элемента
        public void Push(Item item)
        {
            if (!isEmpty())
            {
                item.next = top;
            }
            top = item;
        }
        //Вывод всех значений
        public void Print()
        {
            Console.Write("В стеке сейчас находится =>: ");
            Item current = top;
            while(current != null)
            {
                Console.Write(current.value);
                Console.Write("; ");
                current = current.next;
            }
            Console.WriteLine();
        }
        //Получение значения из стека
        public int Get(int pos, Stack tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            for (int i = 0; i < pos; i++)
            {
                tmp.Push(Pop());
            }
            int result;
            if (!isEmpty()) {result = top.value; }
            else{result = 0;}
            

            while (!tmp.isEmpty())
            {
                Push(tmp.Pop());    
            }
            return result;
        }
        //записать новое значение
        public void Set(int pos,int newValue, Stack tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            for (int i = 0; i < pos; i++)
            {
                tmp.Push(Pop());
            }
            top.value = newValue;
            while (!tmp.isEmpty())
            {
                Push(tmp.Pop());
            }
        }
        public int this[int index]
        {
            get => Get(index, new Stack());
            set => Set(index, value, new Stack());
        }

    }


    internal class Program
    {
        

        //метод возвращающий индекс опорного элемента
        static int Partition(Stack stack, int minIndex, int maxIndex)
        {
            Stack _tmp = new Stack();
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (stack.Get(i, _tmp) < stack.Get(maxIndex, _tmp))
                {
                    pivot++;
                    int tyter_1 = stack.Get(pivot, _tmp);
                    stack.Set(pivot, stack.Get(i, _tmp), _tmp);
                    stack.Set(i, tyter_1, _tmp);
                }
            }

            pivot++;
            int tamer_2 = stack.Get(pivot, _tmp);
            stack.Set(pivot, stack.Get(maxIndex, _tmp), _tmp);
            stack.Set(maxIndex, tamer_2, _tmp);
            return pivot;
        }

        //быстрая сортировка
        static Stack QuickSort(Stack stack, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return stack;
            }

            var pivotIndex = Partition(stack, minIndex, maxIndex);
            QuickSort(stack, minIndex, pivotIndex - 1);
            QuickSort(stack, pivotIndex + 1, maxIndex);

            return stack;
        }

        static Stack QuickSort(Stack stack)
        {
            return QuickSort(stack, 0, stack.stackLenght() - 1);
        }

        static void Main(string[] args)
        {
            
            Stack _stack = new Stack();
            Stack _sohran = new Stack();

            int i, t_f, t_s;

            Random rand = new Random();
            for (int j = 0; j < 1000; j++)
            {
                _sohran.Push(new Item(rand.Next(0, 1000)));
            }
            for (i = 0; i < 10; i++)
            {

                Stack _tmp_first = new Stack();
                for (int j = 0;j < 100*(i+1); j++)
                {
                    _stack.Push(new Item(_sohran.Get(j, _tmp_first)));
                }
                Console.WriteLine("Сортировка #{0}", i+1);
                _stack.Print();
                //Console.WriteLine();
                t_s = Environment.TickCount;
                QuickSort(_stack);
                t_f = Environment.TickCount;
                //Console.WriteLine(_stack.stackLenght());
                Console.WriteLine("Сортировка завершена//----------------------");
                Console.WriteLine();

                
                _stack.Print();
                Console.WriteLine();

                _stack.Del();

                Console.WriteLine("Сортировка #{0}", i + 1);
                Console.WriteLine("Количество отсортированных элементов: {0}", (i+1)*100);
                Console.WriteLine("Время сортировки (в милисикундах): {0}", t_f-t_s);
                Console.WriteLine("//---------------------------------\nНажмите любую кнопку для продолжения:");
                Console.ReadKey();
            }

           

            _stack.Del();
            _sohran.Del();

            //_stack.Print();
            //Console.WriteLine();


            Console.ReadLine();
        }


    }
}
*/











using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;

namespace Al_Sort_Steck_Xoar_S_Pivot
{
    public class Item<T>
    {
        public T value;
        public Item<T> next;

        public Item(T value = default(T), Item<T> next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    public class Stack<T>
    {
        private Item<T> top = null;

        public bool isEmpty()
        {
            return top == null;
        }

        public void Del()
        {
            Item<T> current = top;
            while (current != null)
            {
                current.value = default(T);
                current = current.next;
                Item<T> result = top;
                top = top.next;
                result.next = null;
            }
        }

        public int stackLength()
        {
            int count = 0;
            Item<T> current = top;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        public Item<T> Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            Item<T> result = top;
            top = top.next;
            result.next = null;
            return result;
        }

        public void Push(Item<T> item)
        {
            if (!isEmpty())
            {
                item.next = top;
            }
            top = item;
        }

        public void Print()
        {
            Console.WriteLine("В стеке сейчас находится =>: ");
            Item<T> current = top;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
            Console.WriteLine();
        }

        public T Get(int pos, Stack<T> tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            for (int i = 0; i < pos; i++)
            {
                tmp.Push(Pop());
            }
            T result;
            if (!isEmpty())
            {
                result = top.value;
            }
            else
            {
                result = default(T);
            }

            while (!tmp.isEmpty())
            {
                Push(tmp.Pop());
            }
            return result;
        }

        public void Set(int pos, T newValue, Stack<T> tmp)
        {
            if (isEmpty())
            {
                throw new Exception("Стек пуст!!!");
            }
            for (int i = 0; i < pos; i++)
            {
                tmp.Push(Pop());
            }
            top.value = newValue;
            while (!tmp.isEmpty())
            {
                Push(tmp.Pop());
            }
        }

        public T this[int index]
        {
            get => Get(index, new Stack<T>());
            set => Set(index, value, new Stack<T>());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Stack<object> Stack = new Stack<object>();
            Stack<object> Stack_stack = new Stack<object>();

            Stack.Push(new Item<object>("Стек"));
            Stack.Push(new Item<object>('A'));
            Stack.Push(new Item<object>(999999999));
            Stack.Push(new Item<object>(1.122));
            Stack.Push(new Item<object>(Stack_stack));

            Console.WriteLine("Это работает: " + Stack[2]);
            Stack[2] = "123456789";
            Console.WriteLine("Это работает: " + Stack[2]);

            //Console.WriteLine("Стек для всего: \n ");
            //Stack.Print();

            Console.ReadKey();
        }
    }

}


