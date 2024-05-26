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
        private void ComprovarButton()
        {
            if ((!placeholderPassword || placeholderUsername) && TxtBoxUser.Text != string.Empty && PsswdLogIn.Password != string.Empty)
            {
                BtnLogin.IsEnabled = true;
            }
            else BtnLogin.IsEnabled = false;
        }
        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Register register = new();
            register.Show();
            this.Close();
        }

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

        private void Escriure(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }

        private void PsswdLogIn_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }
    }
}
