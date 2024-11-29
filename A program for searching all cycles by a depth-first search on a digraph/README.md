**Программа определяет наличие всех циклов методом обхода в глубину на орграфе. Выводит все циклы (варианты обхода, образующие циклы). Подсчитывает их общее количество. Представление графа: Список дуг.**<br>
Был реализован в виде программы абстрактный тип данных «Граф». Операторы (операции) АТД «Граф» представленные в программе выполняют следующие операции:<br>
1. FIRST(v) - возвращает индекс первой вершины, смежной с вершиной v. Если вершина v не имеет смежных вершин, то возвращается "нулевая" вершина;<br>
2. NEXT(v, i)- возвращает индекс вершины, смежной с вершиной v, следующий за индексом i. Если i — это индекс последней вершины, смежной с вершиной v, то возвращается;<br>
3. VERTEX(v, i) - возвращает вершину с индексом i из множества вершин, смежных с v;<br>
4. ADD_V(<имя>,<метка, mark>) - добавить УЗЕЛ; <br>
5. ADD_Е(v, w, c) - добавить ДУГУ (здесь c — вес, цена дуги (v,w));<br>
6. DEL_V(<имя>) - удалить УЗЕЛ;<br>
7. DEL_Е(v, w) – удалить ДУГУ;<br>
8. EDIT_V(<имя>, <новое значение метки или маркировки>) - изменить метку (маркировку) УЗЛА;<br>
9. EDIT_Е(v, w, <новый вес дуги>) - изменить вес ДУГИ Реализовать задание (заданный алгоритм) с использованием методов АТД «Граф».<br>


## Объяснение работы программы:<br>
Первым этапом в начале программы записываются инструкции для создания графа. Вначале создаётся объект графф, далее в рафе создаются объекты - вершины/Node. Далее для созданных вершин создаются ориентированные дуги – реализованные с помощь АТД. Разработанная программ работает с ориентированным графом, но поддерживает двунаправленные дуги. АТД дуги и вершины, записываются в List, так как в програме было решено использовать библиотеку «Linq», для работы с АТД.<br>
Далее программ находит все циклы используя метод класса «Graph»: FindAllCycles. Этот метод инициализирует процесс поиска всех циклов в графе. Он выполняет следующие действия. Создает список allCycles, который будет хранить все найденные циклы. Создает множество visited, чтобы отслеживать посещенные узлы. Создает стек stack, который будет использоваться для отслеживания текущего пути при обходе графа. Далее для каждого узла/вершины, вызывается вспомогательный метод FindCyclesDFS.<br>
Этот метод реализует поиск в глубину (DFS) для нахождения циклов. Метод добавляет текущий узел (current) добавляется в множество visited, стек stack и stackSet. Далее происходит обход соседей, метод перебирает всех соседей текущего узла, используя метод GetNeighbors(current). Далее метод проводит проверку на цикл, если соседний узел (neighbor) равен начальному узлу (start), это означает, что найден цикл. В случае если цикл найден, стек stack, который содержит узлы, добавляется в allCycles в перевернутом виде (так как стек работает по принципу LIFO).Если соседний узел не находится в stackSet, то метод рекурсивно вызывает сам себя для этого соседа<br>
Далее из полученного списка циклов, удаляются одинаковые циклы, которые начинаются из другой вершины, с помощью метода DelDublicat. В начале метод конвертирует список, состоящий из списков циклов, состоящих из АТД вершин. Далее с помощью следующего метода «RemoveDuplicateCycles» происходит проверка. Данный метод используя метод «GetMinCycle», конвертирует цикл в минимальную строку (по алфавиту) среди всех возможных циклических сдвигов этой строки. Все циклы сохраняются в HashSet<string>. HashSet автоматически исключает дубликаты.<br>
Далее формируются и выводятся все возможные циклы, и подсчитывается их количество. <br>
Допонительное задание: реализовать потерн итератор. Метод GetIterator() вызывается для получения экземпляра итератора. Данный создает новый объект GraphIterator, передавая ему текущий граф.<br>
Класс GraphIterator - вложенный класс, который реализует логику итерации по узлам графа. Когда мы создаём новый экземпляр мы передаём ему наш граф. В классе итератор присутствует метод MoveNext(), каждый раз, когда вы вызываете метод, итератор перемещается к следующему узлу. В поле Current помещается текущий узел, к которому мы можем обратится. Метод Reset() возвращает итератор в начальную позицию, для последующей работы.<br>

