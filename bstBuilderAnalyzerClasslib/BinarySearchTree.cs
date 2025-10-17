namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTree<T> where T : IComparable<T>
{
    BinarySearchTreeNode<T>? root;
    int totalNodes = 0;
    int treeHeight = 0;
    T? biggest;
    T? smallest;
    List<T> elements;

    public BinarySearchTree()
    {
        totalNodes = 0;
        treeHeight = 0;
        elements = new List<T>();
    }

    public void Insert(T data)
    {
        if (elements.Contains(data))
        {
            return;
        }
        elements.Add(data);
        if (data.CompareTo(biggest) > 0) biggest = data;
        if (data.CompareTo(smallest) < 0) smallest = data;
        totalNodes++;
        if (root == null)
        {
            root = new BinarySearchTreeNode<T>(data, 0);
            return;
        }
        int curTreeHeight = root.Insert(data);
        if (treeHeight < curTreeHeight)
            treeHeight = curTreeHeight;
    }

    public void Preorder()
    {
        if (root == null) return;
        root.Preorder("", new List<int>());
    }

    public void Inorder()
    {
        if (root == null) return;
        root.Inorder();
    }

    public void Postorder()
    {
        if (root == null) return;
        root.Postorder(0);
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
