using System.Windows;
using System.Windows.Media;
using Y.Negoci;


namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private bool placeholderUsername;
        private bool placeholderPassword;
        private bool placeholderPassword2;
        private bool placeholderNom;
        private bool placeholderCognom;
        private bool placeholderCorreu;
        private bool placeholderTelefon;
        public Register()
        {
            InitializeComponent();
            placeholderUsername = true;
            placeholderPassword = true;
            placeholderPassword2 = true;
            placeholderNom = true;
            placeholderCognom = true;
            placeholderCorreu = true;
            placeholderTelefon = true;
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

        private void PsswdRegister_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderPassword)
            {
                PsswdRegister.Password = string.Empty;
                PsswdRegister.Foreground = Brushes.White;
                placeholderPassword = false;
            }
            ComprovarButton();
        }

        private void PsswdRegister_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (PsswdRegister.Password == string.Empty)
            {
                PsswdRegister.Password = "abcdef";
                PsswdRegister.Foreground = Brushes.LightGray;
                placeholderPassword = true;
            }
        }

        private void PsswdRegister2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderPassword2)
            {
                PsswdRegister2.Password = string.Empty;
                PsswdRegister2.Foreground = Brushes.White;
                placeholderPassword2 = false;
            }
            ComprovarButton();
        }

        private void PsswdRegister2_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (PsswdRegister2.Password == string.Empty)
            {
                PsswdRegister2.Password = "abcdef";
                PsswdRegister2.Foreground = Brushes.LightGray;
                placeholderPassword2 = true;
            }
        }

        private void TxtBoxNom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderNom)
            {
                TxtBoxNom.Text = string.Empty;
                TxtBoxNom.Foreground = Brushes.White;
                placeholderNom = false;
            }
            ComprovarButton();
        }

        private void TxtBoxNom_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxNom.Text == string.Empty)
            {
                TxtBoxNom.Text = "Nom";
                TxtBoxNom.Foreground = Brushes.LightGray;
                placeholderNom = true;
            }
        }

        private void TxtBoxCognom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderCognom)
            {
                TxtBoxCognom.Text = string.Empty;
                TxtBoxCognom.Foreground = Brushes.White;
                placeholderCognom = false;
            }
            ComprovarButton();
        }

        private void TxtBoxCognom_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxCognom.Text == string.Empty)
            {
                TxtBoxCognom.Text = "Cognom";
                TxtBoxCognom.Foreground = Brushes.LightGray;
                placeholderCognom = true;
            }
        }

        private void TxtBoxCorreu_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderCorreu)
            {
                TxtBoxCorreu.Text = string.Empty;
                TxtBoxCorreu.Foreground = Brushes.White;
                placeholderCorreu = false;
            }
            ComprovarButton();
        }

        private void TxtBoxCorreu_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxCorreu.Text == string.Empty)
            {
                TxtBoxCorreu.Text = "Correu";
                TxtBoxCorreu.Foreground = Brushes.LightGray;
                placeholderCorreu = true;
            }
        }

        private void TxtBoxTelefon_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderTelefon)
            {
                TxtBoxTelefon.Text = string.Empty;
                TxtBoxTelefon.Foreground = Brushes.White;
                placeholderTelefon = false;
            }
            ComprovarButton();
        }

        private void TxtBoxTelefon_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxTelefon.Text == string.Empty)
            {
                TxtBoxTelefon.Text = "633123123";
                TxtBoxTelefon.Foreground = Brushes.LightGray;
                placeholderTelefon = true;
            }
        }
        private void ComprovarButton()
        {
            if (!(placeholderPassword || placeholderUsername || placeholderPassword2 || placeholderNom || placeholderCorreu) && 
                TxtBoxUser.Text != string.Empty && PsswdRegister.Password != string.Empty && PsswdRegister2.Password != string.Empty && TxtBoxNom.Text != string.Empty && TxtBoxCorreu.Text != string.Empty)
            {
                BtnRegister.IsEnabled = true;
            }
            else BtnRegister.IsEnabled = false;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            UsuariModel u = new UsuariModel();
            if (PsswdRegister.Password == PsswdRegister2.Password)
                u.Contrasenya = PsswdRegister.Password;
            u.Username = TxtBoxUser.Text;
            u.Nom = TxtBoxNom.Text;
            if (!placeholderCognom)
                u.Cognom = TxtBoxCognom.Text;
            else u.Cognom = string.Empty;
            u.Correu = TxtBoxCorreu.Text;
            if (!placeholderTelefon)
                u.Telefon = TxtBoxTelefon.Text;
            else u.Telefon = string.Empty;
            UsuariNegoci uNegoci = new UsuariNegoci();
            uNegoci.Usuari = u;
            uNegoci.Inserir();
        }

        private void Escriure(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }

        private void Escriure(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
                ComprovarButton();
        }
    }
}