//-------------------------------------------------------------------------------------------------------

**The program determines the presence of all cycles by a depth-first traversal method on the digraph. Outputs all loops (traversal options that form loops). Calculates their total number. Graph representation: List of arcs.**<br>
The abstract data type "Graph" was implemented as a program. Operators (operations) The Graf administrative divisions presented in the program perform the following operations:<br>
1. FIRST(v) - returns the index of the first vertex adjacent to vertex v. If vertex v has no adjacent vertices, then the "zero" vertex is returned;<br>
2. NEXT(v, i)- returns the index of the vertex adjacent to vertex v, following the index i. If i is the index of the last vertex adjacent to vertex v, then it is returned;<br>
3. VERTEX(v, i) - returns a vertex with index i from the set of vertices adjacent to v;<br>
4. ADD_V(<name>,<label, mark>) - add a NODE; <br>
5. ADD_E(v, w, c) - add an ARC (here c is the weight, price of the arc (v,w));<br>
6. DEL_V(<name>) - delete the NODE;<br>
7. DEL_E(v, w) – remove the ARC;<br>
8. EDIT_V(<name>, <new value of the label or marking>) - change the label (marking) of the NODE;<br>
9. EDIT_E(v, w, <new arc weight>) - change the ARC weight To implement the task (the specified algorithm) using the methods of the "Graph" administrative division.<br>


## Explanation of how the program works:<br>
The first step at the beginning of the program is to write instructions for creating a graph. First, a graff object is created, then vertex/Node objects are created in the graph. Next, oriented arcs are created for the created vertices – implemented with the help of the administrative division. The developed program works with a directed graph, but supports bidirectional arcs. Arcs and vertices are recorded in the List, since in the program it was decided to use the "Linq" library to work with the AD.<br>
Next, the program finds all the cycles using the method of the "Graph" class: FindAllCycles. This method initializes the process of searching for all cycles in the graph. It performs the following actions. Creates an allCycles list that will store all the cycles found. Creates a visited set to keep track of visited nodes. Creates a stack that will be used to track the current path when traversing the graph. Next, for each node/vertex, the FindCyclesDFS auxiliary method is called.<br>
This method implements a depth-first search (DFS) to find cycles. The method adds the current node (current) is added to the visited set, stack stack and StackSet. Next, the neighbors are bypassed, the method iterates through all the neighbors of the current node using the getNeighbors(current) method. Next, the method checks for a loop, if the neighbor node is equal to the start node, this means that a loop has been found. If a loop is found, the stack stack, which contains nodes, is added to allCycles in an inverted form (since the stack works on the LIFO principle).If the neighbor node is not in the StackSet, then the method recursively calls itself for this neighbor<br>
Next, the same cycles that start from another vertex are removed from the resulting list of cycles using the DelDublicat method. At the beginning, the method converts a list consisting of lists of cycles consisting of AD vertices. Then, using the following method "RemoveDuplicateCycles", the verification takes place. This method, using the "GetMinCycle" method, converts the cycle to the minimum string (alphabetically) among all possible cyclic shifts of this string. All loops are stored in a HashSet<string>. HashSet automatically excludes duplicates.<br>
Next, all possible cycles are formed and displayed, and their number is calculated. <br>
Additional task: to implement a lost iterator. The getIterator() method is called to get an iterator instance. This one creates a new GraphIterator object, passing the current graph to it.<br>
The GraphIterator class is a nested class that implements iteration logic across graph nodes. When we create a new instance, we pass our graph to it. The iterator class has the MoveNext() method, each time you call the method, the iterator moves to the next node. The Current field contains the current node that we can access. The Reset() method returns the iterator to the initial position for subsequent operation.<br>