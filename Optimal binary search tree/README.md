**программа реализует оптимальное двоичное дерево поиска. В программе реализовано создание, копирование, вывод и прямой обход дерева, а также вычисление средневзвешенной высоты дерева. В программе реализован прямой обход с помощью класса итератор и цикла range-for. Реализован абстрактный тип данных «Дерево» - оптимальное дерево двоичного поиска, список сыновей. Была реализована операция С=A ⋃прB означает, что элементы дерева А копируются в дерево С так, чтобы создать копию структуры дерева А, после чего в копию добавляется поэлементно список узлов, полученный в прямом порядке обхода дерева В. Так же реализован вывод структуры дерева в консоль.**<br>



## Объяснение работы программы:<br>

Была создана программа, которая реализует оптимальное двоичное дерево поиска, создание, копирование, вывод и прямой обход дерева, а также вычисление средневзвешенной высоты дерева.<br>
Узел дерева реализован абстрактным типом данных, с помощью созданного **класса Node**. Каждый узел содержит следующие поля:  <br>
•	**Key** - строка, представляющая ключ узла, тип данных строковый.<br>
•	**Weight** - целое число, представляющее вес узла, тип данных целочисленный.<br>
•	**Value** - целое число, представляющее значение узла, данное поле может использоваться для хранения дополнительной информации.<br>
•	**Height** - целое число, представляющее высоту узла в дереве, тип данных целочисленный.<br>
•	**Children[ ]** - массив из двух узлов, представляющий левого и правого сына.<br>
•	**Parent** - ссылка на родительский узел.<br>

**Класс OptimalBinarySearchTree** – в этом классе реализованы методы для создания и работы с оптимальным двоичным деревом поиска.<br>
•	Метод **Add(string key, int weight)** - добавляет новый узел в дерево. Если дерево пустое, новый узел становится корнем. Узел добавляется в первую доступную позицию, и если его вес больше веса родительского узла, вызывается метод Rebalance для перемещения узла вверх по дереву. Если дерево не пустое, создается очередь для обхода дерева в ширину (BFS). В очередь помещается корень дерева. Программа проходится по всем узлам и записывает в очередь уже пройденные узлы, так же по мере прохождения просматривает у какого узла свободно место для нового узла в качестве потомка, сначала проверяется левый узел, после права, обход идёт слева направо. <br>
•	Метод **Rebalance(Node node)** - перемещает узел с большим весом вверх по дереву, пока его родитель не окажется с большим весом или узел не станет корнем. Метод реализует вращение узлов в дереве, и предполагает замену всех ссылок на родителей и сыновей в полях в узлах дерева, в которых это необходимо сделать что бы не нарушить структуру дерева, на другие, благодаря чему происходит вращение двух узлов в дереве.<br>
•	Метод **PrintTree()** - выводит структуру дерева в консоль, Так же выводит ключи, веса, значения, высоты и родительские узлы, каждого узла. Благодаря методу PrintTree(Node node, bool right, string stick), происходит рекурсивный вывод дерева.<br>
•	Метод **FindNode(Node node, string key)** – рекурсивно проходит по всему дереву и находит узел по ключу.<br>
•	Метод **UpdateValue(string key, int newValue)** - обновляет значение узла по его ключу. Использует метод FindNode, для поика нужного узла.<br>
•	Метод **SetHeight(Node node)** – создаёт правило установки высоты, в зависимости от высоты родительского узла + 1, и выставляет 1 в случае если узел является корнем.<br>
•	Метод **UpdateHeights()** - обновляет высоты всех узлов в дереве. Метод рекурсивно проходит по всему дереву и выставляет высоту с помощью метода SetHeight.<br>
•	Метод **CalculateWeightedAverageHeight()** - вычисляет средневзвешенную высоту дерева, используя веса и высоты узлов. Метод использует формулу hср=P/W для вычисления средневзвешенной высоты построенного дерева. Для получения суммы весов и суммы произведений весов на высоты, методы CalculateTotalWeight и CalculateWeightedHeightSum соответственно.<br>
•	Методы **CopyTree(OptimalBinarySearchTree sourceTree)** и **CopyNode(Node sourceNode, Node parent)** - копирует узлы из одного дерева в другое. Используя рекурсивное копирования узлов из одного дерева в другое. Копирование происходит, начиная с корня и копируется поэлементно, создавая новый узел в дерева куда копируется другое дерево.<br>
•	Метод **GetIterator()** - возвращает итератор для обхода дерева. Реализует доступ к классу BinaryTreeIterator.<br>
•	Метод **GetNodes()** - возвращает перечисление узлов дерева для обхода с помощью цикла foreach.<br>

**Класс BinaryTreeIterator** - этот класс реализует итератор для обхода дерева. Метод использует стек для хранения узлов и позволяет последовательно получать узлы дерева при обращение к методу Next().<br>
Метод **HasNext()** - проверяет, есть ли еще узлы для обхода.<br>
Метод **Next()** - возвращает следующий узел в обходе и добавляет его сыновей в стек. Сначала добавляем правый узел, затем левый, чтобы левый узел был на вершине стека.<br>

