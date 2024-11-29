using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Sa
{
    // Структура элемента стека
    public class StackNode
    {
        public int Data { get; set; }
        public StackNode Next { get; set; }
    }

    // Класс для работы со стеком
    public class Stack
    {
        private StackNode top;

        // Свойство для получения и установки верхнего элемента стека
        public StackNode Top
        {
            get { return top; }
            set { top = value; }
        }

        // Добавление элемента в стек
        public void Push(int value)
        {
            StackNode newNode = new StackNode();
            newNode.Data = value;
            newNode.Next = top;
            top = newNode;
        }

        // Удаление элемента из стека
        public int Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Стек пуст.");
            StackNode temp = top;
            top = top.Next;
            return temp.Data;
        }

        // Получение верхнего элемента стека
        public int Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Стек пуст.");
            return top.Data;
        }

        // Проверка, пуст ли стек
        public bool IsEmpty()
        {
            return top == null;
        }

        // Получение размера стека
        public int Size()
        {
            int size = 0;
            StackNode current = top;
            while (current != null)
            {
                size++;
                current = current.Next;
            }
            return size;
        }

        // Функция для печати стека
        public void Print()
        {
            StackNode current = top;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Удаление всех элементов из стека
        public void Clear()
        {
            top = null;
        }
    }

    // Класс для быстрой сортировки Хоара
    public static class QuickSort
    {
        public static void Sort(Stack stack)
        {
            if (stack.IsEmpty() || stack.Top.Next == null)
                return;

            int pivot = stack.Peek();
            Stack left = new Stack();
            Stack middle = new Stack();
            Stack right = new Stack();

            while (!stack.IsEmpty())
            {
                int value = stack.Pop();
                if (value < pivot)
                {
                    left.Push(value);
                }
                else if (value == pivot)
                {
                    middle.Push(value);
                }
                else
                {
                    right.Push(value);
                }
            }

            Sort(left);
            Sort(right);

            Merge(stack, left, middle, right);
        }

        private static void Merge(Stack stack, Stack left, Stack middle, Stack right)
        {
            Stack temp = new Stack();

            while (!left.IsEmpty())
            {
                temp.Push(left.Pop());
            }

            while (!middle.IsEmpty())
            {
                temp.Push(middle.Pop());
            }

            while (!right.IsEmpty())
            {
                temp.Push(right.Pop());
            }

            while (!temp.IsEmpty())
            {
                stack.Push(temp.Pop());
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание стека
            Stack stack = new Stack();

            // Создание объекта Random
            Random random = new Random();

            // Добавление элементов в стек
            for (int i = 0; i < 10000; i++)
            {
                stack.Push(random.Next(1000)); // Случайные числа от 0 до 9999
            }

            // Печать исходного стека
            Console.WriteLine("Исходный стек:");
            stack.Print();

            // Измерение времени выполнения
            int t_s = Environment.TickCount;

            // Сортировка стека
            QuickSort.Sort(stack);

            int t_f = Environment.TickCount;

            // Печать отсортированного стека
            Console.WriteLine("Отсортированный стек:");
            stack.Print();

            // Очистка стека
            stack.Clear();

            Console.WriteLine("Сортировка завершена//----------------------");
            Console.WriteLine();

            Console.WriteLine("Время сортировки (в милисекундах): {0}", t_f - t_s);
            Console.WriteLine("//---------------------------------\nНажмите любую кнопку для продолжения:");
            Console.ReadKey();
        }
    }
}
