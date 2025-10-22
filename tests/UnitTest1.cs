using Xunit;
using Xunit.Abstractions;
using bstBuilderAnalyzerClasslib;

namespace tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _output;

    public UnitTest1(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Test1()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(50);
        bst.Insert(25);
        bst.Insert(14);
        bst.Insert(36);
        // bst.Insert(40);
        bst.Insert(75);
        bst.Insert(60);
        bst.Insert(84);
        // bst.Insert(79);
        // bst.Insert(78);
        // bst.Insert(80);
        // bst.Insert(90);
        bst.PostorderConsole();
        var output = stringWriter.ToString().Trim();
        _output.WriteLine(output);
        Assert.Contains(@"14┐
36┴25┐
60┐  │
84┴75┴50", output);
    }

    [Fact]
    public void Test2()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(50);
        bst.Insert(25);
        bst.Insert(14);
        bst.Insert(36);
        // bst.Insert(40);
        bst.Insert(75);
        bst.Insert(60);
        bst.Insert(84);
        // bst.Insert(79);
        // bst.Insert(78);
        // bst.Insert(80);
        // bst.Insert(90);
        bst.LevelorderConsole();
        var output = stringWriter.ToString().Trim();
        _output.WriteLine(output);
        Assert.Contains(@"50┐
  ├25─┐
  └75┐├14
     │└36
     ├─60 
     └─84
", output);
    }

    //     [Fact]
    //     public void Test3()
    //     {
    //         var stringWriter = new StringWriter();
    //         Console.SetOut(stringWriter);
    //         BinarySearchTree<int> bst = new BinarySearchTree<int>();
    //         bst.Insert(50);
    //         bst.Insert(25);
    //         // bst.Insert(14);
    //         bst.Insert(36);
    //         // bst.Insert(40);
    //         bst.Insert(75);
    //         bst.Insert(60);
    //         bst.Insert(84);
    //         // bst.Insert(79);
    //         // bst.Insert(78);
    //         // bst.Insert(80);
    //         // bst.Insert(90);
    //         bst.PostorderConsole();
    //         var output = stringWriter.ToString().Trim();
    //         _output.WriteLine(output);
    //         Assert.Contains(@"36─25┐
    // 60┐  │
    // 84┴75┴50", output);
    //     }
}