using MySql.Data.MySqlClient;
using System.Windows;
using Y;
using Y.AccesADades;
using Y.Negoci;

namespace Y
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsuariModel u = new UsuariModel();
        public MainWindow()
        {
            InitializeComponent();
            BtnUsername.Visibility = Visibility.Hidden;
        }
        public MainWindow(UsuariModel u)
        {
            InitializeComponent();
            this.u = u;
            BtnUsername.Content = u.Username;
        }

        private void Btn_Perfil_Click(object sender, RoutedEventArgs e)
        {
            Vista.Login login = new();
            login.Show();
            this.Close();
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            Vista.Publicar publicar = new Vista.Publicar(u);
            publicar.Show();
        }

        private void BtnUsername_Click(object sender, RoutedEventArgs e)
        {
            Vista.Perfil perfil = new(u);
            perfil.Show();
        }
    }
}