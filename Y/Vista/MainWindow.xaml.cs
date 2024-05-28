using MySql.Data.MySqlClient;
using System.Windows;
using Y;
using Y.AccesADades;
using Y.Negoci;
using Y.Vista;

namespace Y
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsuariModel u = new UsuariModel();
        bool logged = false;
        List<int> llistaIdPublicacio = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            logged = false;
            BtnUsername.Visibility = Visibility.Hidden;
            Carregar();
        }
        public MainWindow(UsuariModel u)
        {
            InitializeComponent();
            logged = true;
            this.u = u;
            Btn_Perfil.Visibility = Visibility.Hidden;
            BtnUsername.Content = u.Username;
            Carregar();
        }

        private void Carregar()
        {
            // Conseguim tots els id de les publicacions
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            llistaIdPublicacio = pNegoci.ObtenirTotsId();
            
            // Carreguem el frame amb el post
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));
        }
        private void BtnSeguent_Click(object sender, RoutedEventArgs e)
        {
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            int idPublicacioActual = llistaIdPublicacio.First();
            llistaIdPublicacio.RemoveAt(0);
            llistaIdPublicacio.Add(idPublicacioActual);
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));
        }
        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            int ultimPost = llistaIdPublicacio[llistaIdPublicacio.Count - 1];
            llistaIdPublicacio.RemoveAt(llistaIdPublicacio.Count - 1);
            llistaIdPublicacio.Insert(0, ultimPost);
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));
        }

        private void Btn_Perfil_Click(object sender, RoutedEventArgs e)
        {
            Vista.Login login = new();
            login.Show();
            this.Close();
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            if (logged)
            {
                Vista.Publicar publicar = new Vista.Publicar(u);
                publicar.Show();
                Carregar();
            }
            else MessageBox.Show("No pots publicar si no estas logged!");
        }

        private void BtnUsername_Click(object sender, RoutedEventArgs e)
        {
            Vista.Perfil perfil = new(u);
            perfil.Show();
        }
    }
}