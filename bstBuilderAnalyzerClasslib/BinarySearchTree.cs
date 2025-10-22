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

        root.PostorderConsole("", TreeHeight, false, lenLessThanRoot, false);
    }

    public void LevelorderConsole()
    {
        if (root == null) return;
        Queue<BinarySearchTreeNode<T>> bstNodes = new Queue<BinarySearchTreeNode<T>>();
        Queue<string> bstNodeConnectors = new Queue<string>();
        int[] noSiblings = new int[TreeHeight];
        int curLevel = 0;
        int curChild = 0;
        bstNodes.Enqueue(root);
        bstNodeConnectors.Enqueue("");
        while (bstNodes.Count > 0)
        {
            BinarySearchTreeNode<T> curElem = bstNodes.Dequeue();
            string curConnector = bstNodeConnectors.Dequeue();
            if (curLevel != curElem.Level)
            {
                curLevel = curElem.Level;
                curChild = 0;
            }

            if (curChild != 0 || curLevel == 1)
                for (int i = 0; i < curLevel; i++)
                    Console.Write("  ");
            if (curLevel > 1 && curChild != 0)
            {
                if (noSiblings[curLevel - 1] - 2 > curChild)
                {
                    if (curConnector == "└") Console.Write(" │");
                    else Console.Write("  ");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.Write(curConnector);
            if (curLevel > 1 && curChild != 0)
            {
                if (!(noSiblings[curLevel - 1] - 2 > curChild))
                {
                    int amtDashes = noSiblings[curLevel - 1] - curChild - 1;
                    if (amtDashes == 0) amtDashes++;
                    for (int i = 0; i < amtDashes; i++)
                        Console.Write("─");
                }
            }

            Console.Write(curElem.ToString());
            if (curElem.Level != 0 && (curElem.Left != null || curElem.Right != null))
                for (int i = 0; i < noSiblings[curLevel - 1] - curChild - 1; i++)
                    Console.Write("─");
            if (curElem.Right != null || curElem.Left != null)
                Console.Write("┐");
            if (curChild == 0 || (curElem.Left == null || curElem.Right == null))
                Console.WriteLine();
            string leftConnectorStr = "├";
            if (curElem.Right == null) leftConnectorStr = "└";
            if (curElem.Left != null)
            {
                bstNodes.Enqueue(curElem.Left);
                bstNodeConnectors.Enqueue(leftConnectorStr);
                noSiblings[curElem.Level]++;
            }

            if (curElem.Right != null)
            {
                bstNodes.Enqueue(curElem.Right);
                bstNodeConnectors.Enqueue("└");
                noSiblings[curElem.Level]++;
            }

            curChild++;
        }

        Console.WriteLine();
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
            if (curElem.Data > dataToSearch)
            {
                /*todo*/
            }

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
