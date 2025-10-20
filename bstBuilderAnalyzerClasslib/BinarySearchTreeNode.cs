using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Numerics;

namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTreeNode<T> where T : IComparisonOperators<T, T, bool>
{
    public BinarySearchTreeNode<T>? Left;
    public BinarySearchTreeNode<T>? Right;
    public T Data;
    private int level;

    public BinarySearchTreeNode(T nodeData, int treeNodeHeight)
    {
        Data = nodeData;
        level = treeNodeHeight;
    }

    public int Insert(T insertedData)
    {
        int newLevel = level + 1;
        if (Data < insertedData)
        {
            if (Right == null)
            {
                Right = new BinarySearchTreeNode<T>(insertedData, newLevel);
                return newLevel;
            }
            else
                return Right.Insert(insertedData);
        }
        else
        {
            if (Left == null)
            {
                Left = new BinarySearchTreeNode<T>(insertedData, newLevel);
                return newLevel;
            }
            else
                return Left.Insert(insertedData);
        }
    }

    public override string ToString()
    {
        return $"{Data.ToString()}";
    }

    public void PreorderConsole(string stringConnector, List<int> stringBranchConnection)
    {
        if (stringConnector == "└──") // this the only way to know if traversing Right
            stringBranchConnection.Remove(level);
        for (int i = 1; i < level; i++)
        {
            if (stringBranchConnection.Contains(i))
                Console.Write("│  ");
            else
                Console.Write("   ");
        }
        Console.Write(stringConnector);
        Console.WriteLine(ToString());
        string leftStringConnector = "└──";
        if (Right != null)
        {
            leftStringConnector = "├──";
            int stringBranchConnectionElemToAdd = level + 1;
            if (!stringBranchConnection.Contains(stringBranchConnectionElemToAdd))
                stringBranchConnection.Add(stringBranchConnectionElemToAdd);
        }
        if (Left != null) Left.PreorderConsole(leftStringConnector, stringBranchConnection);
        if (Right != null) Right.PreorderConsole("└──", stringBranchConnection);
    }

    public bool InorderConsole(bool shouldCountinue, T biggest)
    {
        if (Left != null) Left.InorderConsole(shouldCountinue, biggest);
        if (!shouldCountinue) return false;
        Console.Clear();
        Console.Write(ToString());
        if (Data < biggest)
        {
            Console.WriteLine(" »");
            bool inputShouldContinueKey = false;
            while (!inputShouldContinueKey)
            {
                ConsoleKey shouldContinueKey = Console.ReadKey().Key;
                switch (shouldContinueKey)
                {
                    case ConsoleKey.RightArrow:
                        inputShouldContinueKey = true;
                        break;
                    case ConsoleKey.N:
                        return false;
                }
            }
        }
        else Console.WriteLine();
        if (Right != null) Right.InorderConsole(shouldCountinue, biggest);
        return shouldCountinue;
    }

    public void PostorderConsole(string stringConnector, int treeHeight, bool hasSibling, int amtOfSpaces)
    {
        bool hasToConnect = stringConnector == "┴" && (Right != null || Left != null);
        if (Left != null) Left.PostorderConsole("┐", treeHeight, hasToConnect, amtOfSpaces);
        if (Right != null) Right.PostorderConsole("┴", treeHeight, false, amtOfSpaces);
        if (Left == null ^ Right == null)
            for (int i = 0; i < treeHeight; i++)
                Console.Write(" ");
        Console.Write(ToString());
        if (Left == null && Right == null)
            if ((Left == null && Right == null) && level != treeHeight)
                for (int i = 0; i < treeHeight; i++)
                    Console.Write("─");
        Console.Write(stringConnector);
        if (hasSibling)
        {
            for (int i = 0; i < amtOfSpaces; i++) Console.Write(" ");
            Console.Write("│");
        }
        if (stringConnector == "┐") Console.WriteLine();
    }

    public void PreorderGUI(Canvas canvas, T dataToSearch)
    {
        if (Data > dataToSearch) {/*todo*/}
        if (Left != null) Left.PreorderGUI(canvas, dataToSearch);
        if (Right != null) Right.PreorderGUI(canvas, dataToSearch);
    }

    public void InorderGUI(Canvas canvas, T dataToSearch)
    {
        if (Left != null) Left.InorderGUI(canvas, dataToSearch);
        if (Data > dataToSearch) {/*todo*/}
        if (Right != null) Right.InorderGUI(canvas, dataToSearch);
    }

    public void PostorderGUI(Canvas canvas, T dataToSearch)
    {
        if (Left != null) Left.PostorderGUI(canvas, dataToSearch);
        if (Data > dataToSearch) {/*todo*/}
        if (Right != null) Right.PostorderGUI(canvas, dataToSearch);

    }

    public void DisplayGUITree(Canvas canvas)
    {
        Ellipse shapeContainer = new Ellipse
        {
            Fill = Brushes.Coral,
            Height = 20.0,
            Width = 20.0
        };
        Canvas.SetLeft(shapeContainer, 100.0);
        Canvas.SetTop(shapeContainer, 100.0);
        canvas.Children.Add(shapeContainer);

        TextBlock containerText = new TextBlock { Text = Data.ToString() };
        Canvas.SetLeft(containerText, 105.0);
        Canvas.SetTop(containerText, 105.0);
        canvas.Children.Add(containerText);

        if (Left != null) Left.DisplayGUITree(canvas);
        if (Right != null) Right.DisplayGUITree(canvas);
    }
}