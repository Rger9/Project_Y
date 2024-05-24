using System.Windows;
using Y.Negoci;

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TxtBoxUser_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TxtBoxUser.Text == "Usuari")
                TxtBoxUser.Text = "";
        }
        private void TxtBoxUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if(TxtBoxUser.Text == string.Empty)
                TxtBoxUser.Text = "Usuari";
        }
        private void PsswdLogIn_GotFocus(object sender, RoutedEventArgs e)
        {
            if(PsswdLogIn.Password== "Contrasenya")
                PsswdLogIn.Password = "";
        }
        private void PsswdLogIn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PsswdLogIn.Password == string.Empty)
                PsswdLogIn.Password = "Contrasenya";
        }
        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Register register = new();
            register.Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuariNegoci uNegoci = new UsuariNegoci();
                uNegoci.GetUsuari(TxtBoxUser.Text);
            }
            catch
            {
                MessageBox.Show("NYE");
            }
        }
    }
}
