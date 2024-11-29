using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Fill_3_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            /*
            //Пример 0
            // Добавляем узлы
            graph.AddNode("A", "1");
            graph.AddNode("B", "2");
            graph.AddNode("C", "3");

            // Добавляем дуги
            var nodeA = graph.FindNodeByName("A");
            var nodeB = graph.FindNodeByName("B");
            var nodeC = graph.FindNodeByName("C");

            graph.AddEdge(nodeA, nodeB, 1);
            graph.AddEdge(nodeB, nodeC, 1);
            graph.AddEdge(nodeC, nodeA, 1);
            graph.AddEdge(nodeB, nodeA, 1);
            graph.AddEdge(nodeC, nodeB, 1);
            graph.AddEdge(nodeA, nodeC, 1);
            */

            /*
            //Пример 1
            graph.AddNode("A", "1");
            graph.AddNode("B", "2");
            graph.AddNode("C", "3");
            graph.AddNode("D", "4");
            graph.AddNode("E", "5");
            graph.AddNode("F", "6");
            graph.AddNode("G", "7");

            
            var nodeA = graph.FindNodeByName("A");
            var nodeB = graph.FindNodeByName("B");
            var nodeC = graph.FindNodeByName("C");
            var nodeD = graph.FindNodeByName("D");
            var nodeE = graph.FindNodeByName("E");
            var nodeF = graph.FindNodeByName("F");
            var nodeG = graph.FindNodeByName("G");

            graph.AddEdge(nodeA, nodeB, 1);
            graph.AddEdge(nodeC, nodeB, 1);
            graph.AddEdge(nodeC, nodeD, 1);
            graph.AddEdge(nodeD, nodeE, 1);
            graph.AddEdge(nodeE, nodeC, 1);

            graph.AddEdge(nodeB, nodeA, 1);
            graph.AddEdge(nodeC, nodeA, 1);

            graph.AddEdge(nodeE, nodeF, 1);
            graph.AddEdge(nodeF, nodeE, 1);

            graph.AddEdge(nodeA, nodeF, 1);
            graph.AddEdge(nodeA, nodeG, 1);
            graph.AddEdge(nodeF, nodeA, 1);
            graph.AddEdge(nodeF, nodeG, 1);
            graph.AddEdge(nodeG, nodeF, 1);
            graph.AddEdge(nodeG, nodeA, 1);
            */

            //Пример 2
            graph.AddNode("A", "1");
            graph.AddNode("B", "2");
            graph.AddNode("C", "3");
            graph.AddNode("D", "4");
            graph.AddNode("E", "5");
            graph.AddNode("F", "6");
            graph.AddNode("G", "7");
            graph.AddNode("K", "8");



            var nodeA = graph.FindNodeByName("A");
            var nodeB = graph.FindNodeByName("B");
            var nodeC = graph.FindNodeByName("C");
            var nodeD = graph.FindNodeByName("D");
            var nodeE = graph.FindNodeByName("E");
            var nodeF = graph.FindNodeByName("F");
            var nodeG = graph.FindNodeByName("G");
            var nodeK = graph.FindNodeByName("K");


            graph.AddEdge(nodeA, nodeB, 1);
            graph.AddEdge(nodeA, nodeC, 1);
            graph.AddEdge(nodeC, nodeA, 1);
            graph.AddEdge(nodeG, nodeA, 1);
            graph.AddEdge(nodeK, nodeA, 1);

            graph.AddEdge(nodeB, nodeD, 1);
            graph.AddEdge(nodeB, nodeE, 1);
            graph.AddEdge(nodeC, nodeE, 1);
            graph.AddEdge(nodeC, nodeF, 1);
            graph.AddEdge(nodeE, nodeC, 1);

            graph.AddEdge(nodeD, nodeG, 1);
            graph.AddEdge(nodeE, nodeG, 1);
            graph.AddEdge(nodeE, nodeK, 1);
            graph.AddEdge(nodeF, nodeK, 1);
            graph.AddEdge(nodeG, nodeE, 1);

            //Блок проверки операций ------------------------
            //Console.WriteLine(graph.First(nodeD));
            //Console.WriteLine(graph.Next(nodeA, nodeD));
            //Console.WriteLine(graph.Vertex(nodeA, "Mark7"));
            //graph.DeleteNode("D");
            //graph.DeleteEdge(nodeA, nodeB);
            //Console.WriteLine(graph.Vertex(nodeA, "Mark4"));
            //graph.EditNode("A", "markeeee");

            //Console.WriteLine((graph.Vertex(nodeC, "markeeee")).Mark);
            //graph.EditEdge(nodeA, nodeB, 2);

            //-----------------------------------------------

            // Находим все циклы
            var cycles = graph.FindAllCycles();


            /*foreach (var cycle in cycles)
            {
                //Console.WriteLine(string.Join(" -> ", cycle.Select(n => n.Name)) + " -> " + cycle.First().Name);
                Console.WriteLine(string.Join("", cycle.Select(n => n.Name)));
            }*/

            string[] result = graph.DelDublicats(cycles);

            // Форматирование результата
            // Вывод циклов
            //Console.WriteLine("Уникальные циклы:");
            Console.WriteLine("Уникальные Циклы в графе:");
            foreach (string _output in result)
            {
                char j = _output[0];
                foreach (char i in _output)
                {
                    Console.Write(i);
                    Console.Write(" -> ");
                }
                Console.Write(j);
                Console.WriteLine();
            }


            // Подсчет и вывод общего количества циклов
            Console.WriteLine($"Общее количество циклов: {result.Count()}");


            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Итератор для перебора узлов:");
            var iterator = graph.GetIterator();

            // Итератор для перебора узлов
            do
            {
                Console.WriteLine($"Node Name: {iterator.Current.Name}, Mark: {iterator.Current.Mark}");
            }while (iterator.MoveNext());


            Console.ReadLine();
        }
    }

    public class Graph
    {
        // Класс для представления узла
        public class Node
        {
            public string Name { get; set; }
            public string Mark { get; set; }

            public Node(string name, string mark)
            {
                Name = name;
                Mark = mark;
            }
        }

        // Класс для представления дуги
        public class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public int Weight { get; set; }

            public Edge(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }

        private List<Node> nodes = new List<Node>();
        private List<Edge> edges = new List<Edge>();

        // 1. FIRST(v)
        public string First(Node v)
        {
            foreach (var edge in edges)
            {
                if (edge.From == v)
                    return edge.To.Mark;
            }
            return "Mark -1"; // Нулевая вершина
        }

        // 2. NEXT(v, i)
        public string Next(Node v, Node i)
        {
            bool found = false;
            foreach (var edge in edges)
            {
                if (edge.From == v)
                {
                    if (found) return edge.To.Mark;
                    if (edge.To == i) found = true;
                }
            }
            return "Mark -1"; // Нулевая вершина
        }

        // 3. VERTEX(v, i)
        public Node Vertex(Node v, string index)
        {
            foreach (var edge in edges)
            {
                if (edge.From == v)
                {
                    if (index == edge.To.Mark) return edge.To;
                }
            }
            return null; // Нулевая вершина
        }

        // 4. ADD_V(<имя>,<метка, mark>)
        public void AddNode(string name, string mark)
        {
            nodes.Add(new Node(name, mark));
        }

        // 5. ADD_E(v, w, c)
        public void AddEdge(Node v, Node w, int weight)
        {
            edges.Add(new Edge(v, w, weight));
        }

        // 6. DEL_V(<имя>)
        public void DeleteNode(string name)
        {
            var nodeToRemove = nodes.Find(node => node.Name == name);
            if (nodeToRemove != null)
            {
                nodes.Remove(nodeToRemove);
                edges.RemoveAll(edge => edge.From == nodeToRemove || edge.To == nodeToRemove);
            }
        }

        // 7. DEL_E(v, w)
        public void DeleteEdge(Node v, Node w)
        {
            edges.RemoveAll(edge => edge.From == v && edge.To == w);
        }

        // 8. EDIT_V(<имя>, <новое значение метки или маркировки>)
        public void EditNode(string name, string newMark)
        {
            var nodeToEdit = nodes.Find(node => node.Name == name);
            if (nodeToEdit != null)
            {
                nodeToEdit.Mark = newMark;
            }
        }

        // 9. EDIT_E(v, w, <новый вес дуги>)
        public void EditEdge(Node v, Node w, int newWeight)
        {
            var edgeToEdit = edges.Find(edge => edge.From == v && edge.To == w);
            if (edgeToEdit != null)
            {
                edgeToEdit.Weight = newWeight;
            }
        }

        //Удаление дубликаьлв циклов
        public string[] DelDublicats(List<List<Node>> _cycle)
        {
            List<string> input = new List<string>();
            foreach (var cycle in _cycle)
            {
                //Console.WriteLine(string.Join(" -> ", cycle.Select(n => n.Name)) + " -> " + cycle.First().Name);
                input.Add(string.Join("", cycle.Select(n => n.Name)));
            }
            return RemoveDuplicateCycles(input.ToArray());
        }

        public string[] RemoveDuplicateCycles(string[] strings)
        {
            HashSet<string> uniqueCycles = new HashSet<string>();
            foreach (var str in strings)
            {
                string minCycle = GetMinCycle(str);
                uniqueCycles.Add(minCycle);
            }
            return new List<string>(uniqueCycles).ToArray();
        }

        public string GetMinCycle(string str)
        {
            string minCycle = str;
            for (int i = 1; i < str.Length; i++)
            {
                string rotated = str.Substring(i) + str.Substring(0, i);
                if (string.Compare(rotated, minCycle) < 0)
                {
                    minCycle = rotated;
                }
            }
            return minCycle;
        }
        //Вспомогательные методы
        public Node FindNodeByName(string name)
        {
            return nodes.FirstOrDefault(n => n.Name == name);
        }

        public void PrintGraph()
        {
            Console.WriteLine("Nodes:");
            foreach (var node in nodes)
            {
                Console.WriteLine($"Name: {node.Name}, Mark: {node.Mark}");
            }
            Console.WriteLine("Edges:");
            foreach (var edge in edges)
            {
                Console.WriteLine($"From: {edge.From.Name}, To: {edge.To.Name}, Weight: {edge.Weight}");
            }
        }

        // Метод для поиска всех циклов в графе
        public List<Node> GetNeighbors(Node node)
        {
            return edges.Where(e => e.From == node).Select(e => e.To).ToList();
        }

        public List<List<Node>> FindAllCycles()
        {
            var allCycles = new List<List<Node>>();
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();

            foreach (var node in nodes)
            {
                FindCyclesDFS(node, node, visited, stack, new HashSet<Node>(), allCycles);
            }
            return allCycles;
        }

        private void FindCyclesDFS(Node start, Node current, HashSet<Node> visited, Stack<Node> stack, HashSet<Node> stackSet, List<List<Node>> allCycles)
        {
            visited.Add(current);
            stack.Push(current);
            stackSet.Add(current);

            foreach (var neighbor in GetNeighbors(current))
            {
                if (neighbor == start)
                {
                    // Найден цикл
                    var cycle = stack.Reverse().ToList();
                    allCycles.Add(cycle);
                }
                else if (!stackSet.Contains(neighbor))
                {
                    FindCyclesDFS(start, neighbor, visited, stack, stackSet, allCycles);
                }
            }

            stack.Pop();
            stackSet.Remove(current);
        }

        // Метод для получения итератора

        public GraphIterator GetIterator()
        {
            return new GraphIterator(this);
        }


        // Итератор для графа

        public class GraphIterator
        {
            private Graph _graph;
            private int _currentIndex = 0;

            public GraphIterator(Graph graph)
            {
                _graph = graph;
            }

            public Node Current => _graph.nodes[_currentIndex];
            public bool MoveNext()
            {
                if (_currentIndex < _graph.nodes.Count - 1)
                {
                    _currentIndex++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _currentIndex = 0;
            }
        }
    }
}
