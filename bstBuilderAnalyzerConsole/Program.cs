using bstBuilderAnalyzerClasslib;

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
        bst.Insert(90);
        bst.Insert(36);
        bst.Insert(40);
        bst.Insert(78);
        bst.Insert(60);
        bst.Inorder();
    }
}