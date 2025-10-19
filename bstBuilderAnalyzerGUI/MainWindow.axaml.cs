using Avalonia.Controls;
using bstBuilderAnalyzerClasslib;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bstBuilderAnalyzerGUI;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private BinarySearchTree<int> bst;
    private string _analyticsStr;
    public string AnalyticsStr
    {
        get => _analyticsStr; set
        {
            _analyticsStr = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindow()
    {
        InitializeComponent();
        bst = new BinarySearchTree<int>();
        _analyticsStr = $"Maximum: {bst.Biggest}, Minimum: {bst.Smallest}, Total Nodes: {bst.TotalNodes}, Tree Height: {bst.TreeHeight}, Leaf Nodes: ";
        foreach (var leafNode in bst.LeafNodes) _analyticsStr += $"{leafNode}, ";
        DataContext = this;
    }

    private void insertInt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int inputtedInt = 0;
        try
        {
            string strInputtedInt = insertInput.Text.Trim();
            inputtedInt = Convert.ToInt32(strInputtedInt);
        }
        catch
        {
            return;
        }
        bst.Insert(inputtedInt);
        bst.PreorderGUI(bstCanvas);
        AnalyticsStr = $"Maximum: {bst.Biggest}, Minimum: {bst.Smallest}, Total Nodes: {bst.TotalNodes}, Tree Height: {bst.TreeHeight}";
        foreach (var leafNode in bst.LeafNodes) AnalyticsStr += $"{leafNode}, ";
    }

    private void search_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int inputtedInt = 0;
        try
        {
            string strInputtedInt = searchInput.Text.Trim();
            inputtedInt = Convert.ToInt32(strInputtedInt);
        }
        catch
        {
            return;
        }
        switch (traversalType.SelectedIndex)
        {
            case 0:
                bst.PreorderGUI(bstCanvas);
                break;
            case 1:
                bst.InorderGUI(bstCanvas);
                break;
            case 2:
                bst.PostorderGUI(bstCanvas);
                break;
            case 3:
                bst.LevelorderGUI(bstCanvas);
                break;
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}