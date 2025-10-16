namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTreeNode<T> where T : IComparable<T>
{
    public BinarySearchTreeNode<T>? Left;
    public BinarySearchTreeNode<T>? Right;
    public T Data;
    int level;

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

    public void Inorder()
    {
        if (Left != null) Left.Inorder();
        Console.WriteLine(ToString());
        if (Right != null) Right.Inorder();
    }

    public void Postorder()
    {
        if (Left != null) Left.Postorder();
        if (Right != null) Right.Postorder();
        Console.WriteLine(ToString());
    }
}