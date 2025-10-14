class BinarySearchTreeNode<T> where T : IComparable<T>
{
    BinarySearchTreeNode<T>? Left;
    BinarySearchTreeNode<T>? Right;
    T data;

    public BinarySearchTreeNode(T nodeData)
    {
        data = nodeData;
    }

    public bool IsGreaterThan(T other) => data.CompareTo(other) < 0;

//    public bool IsLessThan(T other) => data.CompareTo(other) > 0;

    public void Insert(T insertedData)
    {
        if (IsGreaterThan(insertedData))
        {
            if (Right == null)
                Right = new BinarySearchTreeNode<T>(insertedData);
            else
                Right.Insert(insertedData);
        }
        else
        {
            if (Left == null)
                Left = new BinarySearchTreeNode<T>(insertedData);
            else
                Left.Insert(insertedData);
        }
    }

    public void Traverse()
    {
        Console.WriteLine(ToString());
        if (Left != null) Left.Traverse();
        if (Right != null) Right.Traverse();
    }

    public override string ToString()
    {
        return $"{data.ToString()}";
    }
}

class BinarySearchTree<T> where T : IComparable<T>
{
    BinarySearchTreeNode<T>? Root;

    public void Insert(T data)
    {
        if (Root == null)
        {
            Root = new BinarySearchTreeNode<T>(data);
            return;
        }

        Root.Insert(data);
    }

    public void Traverse()
    {
        if (Root == null) return;
        Root.Traverse();
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(50);
        bst.Insert(25);
        bst.Insert(75);
        bst.Insert(14);
        bst.Insert(84);
        bst.Insert(79);
        bst.Insert(80);
        bst.Traverse();
    }
}