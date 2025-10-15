class BinarySearchTreeNode<T> where T : IComparable<T>
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

    public void Preorder()
    {
        Console.WriteLine(ToString());
        if (Left != null) Left.Preorder();
        if (Right != null) Right.Preorder();
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

class BinarySearchTree<T> where T : IComparable<T>
{
    BinarySearchTreeNode<T>? root;
    int totalNodes = 0;
    int treeHeight = 0;
    T biggest;
    T smallest;

    public void Insert(T data)
    {
        if (data.CompareTo(biggest) > 0) biggest = data;
        if (data.CompareTo(smallest) < 0) smallest = data;
        totalNodes++;
        if (root == null)
        {
            root = new BinarySearchTreeNode<T>(data, 0);
            return;
        }
        treeHeight = root.Insert(data);
    }

    public void Preorder()
    {
        if (root == null) return;
        root.Preorder();
    }

    public void Inorder()
    {
        if (root == null) return;
        root.Inorder();
    }

    public void Postorder()
    {
        if (root == null) return;
        root.Postorder();
    }

    public void Levelorder()
    {
        if (root == null) return;
        Queue<BinarySearchTreeNode<T>> elements = new Queue<BinarySearchTreeNode<T>>();
        elements.Enqueue(root);
        while (elements.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = elements.Dequeue();
            Console.WriteLine(curElem.ToString());
            if (curElem.Left != null) elements.Enqueue(curElem.Left);
            if (curElem.Right != null) elements.Enqueue(curElem.Right);
        }
    }

    public int GetTreeHeight() => treeHeight;

    public int GetTotalNodes() => totalNodes;

    public List<T> GetLeafNodes()
    {
        if (root == null) return [];
        List<T> leafNodes = new List<T>();
        Queue<BinarySearchTreeNode<T>> elements = new Queue<BinarySearchTreeNode<T>>();
        elements.Enqueue(root);
        while (elements.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = elements.Dequeue();
            if (curElem.Left == null && curElem.Right == null) leafNodes.Add(curElem.Data);
            if (curElem.Left != null) elements.Enqueue(curElem.Left);
            if (curElem.Right != null) elements.Enqueue(curElem.Right);
        }
        return leafNodes;
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
        // bst.Levelorder();
        // Console.WriteLine(bst.GetTreeHeight());
        foreach (var leafNode in bst.GetLeafNodes())
            Console.WriteLine(leafNode.ToString());
    }
}