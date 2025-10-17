using Avalonia.Controls;

namespace bstBuilderAnalyzerGUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void insertInt(object? sender, Avalonia.Interactivity.RoutedEvent e)
    {
        int inputtedInt = 0;
        try
        {
            string _ = insertInput.Text.Trim();
        }
        catch
        {
            await MessageBox.Show(this, "This is a diagnostic message!", "Error", MessageBox.MessageBoxButtons.OK, MessageBox.MessageBoxIcon.Error);
            return;
        }
        bst.Insert(inputtedInt);
    }

    private async void traverse(object? sender, Avalonia.Interactivity.RoutedEvent e)
    {
        switch (traversalType.SelectedIndex)
        {
            case 0:
                bst.Preorder();
                break;
            case 1:
                bst.Inorder();
                break;
            case 2:
                bst.Postorder();
                break;
            case 3:
                bst.Levelorder();
                break;
        }
    }
}