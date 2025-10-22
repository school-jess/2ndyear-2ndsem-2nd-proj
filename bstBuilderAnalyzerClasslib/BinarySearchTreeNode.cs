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
    public int Level;

    public BinarySearchTreeNode(T nodeData, int treeNodeHeight)
    {
        Data = nodeData;
        Level = treeNodeHeight;
    }

    public int Insert(T insertedData)
    {
        int newLevel = Level + 1;
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

    public List<T> Preorder(List<T> elements)
    {
        elements.Add(Data);
        Left?.Preorder(elements);
        Right?.Preorder(elements);
        return elements;
    }

    public List<T> Inorder(List<T> elements)
    {
        Left?.Inorder(elements);
        elements.Add(Data);
        Right?.Inorder(elements);
        return elements;
    }

    public List<T> Postorder(List<T> elements)
    {
        Left?.Postorder(elements);
        Right?.Postorder(elements);
        elements.Add(Data);
        return elements;
    }

    public void DisplayTreeConsole(int spaces)
    {
        Console.WriteLine(ToString());
        if (Left != null) Console.Write("/");
        if (Right != null) Console.Write("\\");
        Console.WriteLine();
        Left?.DisplayTreeConsole(spaces - 2);
        Right?.DisplayTreeConsole(spaces - 2);
    }

    public void DisplayGUITree(Canvas canvas)
    {
        Ellipse shapeContainer = new Ellipse
        {
            Fill = Brushes.Coral,
            Height = 20.0,
            Width = 20.0
        };
        Canvas.SetLeft(shapeContainer, 10.0);
        Canvas.SetTop(shapeContainer, 10.0 * Level);
        canvas.Children.Add(shapeContainer);

        TextBlock containerText = new TextBlock { Text = Data.ToString() };
        Canvas.SetLeft(containerText, 15.0);
        Canvas.SetTop(containerText, 15.0 * Level);
        canvas.Children.Add(containerText);

        if (Left != null) Left.DisplayGUITree(canvas);
        if (Right != null) Right.DisplayGUITree(canvas);
    }
}