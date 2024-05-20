using System.Windows;
using Y;
using Y.AccesADades;

namespace Y
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Connexio c = new Connexio();
            InitializeComponent();
        }

        private void Btn_Perfil_Click(object sender, RoutedEventArgs e)
        {
            Vista.Login login = new();
            login.Show();
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            Vista.Publicar publicar = new Vista.Publicar();
            publicar.Show();

        }
    }
}