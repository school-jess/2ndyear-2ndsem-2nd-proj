using bstBuilderAnalyzerClasslib;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bool running = true;
        string[] mainOptions = ["exit", "insert", "traverse", "analytics"];
        int selectedMainOption = 0;

        while (running)
        {
            bool choosingMainOption = true;
            while (choosingMainOption)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════╗");
                for (int optionIndex = 0; optionIndex < mainOptions.Length; optionIndex++)
                {
                    Console.Write($"║ {optionIndex + 1}. ");
                    if (optionIndex == selectedMainOption)
                        Console.Write($"\x1b[;32m{mainOptions[optionIndex]}\x1b[0m");
                    else Console.Write(mainOptions[optionIndex]);
                    for (int i = 0; i < 14 - (4 + mainOptions[optionIndex].Length); i++) Console.Write(" ");
                    Console.WriteLine("║");
                }

                Console.WriteLine("╚══════════════╝");

                ConsoleKey selectedMainOptionKey = Console.ReadKey().Key;
                switch (selectedMainOptionKey)
                {
                    case ConsoleKey.Enter:
                        choosingMainOption = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedMainOption == mainOptions.Length - 1) continue;
                        selectedMainOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedMainOption == 0) continue;
                        selectedMainOption--;
                        break;
                }
            }

            bool continueMainOptionOp = true;
            while (continueMainOptionOp)
            {
                Console.Clear();
                switch (selectedMainOption)
                {
                    case 0:
                        running = false;
                        continueMainOptionOp = false;
                        break;
                    case 1:
                        int inputtedInt = 0;
                        bool hasInputtedInt = false;
                        while (!hasInputtedInt)
                        {
                            Console.Write("Integer to insert: ");
                            string strInt = Console.ReadLine() ?? "";
                            try
                            {
                                inputtedInt = Convert.ToInt32(strInt);
                                hasInputtedInt = true;
                            }
                            catch
                            {
                            }
                        }

                        bst.Insert(inputtedInt);
                        break;
                    case 2:
                        continueMainOptionOp = false;
                        string[] traverseOptions = ["exit", "preorder", "inorder", "postorder", "level-order"];
                        bool traversing = true;
                        while (traversing)
                        {
                            bool choosingTraverseOption = true;
                            int selectedTraverseOption = 0;
                            while (choosingTraverseOption)
                            {
                                Console.Clear();
                                Console.WriteLine("╔════════════════╗");
                                for (int traverseOptionIndex = 0;
                                     traverseOptionIndex < traverseOptions.Length;
                                     traverseOptionIndex++)
                                {
                                    Console.Write($"║ {traverseOptionIndex + 1}. ");
                                    if (traverseOptionIndex == selectedTraverseOption)
                                        Console.Write($"\x1b[;32m{traverseOptions[traverseOptionIndex]}\x1b[0m");
                                    else Console.Write(traverseOptions[traverseOptionIndex]);
                                    for (int i = 0; i < 16 - (4 + traverseOptions[traverseOptionIndex].Length); i++) Console.Write(" ");
                                    Console.WriteLine("║");
                                }
                                Console.WriteLine("╚════════════════╝");

                                ConsoleKey selectedTraverseOptionKey = Console.ReadKey().Key;
                                switch (selectedTraverseOptionKey)
                                {
                                    case ConsoleKey.Enter:
                                        choosingTraverseOption = false;
                                        break;
                                    case ConsoleKey.DownArrow:
                                        if (selectedTraverseOption == traverseOptions.Length - 1) continue;
                                        selectedTraverseOption++;
                                        break;
                                    case ConsoleKey.UpArrow:
                                        if (selectedTraverseOption == 0) continue;
                                        selectedTraverseOption--;
                                        break;
                                }
                            }

                            bool continueTraverseOptionOp = true;
                            while (continueTraverseOptionOp)
                            {
                                Console.Clear();
                                switch (selectedTraverseOption)
                                {
                                    case 0:
                                        traversing = false;
                                        continueTraverseOptionOp = false;
                                        break;
                                    case 1:
                                        bst.Preorder();
                                        break;
                                    case 2:
                                        bst.Inorder();
                                        break;
                                    case 3:
                                        bst.Postorder();
                                        break;
                                    case 4:
                                        bst.Levelorder();
                                        break;
                                }

                                if (continueTraverseOptionOp == false)
                                    continue;
                                bool inputTraverseContinueCorrectly = false;
                                while (!inputTraverseContinueCorrectly)
                                {
                                    Console.Write("Do you want to continue? ");
                                    ConsoleKey continueKey = Console.ReadKey().Key;
                                    if (continueKey == ConsoleKey.Y)
                                        inputTraverseContinueCorrectly = true;
                                    else if (continueKey == ConsoleKey.N)
                                    {
                                        inputTraverseContinueCorrectly = true;
                                        continueTraverseOptionOp = false;
                                    }
                                }
                            }
                        }

                        break;
                    case 3:
                        if (bst.TotalNodes == 0) Console.WriteLine("The Binary Search Tree is empty!");
                        else
                        {
                            Console.WriteLine($"Maximum: {bst.Biggest}");
                            Console.WriteLine($"Minimum: {bst.Smallest}");
                            Console.WriteLine($"Total Nodes: {bst.TotalNodes}");
                            Console.WriteLine($"Tree Height: {bst.TreeHeight}");
                            Console.Write($"Leaf Nodes: ");
                            int leafNodeIndex = 0;
                            foreach (var leafNode in bst.LeafNodes)
                            {
                                if (leafNodeIndex == bst.LeafNodes.Count - 1) Console.Write($"{leafNode.ToString()}");
                                else Console.Write($"{leafNode.ToString()}, ");
                                leafNodeIndex++;
                            }
                            Console.WriteLine();
                        }
                        break;
                }

                if (continueMainOptionOp == false)
                    continue;
                bool inputMainContinueCorrectly = false;
                while (!inputMainContinueCorrectly)
                {
                    Console.Write("Do you want to continue? ");
                    ConsoleKey continueKey = Console.ReadKey().Key;
                    if (continueKey == ConsoleKey.Y)
                        inputMainContinueCorrectly = true;
                    else if (continueKey == ConsoleKey.N)
                    {
                        inputMainContinueCorrectly = true;
                        continueMainOptionOp = false;
                    }
                }
            }
        }

        Console.WriteLine("Goodbye!");
    }
}