using System.Windows;

namespace CardCreator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static void ShowTypeWindow()
        {
            var typeWin = new TypeCreator();
            typeWin.Show();
        }
    }
}
