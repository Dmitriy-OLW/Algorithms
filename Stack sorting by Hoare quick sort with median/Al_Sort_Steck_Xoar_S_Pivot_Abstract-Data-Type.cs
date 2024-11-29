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


