namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private BinarySearchTreeNode<T>? root;
    public int TotalNodes = 0;
    public int TreeHeight = 0;
    public T? Biggest;
    public T? Smallest;
    private List<T> elements;

    public List<T> LeafNodes
    {
        get
        {
            if (root == null) return [];
            List<T> leafNodes = new List<T>();
            Queue<BinarySearchTreeNode<T>> bstNodes = new Queue<BinarySearchTreeNode<T>>();
            bstNodes.Enqueue(root);
            while (bstNodes.Count > 0)
            {
                BinarySearchTreeNode<T> curElem = bstNodes.Dequeue();
                if (curElem.Left == null && curElem.Right == null) leafNodes.Add(curElem.Data);
                if (curElem.Left != null) bstNodes.Enqueue(curElem.Left);
                if (curElem.Right != null) bstNodes.Enqueue(curElem.Right);
            }

            return leafNodes;
        }
    }

    public BinarySearchTree()
    {
        TotalNodes = 0;
        TreeHeight = 0;
        elements = new List<T>();
    }

    public void Insert(T data)
    {
        if (elements.Contains(data))
        {
            return;
        }

        elements.Add(data);
        if (TotalNodes == 0)
        {
            Biggest = data;
            Smallest = data;
        }
        else
        {
            if (data.CompareTo(Biggest) > 0) Biggest = data;
            if (data.CompareTo(Smallest) < 0) Smallest = data;
        }

        TotalNodes++;
        if (root == null)
        {
            root = new BinarySearchTreeNode<T>(data, 0);
            return;
        }

        int curTreeHeight = root.Insert(data);
        if (TreeHeight < curTreeHeight)
            TreeHeight = curTreeHeight;
    }

    public void Preorder()
    {
        if (root == null) return;
        root.Preorder("", new List<int>());
    }

    public void Inorder()
    {
        if (root == null) return;
        root.Inorder(true, Biggest);
    }

    public void Postorder()
    {
        if (root == null) return;
        root.Postorder("", TreeHeight);
    }

    public void Levelorder()
    {
        if (root == null) return;
        Queue<BinarySearchTreeNode<T>> bstNodes = new Queue<BinarySearchTreeNode<T>>();
        bstNodes.Enqueue(root);
        while (bstNodes.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = bstNodes.Dequeue();
            Console.WriteLine(curElem.ToString());
            if (curElem.Left != null) bstNodes.Enqueue(curElem.Left);
            if (curElem.Right != null) bstNodes.Enqueue(curElem.Right);
        }
    }
}
