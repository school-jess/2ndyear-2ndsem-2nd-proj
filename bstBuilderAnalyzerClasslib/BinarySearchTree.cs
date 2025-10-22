using Avalonia.Controls;
using System.Numerics;

namespace bstBuilderAnalyzerClasslib;

public class BinarySearchTree<T> where T : IComparisonOperators<T, T, bool>
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
        if (elements.Contains(data)) return;

        elements.Add(data);
        if (TotalNodes == 0)
        {
            Biggest = data;
            Smallest = data;
        }
        else
        {
            if (data > Biggest) Biggest = data;
            if (data < Smallest) Smallest = data;
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

    public List<T> Preorder()
    {
        if (root == null) return [];
        List<T> elements = [];
        elements = root.Preorder(elements);
        return elements;
    }

    public List<T> Inorder()
    {
        if (root == null) return [];
        List<T> elements = [];
        elements = root.Inorder(elements);
        return elements;
    }

    public List<T> Postorder()
    {
        if (root == null) return [];
        List<T> elements = [];
        elements = root.Postorder(elements);
        return elements;
    }

    public List<T> Levelorder()
    {
        if (root == null) return [];
        List<T> elements = [];
        Queue<BinarySearchTreeNode<T>> bstNodes = new Queue<BinarySearchTreeNode<T>>();
        bstNodes.Enqueue(root);
        while (bstNodes.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = bstNodes.Dequeue();
            elements.Add(curElem.Data);
            if (curElem.Left != null) bstNodes.Enqueue(curElem.Left);
            if (curElem.Right != null) bstNodes.Enqueue(curElem.Right);
        }
        return elements;
    }

    public void DisplayTreeConsole()
    {
        if (root == null) return;
        root.DisplayTreeConsole("", []);
    }

    public void DisplayGUITree(Canvas canvas)
    {
        if (root == null) return;
        root.DisplayGUITree(canvas);
    }
}
