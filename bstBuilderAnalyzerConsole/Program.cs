using bstBuilderAnalyzerClasslib;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bool running = true;
        string[] mainOptions = ["exit", "insert", "traverse"];
        int selectedMainOption = 0;

        while (running)
        {
            bool choosingMainOption = true;
            while (choosingMainOption)
            {
                Console.Clear();
                // Console.WriteLine("═");
                for (int optionIndex = 0; optionIndex < mainOptions.Length; optionIndex++)
                {
                    Console.Write($"{optionIndex + 1}. ");
                    if (optionIndex == selectedMainOption) Console.WriteLine($"\x1b[;32m{mainOptions[optionIndex]}\x1b[0m");
                    else Console.WriteLine(mainOptions[optionIndex]);
                }
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
                            { }
                        }
                        bst.Insert(inputtedInt);
                        break;
                    case 2:
                        string[] traverseOptions = ["preorder", "inorder", "postorder", "level-order"];
                        bool choosingTraverseOption = true;
                        int selectedTraverseOption = 0;
                        while (choosingTraverseOption)
                        {
                            for (int traverseOptionIndex = 0; traverseOptionIndex < traverseOptions.Length; traverseOptionIndex++)
                            {
                                Console.Write($"{traverseOptionIndex + 1}. ");
                                if (traverseOptionIndex == selectedTraverseOption) Console.WriteLine($"\x1b[;32m{traverseOptions[traverseOptionIndex]}\x1b[0m");
                                else Console.WriteLine(traverseOptions[traverseOptionIndex]);
                            }
                            ConsoleKey selectedTraverseOptionKey = Console.ReadKey().Key;
                            switch (selectedTraverseOptionKey)
                            {
                                case ConsoleKey.Enter:
                                    choosingTraverseOption = false;
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (selectedTraverseOption == traverseOptions.Length - 1) continue;
                                    selectedMainOption++;
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (selectedTraverseOption == 0) continue;
                                    selectedMainOption--;
                                    break;
                            }
                            Console.Clear();
                        }
                        break;
                }
                if (continueMainOptionOp == false)
                    continue;
                bool inputContinueCorrectly = false;
                while (!inputContinueCorrectly)
                {
                    Console.Write("Do you want to continue? ");
                    ConsoleKey continueKey = Console.ReadKey().Key;
                    if (continueKey == ConsoleKey.Y)
                        inputContinueCorrectly = true;
                    else if (continueKey == ConsoleKey.N)
                    {
                        inputContinueCorrectly = true;
                        continueMainOptionOp = false;
                    }
                }
            }
        }
        Console.WriteLine("Goodbye!");
    }
}