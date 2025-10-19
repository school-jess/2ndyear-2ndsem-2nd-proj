namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTreeNode<T> where T : IComparable<T>
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

    public bool IsGreaterThan(T other) => Data.CompareTo(other) < 0;

    public int Insert(T insertedData)
    {
        int newLevel = level + 1;
        if (IsGreaterThan(insertedData))
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

    public void Preorder(string stringConnector, List<int> stringBranchConnection)
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
        if (Left != null) Left.Preorder(leftStringConnector, stringBranchConnection);
        if (Right != null) Right.Preorder("└──", stringBranchConnection);
    }

    public bool Inorder(bool shouldCountinue, T biggest)
    {
        if (Left != null) Left.Inorder(shouldCountinue, biggest);
        if (!shouldCountinue) return false;
        Console.Clear();
        Console.Write(ToString());
        if (Data.CompareTo(biggest) < 0)
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
        if (Right != null) Right.Inorder(shouldCountinue, biggest);
        return shouldCountinue;
    }

    public void Postorder(string stringConnector, int treeHeight)
    {
        if (Left != null) Left.Postorder(" ┐", treeHeight);
        if (Right != null) Right.Postorder("┴", treeHeight);
        if (Left == null ^ Right == null)
            for (int i = 0; i < treeHeight; i++)
                Console.Write(" ");
        Console.Write(ToString());
        if (Left == null && Right == null)
            if ((Left == null && Right == null) && level != treeHeight)
                for (int i = 0; i < treeHeight; i++)
                    Console.Write("─");
        Console.Write(stringConnector);
        if (stringConnector == "┐") Console.WriteLine();
    }
}