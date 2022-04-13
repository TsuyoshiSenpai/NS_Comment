using System.Windows;

namespace NS_Comment
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }
        public StartWindow(MainViewModel model) : this()
        {
            this.DataContext = model;
        }
    }
}