В **классе Main**, выполняются следующие операции:<br>
•	Создание и заполнение двух деревьев: **tree_A** и **tree_B**;<br>
•	Вывод структуры и средневзвешенной высоты каждого дерева;<br>
•	Копирование узлов из **tree_A** в **tree_C** и добавление узлов из **tree_B** в **tree_C** с помощью класса итератор;<br>
•	Вывод структуры и средневзвешенной высоты дерева **tree_C**;<br>
•	Обход дерева **tree_C** с помощью **итератора** и с помощью **цикла foreach**.<br>


//-------------------------------------------------------------------------------------------------------

**The program implements an optimal binary search tree. The program implements the creation, copying, output and direct traversal of the tree, as well as the calculation of the weighted average height of the tree. The program implements direct traversal using the iterator class and the range-for loop. The abstract data type "Tree" is implemented - the optimal binary search tree, a list of sons. The operation C=A ⋃was implemented, which means that the elements of tree A are copied to tree C so as to create a copy of the structure of tree A, after which a list of nodes is added to the copy, obtained in the direct order of traversal of tree B. The output of the tree structure to the console is also implemented.**<br>



## Explanation of how the program works:<br>

A program has been created that implements the optimal binary search tree, creation, copying, output and direct traversal of the tree, as well as calculating the weighted average height of the tree.<br>
The node of the tree is implemented by an abstract data type, using the created Node** class. Each node contains the following fields: <br>
• **Key** is a string representing the node key, the data type is string.<br>
• **Weight** is an integer representing the weight of the node, the data type is integer.<br>
• **Value** is an integer representing the node value, this field can be used to store additional information.<br>
• **Height** is an integer representing the height of a node in the tree, the data type is integer.<br>
• **Children[ ]** is an array of two nodes representing the left and right son.<br>
• **Parent** - link to the parent node.<br>

**OptimalBinarySearchTree class** – this class implements methods for creating and working with an optimal binary search tree.<br>
• **Add method(string key, int weight)** - adds a new node to the tree. If the tree is empty, the new node becomes the root. The node is added to the first available position, and if its weight is greater than the weight of the parent node, the Rebalance method is called to move the node up the tree. If the tree is not empty, a queue is created to traverse the tree in width (BFS). The root of the tree is placed in the queue. The program goes through all nodes and writes already passed nodes to the queue, as well as looks at which node has free space for a new node as a descendant, first the left node is checked, after the right, the bypass goes from left to right. <br>
• Rebalance method(Node node)** - moves a node with a large weight up the tree until its parent is with a large weight or the node becomes the root. The method implements the rotation of nodes in the tree, and involves replacing all references to parents and sons in the fields in the nodes of the tree, in which this must be done so as not to disrupt the structure of the tree, with others, thereby rotating two nodes in the tree.<br>
• The **PrintTree()** method outputs the tree structure to the console, as well as outputs the keys, weights, values, heights and parent nodes of each node. Thanks to the PrintTree method(Node node, bool right, string stick), the tree is output recursively.<br>
• The **findNode(Node node, string key)** method recursively traverses the entire tree and finds a node by key.<br>
• Method **updateValue(string key, int newValue)** - updates the node value by its key. Uses the findNode method to find the desired node.<br>
• Method **setHeight(Node node)** – creates a height setting rule, depending on the height of the parent node + 1, and sets 1 if the node is the root.<br>
• The **UpdateHeights()** method updates the heights of all nodes in the tree. The method recursively traverses the entire tree and sets the height using the setHeight method.<br>
• The **CalculateWeightedAverageHeight()** method calculates the weighted average height of the tree using the weights and heights of the nodes. The method uses the formula hsr=P/W to calculate the weighted average height of the constructed tree. To obtain the sum of the weights and the sum of the products of the weights by heights, the CalculateTotalWeight and CalculateWeightedHeightSum methods, respectively.<br>
• Methods **CopyTree(OptimalBinarySearchTree SourceTree)** and **CopyNode(Node sourceNode, Node parent)** - copies nodes from one tree to another. Using recursive copying of nodes from one tree to another. Copying takes place starting from the root and is copied piecemeal, creating a new node in the tree where another tree is copied.<br>
• The **getIterator()** method returns an iterator to traverse the tree. Implements access to the BinaryTreeIterator class.<br>
• The **GetNodes()** method returns an enumeration of tree nodes to be traversed using a foreach loop.<br>

**BinaryTreeIterator class** - this class implements an iterator for traversing the tree. The method uses a stack to store nodes and allows you to sequentially get tree nodes when calling the Next() method.<br>
The **hasNext()** method checks if there are more nodes to crawl.<br>
The **Next()** method returns the next node in the crawl and adds its sons to the stack. First we add the right node, then the left one, so that the left node is at the top of the stack.<br>

In the **Main** class, the following operations are performed:<br>
• Creating and filling two trees: **tree_A** and **tree_B**;<br>
• Output of the structure and weighted average height of each tree;<br>
• Copying nodes from **tree_A** to **tree_C** and adding nodes from **tree_B** to **tree_C** using the iterator class;<br>
• Output of the structure and weighted average height of the tree **tree_C**;<br>
• Traversing the tree **tree_C** using the **iterator** and using the ** foreach loop**.<br>
