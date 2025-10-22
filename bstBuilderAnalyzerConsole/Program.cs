using bstBuilderAnalyzerClasslib;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bool running = true;
        string[] mainOptions = ["exit", "insert", "traverse", "analytics", "display tree"];
        int selectedMainOption = 0;

        while (running)
        {
            bool choosingMainOption = true;
            while (choosingMainOption)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════╗");
                for (int optionIndex = 0; optionIndex < mainOptions.Length; optionIndex++)
                {
                    Console.Write($"║ {optionIndex + 1}. ");
                    if (optionIndex == selectedMainOption)
                        Console.Write($"\x1b[;32m{mainOptions[optionIndex]}\x1b[0m");
                    else Console.Write(mainOptions[optionIndex]);
                    for (int i = 0; i < 17 - (4 + mainOptions[optionIndex].Length); i++) Console.Write(" ");
                    Console.WriteLine("║");
                }

                Console.WriteLine("╚═════════════════╝");

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
                            Console.Clear();
                            Console.WriteLine("╔═════════════════════════════╗");
                            Console.WriteLine("║                             ║");
                            Console.WriteLine("║ Integer to insert:          ║");
                            Console.WriteLine("║                             ║");
                            Console.WriteLine("╚═════════════════════════════╝");
                            Console.Write("\x1b[3;22f");
                            string strInt = Console.ReadLine() ?? "";
                            Console.Write("\x1b[6;1f");
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
                        List<int> preorderedElems = bst.Preorder();
                        List<int> inorderedElems = bst.Inorder();
                        List<int> postorderedElems = bst.Postorder();
                        List<int> levelorderedElems = bst.Levelorder();
                        Console.WriteLine("Preorder: ");
                        foreach (var preorderedElem in preorderedElems)
                            Console.Write($"{preorderedElem} ");
                        Console.WriteLine();
                        Console.Write("Inorder: ");
                        foreach (var inorderedElem in inorderedElems)
                            Console.Write($"{inorderedElem} ");
                        Console.WriteLine();
                        Console.Write("Postorder: ");
                        foreach (var postorderedElem in postorderedElems)
                            Console.Write($"{postorderedElem} ");
                        Console.WriteLine();
                        Console.Write("Level-order: ");
                        foreach (var levelorderedElem in levelorderedElems)
                            Console.Write($"{levelorderedElem} ");
                        Console.WriteLine();
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
                    case 4:
                        bst.DisplayTreeConsole();
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