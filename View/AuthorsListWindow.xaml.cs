using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NS_Comment.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorsListWindow.xaml
    /// </summary>
    public partial class AuthorsListWindow : Window
    {
        public AuthorsListWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = System.Windows.SystemParameters.WorkArea.Width - this.Width - 350;
            this.Top = System.Windows.SystemParameters.WorkArea.Height - this.Height - 250;
        }
    }
}
