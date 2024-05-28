using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Y.Negoci;

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private bool placeholderUsername;
        private bool placeholderPassword;
        public Login()
        {
            InitializeComponent();
            placeholderUsername = true;
            placeholderPassword = true;
        }
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxUser_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderUsername)
            {
                TxtBoxUser.Text = string.Empty;
                TxtBoxUser.Foreground = Brushes.White;
                placeholderUsername = false;
            }
            ComprovarButton();
        }
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxUser_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxUser.Text == string.Empty)
            {
                TxtBoxUser.Text = "Nom d'usuari";
                TxtBoxUser.Foreground = Brushes.LightGray;
                placeholderUsername = true;
            }
        }
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PsswdLogIn_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderPassword)
            {
                PsswdLogIn.Password = string.Empty;
                TxtBoxUser.Foreground = Brushes.White;
                placeholderPassword = false;
            }
            ComprovarButton();
        }
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PsswdLogIn_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (PsswdLogIn.Password == string.Empty)
            {
                PsswdLogIn.Password = "abcdef";
                TxtBoxUser.Foreground = Brushes.LightGray;
                placeholderPassword = true;
            }
        }
        /// <summary>
        /// Permetrà a l'usuari fer click al botó BtnLogin mentre els camps de l'usuari i la contrasenya no estiguin buits
        /// </summary>
        private void ComprovarButton()
        {
            if ((!placeholderPassword || placeholderUsername) && TxtBoxUser.Text != string.Empty && PsswdLogIn.Password != string.Empty)
            {
                BtnLogin.IsEnabled = true;
            }
            else BtnLogin.IsEnabled = false;
        }
        /// <summary>
        /// Quan deixis de fer click al text de "no tens compte", s'obrirà la finestra de registre i es tancarà la de login actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Register register = new();
            register.Show();
            this.Close();
        }
        /// <summary>
        /// Al fer click a Login, comprovarà si l'usuari i contrasenya son incorrectes a la capa negoci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            UsuariModel u = new UsuariModel();
            try
            {
                // comprovem si existeix l'usuari
                UsuariNegoci uNegoci = new UsuariNegoci();
                u = uNegoci.GetUsuari(TxtBoxUser.Text);
                if (u.Contrasenya != PsswdLogIn.Password)
                {
                    MessageBox.Show("Has introduït una contrasenya incorrecta");
                }
                else
                {
                    MainWindow main = new MainWindow(u);
                    main.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("ERROR: Hi ha hagut un error en el procés de 'Log In'");
            }
        }
        /// <summary>
        /// Si l'aplicació està inicialitzada, quan s'escrigui comprovarà si el botó ha d'estar disponible o no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Escriure(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }
        /// <summary>
        /// Si l'aplicació està inicialitzada, quan s'escrigui a un camp de contrasenya comprovarà si el botó ha d'estar disponible o no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PsswdLogIn_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }
    }
}
