using System.Windows;
using Y;

namespace Y
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

        private void Btn_Perfil_Click(object sender, RoutedEventArgs e)
        {
            Vista.Login login = new();
            login.Show();
        }
    }
}