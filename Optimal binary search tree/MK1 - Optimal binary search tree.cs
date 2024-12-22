using System;
using System.Collections.Generic;

// Класс узла дерева
public class Node
{
    public string Key;
    public int Weight;
    public int Value;
    public int Height;
    public Node[] Children = new Node[2];
    public Node Parent;

    public Node(string key, int weight)
    {
        Key = key;
        Weight = weight;
        Value = 0;
        Height = 1;
    }
}

//------------------------------------------------------------------------------------------------------------------------------------
// Класс: Оптимальное дерево двоичного поиска
public class OptimalBinarySearchTree
{
    private Node root;

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод добавления нового узла
    public void Add(string key, int weight)
    {
        Node newNode = new Node(key, weight);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current.Children[0] == null)
            {
                current.Children[0] = newNode;
                newNode.Parent = current;
                break;
            }
            else
            {
                queue.Enqueue(current.Children[0]);
            }

            if (current.Children[1] == null)
            {
                current.Children[1] = newNode;
                newNode.Parent = current;
                break;
            }
            else
            {
                queue.Enqueue(current.Children[1]);
            }
        }

        if (newNode.Weight > newNode.Parent.Weight)
        {
            Rebalance(newNode);
        }
        //UpdateHeights(newNode);
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод перемещения узла с большим весом вверх
    private void Rebalance(Node node)
    {
        //Console.WriteLine("//-----------------------------------");
        //PrintTree();
        while (node.Parent != null && node.Weight > node.Parent.Weight)
        {
            int num;
            Node Parent_Children_2;
            Node Node_Children_1;
            Node Node_Children_2;
            if (node.Parent.Children[0] == node)
            {
                num = 0;
                Parent_Children_2 = node.Parent.Children[1];
            }
            else
            {
                num = 1;
                Parent_Children_2 = node.Parent.Children[0];
            }
            Node_Children_1 = node.Children[0];
            Node_Children_2 = node.Children[1];

            node.Children[num] = node.Parent;
            if (Parent_Children_2 != null)
            {
                Parent_Children_2.Parent = node;
            }

            if (num == 0)
            {

                node.Children[1] = Parent_Children_2;
            }
            else
            {
                node.Children[0] = Parent_Children_2;
            }
            if (node.Parent.Parent == null)
            {

                root = node;
            }
            else
            {
                if (node.Parent.Parent.Children[0] == node.Parent)
                {
                    node.Parent.Parent.Children[0] = node;
                }
                else
                {
                    node.Parent.Parent.Children[1] = node;
                }

            }

            node.Parent = node.Parent.Parent;


            node.Children[num].Parent = node;

            if (Node_Children_1 != null)
            {
                Node_Children_1.Parent = node.Children[num];
            }
            if (Node_Children_2 != null)
            {
                Node_Children_2.Parent = node.Children[num];
            }

            node.Children[num].Children[0] = Node_Children_1;
            node.Children[num].Children[1] = Node_Children_2;

            //PrintTree();
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Инициализация метода вывода
    public void PrintTree()
    {
        Console.WriteLine("//--------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine();
        PrintTree(root, true, "");
        Console.WriteLine();
        Console.WriteLine();
    }

    // Метод вывода дерева
    private void PrintTree(Node node, bool right, string stick)
    {
        if (node != null)
        {
            Console.Write(stick);
            if (right)
            {
                Console.Write("R---- ");
                stick += "   ";
            }
            else
            {
                Console.Write("L---- ");
                stick += "   ";
            }
            string s;

            if (node.Parent == null) { s = "null"; }
            else
            { s = node.Parent.Key; }
            Console.WriteLine($"Key: {node.Key} (Weight: {node.Weight}; Value:  {node.Value}; Height: {node.Height}; Parent: {s}.)");
            PrintTree(node.Children[1], true, stick);
            PrintTree(node.Children[0], false, stick);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод изменения значения
    public void UpdateValue(string key, int newValue)
    {
        Node node = FindNode(root, key);
        if (node != null)
        {
            node.Value = newValue;
        }
        else
        {
            Console.WriteLine($"Node with key '{key}' not found.");
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод нахождения узла по ключу
    private Node FindNode(Node node, string key)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Key == key)
        {
            return node;
        }

        Node foundNode = FindNode(node.Children[0], key);
        if (foundNode != null)
        {
            return foundNode;
        }

        return FindNode(node.Children[1], key);
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод для установки высоты узла
    public void SetHeight(Node node)
    {
        if (node.Parent == null)
        {
            node.Height = 1;
        }
        else
        {
            node.Height = node.Parent.Height + 1;
        }
    }

    // Метод для обновления высоты всех узлов
    public void UpdateHeights()
    {
        UpdateHeights(root);
    }

    private void UpdateHeights(Node node)
    {
        if (node != null)
        {
            SetHeight(node);
            UpdateHeights(node.Children[0]);
            UpdateHeights(node.Children[1]);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод для подсчета средневзвешенной высоты дерева
    public void PrintCalculateWeightedAverageHeight()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Cредневзвешенная высота построенного дерева: " + CalculateWeightedAverageHeight());
        Console.WriteLine();
        Console.WriteLine();
    }

    public double CalculateWeightedAverageHeight()
    {
        double totalWeight = CalculateTotalWeight(root);
        if (totalWeight == 0) return 0;

        double weightedHeightSum = CalculateWeightedHeightSum(root);
        if (weightedHeightSum == 0) return 0;

        return weightedHeightSum / totalWeight;
    }

    private double CalculateWeightedHeightSum(Node node)
    {
        if (node == null) return 0;
        return (node.Weight * node.Height) + CalculateWeightedHeightSum(node.Children[0]) + CalculateWeightedHeightSum(node.Children[1]);
    }

    private double CalculateTotalWeight(Node node)
    {
        if (node == null) return 0;
        return node.Weight + CalculateTotalWeight(node.Children[0]) + CalculateTotalWeight(node.Children[1]);
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод для копирования дерева
    public void CopyTree(OptimalBinarySearchTree sourceTree)
    {
        if (sourceTree.root != null)
        {
            root = CopyNode(sourceTree.root, null);
        }
    }

    // Вспомогательный метод для рекурсивного копирования узлов
    private Node CopyNode(Node sourceNode, Node parent)
    {
        if (sourceNode == null)
        {
            return null;
        }

        Node newNode = new Node(sourceNode.Key, sourceNode.Weight)
        {
            Value = sourceNode.Value,
            Height = sourceNode.Height,
            Parent = parent
        };

        newNode.Children[0] = CopyNode(sourceNode.Children[0], newNode);
        newNode.Children[1] = CopyNode(sourceNode.Children[1], newNode);

        return newNode;
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод для получения итератора
    public BinaryTreeIterator GetIterator()
    {
        return new BinaryTreeIterator(root);
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    // Метод реализующий перебор узлов прямым обходом с помощью цикла range-for
    public IEnumerable<Node> GetNodes()
    {
        Stack<Node> stack = new Stack<Node>();
        if (root != null)
        {
            stack.Push(root);
        }

        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            yield return current;

            if (current.Children[1] != null)
            {
                stack.Push(current.Children[1]);
            }
            if (current.Children[0] != null)
            {
                stack.Push(current.Children[0]);
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------

}

// Класс итератора для обхода дерева
public class BinaryTreeIterator
{
    private Stack<Node> stack = new Stack<Node>();

    public BinaryTreeIterator(Node root)
    {
        if (root != null)
        {
            stack.Push(root);
        }
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    public Node Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more nodes to iterate.");
        }

        Node current = stack.Pop();

        // Сначала добавляем правый узел, затем левый, чтобы левый узел был на вершине стека
        if (current.Children[1] != null)
        {
            stack.Push(current.Children[1]);
        }
        if (current.Children[0] != null)
        {
            stack.Push(current.Children[0]);
        }

        return current;
    }
}




public class Program
{
    public static void Main()
    {
        // Пример заполнения сложного дерева
        /*OptimalBinarySearchTree tree = new OptimalBinarySearchTree();
        tree.Add("A", 10);
        tree.Add("B", 5);
        tree.Add("C", 15);
        tree.Add("D", 3);
        tree.Add("E", 7);
        tree.Add("F", 12);
        tree.Add("G", 18);
        tree.Add("W", 2);
        tree.Add("K", 1);
        tree.Add("Y", 2);
        tree.Add("E", 7);
        tree.Add("W", 2);
        tree.Add("K", 1);
        tree.Add("Y", 2);
        tree.Add("P", 4);
        tree.Add("A", 1);
        tree.Add("H", 3);
        tree.Add("O", 3);
        tree.Add("B", 2);
        tree.Add("E", 1);
        tree.Add("J", 2);
        tree.Add("H", 1);
        tree.Add("И", 1);
        tree.Add("T", 1);

        tree.Add("A", 5);   
        tree.Add("B", 15);  
        tree.Add("C", 3);   
        tree.Add("D", 20);  
        tree.Add("E", 4);   
        tree.Add("F", 25);  
        tree.Add("G", 2);   
        tree.Add("H", 30);  
        tree.Add("I", 1);   
        tree.Add("J", 35);  
        tree.Add("K", 6);   
        tree.Add("L", 40);  
        tree.Add("M", 8);   
        tree.Add("N", 45);  
        tree.Add("O", 7);   
        tree.Add("P", 50);

        tree.UpdateHeights();
*/


        //tree.PrintTree();

        //tree.PrintCalculateWeightedAverageHeight();


        // Пример работы изменения Value
        /*tree.PrintTree();
        tree.UpdateValue("O", 20);
        tree.UpdateValue("И", 30);*/


        /*//Пример 1
        // Дерево А
        OptimalBinarySearchTree tree_A = new OptimalBinarySearchTree();
        tree_A.Add("A", 10);
        tree_A.Add("B", 5);
        tree_A.Add("W", 2);
        tree_A.Add("K", 1);
        tree_A.Add("Y", 2);
        tree_A.Add("P", 4);
        tree_A.Add("A", 1);
        tree_A.Add("H", 3);
        tree_A.Add("O", 3);
        tree_A.Add("B", 2);
        tree_A.Add("E", 1);
        tree_A.Add("J", 2);
        tree_A.Add("H", 1);
        tree_A.Add("И", 1);
        tree_A.Add("T", 1);

        tree_A.UpdateHeights();

        tree_A.PrintTree();

        tree_A.PrintCalculateWeightedAverageHeight();


        // Дерево B
        OptimalBinarySearchTree tree_B = new OptimalBinarySearchTree();
        tree_B.Add("A", 5);
        tree_B.Add("B", 15);
        tree_B.Add("C", 3);
        tree_B.Add("D", 20);
        tree_B.Add("E", 4);
        tree_B.Add("F", 25);
        tree_B.Add("G", 2);
        tree_B.Add("H", 30);
        tree_B.Add("I", 1);
        tree_B.Add("J", 35);
        tree_B.Add("K", 6);
        tree_B.Add("L", 40);
        tree_B.Add("M", 8);
        tree_B.Add("N", 45);
        tree_B.Add("O", 7);
        tree_B.Add("P", 50);

        tree_B.UpdateHeights();

        tree_B.PrintTree();

        tree_B.PrintCalculateWeightedAverageHeight();*/





        //Пример 2
        // Дерево А
        OptimalBinarySearchTree tree_A = new OptimalBinarySearchTree();
        tree_A.Add("A", 100);
        tree_A.Add("B", 100);
        tree_A.Add("C", 200);
        tree_A.Add("D", 200);
        tree_A.Add("G", 400);
        tree_A.Add("H", 400);
        tree_A.Add("I", 500);
        tree_A.Add("K", 600);
        tree_A.Add("L", 600);
        tree_A.Add("M", 700);
        tree_A.Add("N", 800);
        tree_A.Add("O", 900);
        tree_A.Add("P", 1000);

        tree_A.UpdateHeights();

        tree_A.PrintTree();

        tree_A.PrintCalculateWeightedAverageHeight();


        // Дерево B
        OptimalBinarySearchTree tree_B = new OptimalBinarySearchTree();
        tree_B.Add("M", 1);
        tree_B.Add("N", 2);
        tree_B.Add("P", 4);
        tree_B.Add("Q", 5);
        tree_B.Add("R", 10);
        tree_B.Add("S", 15);
        tree_B.Add("T", 20);
        tree_B.Add("V", 30);
        tree_B.Add("W", 35);
        tree_B.Add("X", 50);
        tree_B.Add("Y", 45);
        tree_B.Add("Z", 40);

        tree_B.UpdateHeights();

        tree_B.PrintTree();

        tree_B.PrintCalculateWeightedAverageHeight();





        // Дерево С
        OptimalBinarySearchTree tree_C = new OptimalBinarySearchTree();
        // Копируем дерево А в дерево С
        tree_C.CopyTree(tree_A);
        //Добовляем по элементно узлы из дерева В в дерево С, используя прямой обход дерева В

        // Инициализируем итератор B
        BinaryTreeIterator iterator_B = tree_B.GetIterator();

        // Проходим по дереву B прямым обходом
        while (iterator_B.HasNext())
        {
            Node node = iterator_B.Next();
            tree_C.Add(node.Key, node.Weight);
            tree_C.UpdateValue(node.Key, node.Value);
        }


        // Выводим новое Дерево С
        tree_C.UpdateHeights();
        tree_C.PrintTree();
        tree_C.PrintCalculateWeightedAverageHeight();

        // Инициализируем итератор C
        BinaryTreeIterator iterator_C = tree_C.GetIterator();


        Console.WriteLine();
        Console.WriteLine("Проходим по дереву прямым обходом с помощью класса итератор:");

        // Проходим по дереву прямым обходом с помощью класса итератор
        while (iterator_C.HasNext())
        {
            Node node = iterator_C.Next();
            Console.WriteLine($"Key: {node.Key}, Weight: {node.Weight}, Value: {node.Value}, Height: {node.Height}");
        }


        Console.WriteLine();
        Console.WriteLine("Проходим по дереву прямым обходом с помощью цикла range-for:");

        // Проходим по дереву прямым обходом с помощью цикла range-for
        foreach (Node node in tree_C.GetNodes())
        {
            Console.WriteLine($"Key: {node.Key}, Weight: {node.Weight}, Value: {node.Value}, Height: {node.Height}");

        }


        Console.ReadLine();
    }
}


























