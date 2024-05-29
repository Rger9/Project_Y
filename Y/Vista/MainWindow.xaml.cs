using MySql.Data.MySqlClient;
using System.Windows;
using Y;
using Y.AccesADades;
using Y.Negoci;
using Y.Vista;

namespace Y
{
    /// <summary>
    /// La finestra principal de l'aplicatiu, on podràs veure posts, comentar, iniciar sessió o modificar perfil i publicar
    /// </summary>
    public partial class MainWindow : Window
    {
        UsuariModel u;
        bool logged;
        List<int> llistaIdPublicacio;
        /// <summary>
        /// Finestra inicialitzada quan ets un usuari anònim
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            logged = false;
            u = new UsuariModel();
            BtnUsername.Visibility = Visibility.Hidden;
            Carregar();
        }
        /// <summary>
        /// Finestra inicialitzada amb la sessió iniciada de l'usuari
        /// </summary>
        /// <param name="u">Usuari loguejat</param>
        public MainWindow(UsuariModel u)
        {
            InitializeComponent();
            logged = true;
            this.u = u;
            Btn_Perfil.Visibility = Visibility.Hidden;
            BtnUsername.Content = u.Username;
            Carregar();
        }
        /// <summary>
        /// Carregar la finestra amb la vista "VistaPost"
        /// </summary>
        private void Carregar()
        {
            // Conseguim tots els id de les publicacions
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            llistaIdPublicacio = pNegoci.ObtenirTotsId();

            // Carreguem el frame amb el post
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));

            // Carreguem la llista de tags amb el nom d'aquests
            TagNegoci tNegoci = new TagNegoci();
            List<string> llistaTags = new List<string>();
            foreach (int tagId in tNegoci.ObtenirTotsId())
            {
                llistaTags.Add(tNegoci.GetTagDB(tagId).Nom);
            }
            ListboxTag.ItemsSource = llistaTags;
        }
        /// <summary>
        /// Obre la finestra Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Perfil_Click(object sender, RoutedEventArgs e)
        {
            Vista.Login login = new();
            login.Show();
            this.Close();
        }
        /// <summary>
        /// Obre la finestra de publicar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            if (logged)
            {
                Vista.Publicar publicar = new Vista.Publicar(u);
                publicar.Show();
                Carregar();
                this.Close();
            }
            else MessageBox.Show("No pots publicar si no estas logged!");
        }
        /// <summary>
        /// Obre un popup amb dues opcions, modificar perfil o sortir de la sessió
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUsername_Click(object sender, RoutedEventArgs e)
        {
            PopupUsername.IsOpen = true;
        }
        /// <summary>
        /// Passa a la publicacio anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnterior_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            int ultimPost = llistaIdPublicacio[llistaIdPublicacio.Count - 1];
            llistaIdPublicacio.RemoveAt(llistaIdPublicacio.Count - 1);
            llistaIdPublicacio.Insert(0, ultimPost);
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));

        }
        /// <summary>
        /// Passa a la seguent publicacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSeguent_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            int idPublicacioActual = llistaIdPublicacio.First();
            llistaIdPublicacio.RemoveAt(0);
            llistaIdPublicacio.Add(idPublicacioActual);
            FramePublicacions.NavigationService.Navigate(new VistaPost(u, pNegoci.GetPublicacio(llistaIdPublicacio.First())));
        }
        /// <summary>
        /// Obre la finestra de modificar perfil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupBtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Vista.Perfil perfil = new(u);
            perfil.Show();
            this.Close();
        }
        /// <summary>
        /// Tanca la sessió, obre l'interfaç com un usuari anònim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupBtnSortir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}