using System.Windows;
using Y.Negoci;


namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void TxtBoxUser_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxUser.Text == "Usuari")
                TxtBoxUser.Text = "";
        }

        private void TxtBoxUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxUser.Text == string.Empty)
                TxtBoxUser.Text = "Usuari";
        }

        private void PsswdRegister_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PsswdRegister.Password == "Contrasenya")
                PsswdRegister.Password = "";
        }

        private void PsswdRegister_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PsswdRegister.Password == string.Empty)
                PsswdRegister.Password = "Contrasenya";
        }

        private void PsswdRegister2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PsswdRegister2.Password == "Contrasenya")
                PsswdRegister2.Password = "";
        }

        private void PsswdRegister2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PsswdRegister2.Password == string.Empty)
                PsswdRegister2.Password = "Contrasenya";
        }

        private void TxtBoxNom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxNom.Text == "Nom")
                TxtBoxNom.Text = "";
        }

        private void TxtBoxNom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxNom.Text == string.Empty)
                TxtBoxNom.Text = "Nom";
        }

        private void TxtBoxCognom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCognom.Text == "Cognom")
                TxtBoxCognom.Text = "";
        }

        private void TxtBoxCognom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCognom.Text == string.Empty)
                TxtBoxCognom.Text = "Cognom";
        }

        private void TxtBoxCorreu_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCorreu.Text == "Correu")
                TxtBoxCorreu.Text = "";
        }

        private void TxtBoxCorreu_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCorreu.Text == string.Empty)
                TxtBoxCorreu.Text = "Correu";
        }

        private void TxtBoxTelefon_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxTelefon.Text == "Telefon")
                TxtBoxTelefon.Text = "";
        }

        private void TxtBoxTelefon_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxTelefon.Text == string.Empty)
                TxtBoxTelefon.Text = "Telefon";
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            UsuariModel u = new UsuariModel();
            if (PsswdRegister.Password == PsswdRegister2.Password)
                u.Contrasenya = PsswdRegister.Password;
            u.Username = TxtBoxUser.Text;
            u.Nom = TxtBoxNom.Text;
            u.Cognom = TxtBoxCognom.Text;
            u.Correu = TxtBoxCorreu.Text;
            u.Telefon = TxtBoxTelefon.Text;
            UsuariNegoci uNegoci = new UsuariNegoci();
            uNegoci.Usuari = u;
            uNegoci.Inserir();
        }
    }
}
