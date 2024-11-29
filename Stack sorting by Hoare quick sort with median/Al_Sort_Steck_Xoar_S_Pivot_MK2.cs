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

