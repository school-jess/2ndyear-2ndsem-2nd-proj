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

    public void PreorderConsole()
    {
        if (root == null) return;
        root.PreorderConsole("", new List<int>());
    }

    public void InorderConsole()
    {
        if (root == null) return;
        root.InorderConsole(true, Biggest);
    }

    public void PostorderConsole()
    {
        if (root == null) return;
        int lenLessThanRoot = 0;
        foreach (var leafNode in LeafNodes)
            if (leafNode > root.Data)
            {
                lenLessThanRoot = LeafNodes.IndexOf(leafNode);
                break;
            }
        root.PostorderConsole("", TreeHeight, false, lenLessThanRoot);
    }

    public void LevelorderConsole()
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

    public void PreorderGUI(Canvas canvas, T dataToSearch)
    {
        if (root == null) return;
        root.PreorderGUI(canvas, dataToSearch);
    }

    public void InorderGUI(Canvas canvas, T dataToSearch)
    {
        if (root == null) return;
        root.InorderGUI(canvas, dataToSearch);
    }

    public void PostorderGUI(Canvas canvas, T dataToSearch)
    {
        if (root == null) return;
        root.PostorderGUI(canvas, dataToSearch);
    }

    public void LevelorderGUI(Canvas canvas, T dataToSearch)
    {
        if (root == null) return;
        Queue<BinarySearchTreeNode<T>> bstNodes = new Queue<BinarySearchTreeNode<T>>();
        bstNodes.Enqueue(root);
        while (bstNodes.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = bstNodes.Dequeue();
            if (curElem.Data > dataToSearch) {/*todo*/}
            if (curElem.Left != null) bstNodes.Enqueue(curElem.Left);
            if (curElem.Right != null) bstNodes.Enqueue(curElem.Right);
        }
    }

    public void DisplayGUITree(Canvas canvas)
    {
        if (root == null) return;
        root.DisplayGUITree(canvas);
    }
}
