using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Y.Model;
using Y.Negoci;

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Publicar.xaml
    /// </summary>
    public partial class Publicar : Window
    {
        private UsuariModel usuari;
        private bool placeholderTitol;
        private bool placeholderContingut;
        private bool placeholderEtiquetes;
        public Publicar(UsuariModel u)
        {
            InitializeComponent();
            usuari = u;
            placeholderContingut = true;
            placeholderEtiquetes = true;
            placeholderTitol = true;
            BtnPublicar.IsEnabled = false;
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            // Publicar un article modifica les bases de dades PUBLICACIO, TAG i TAGPUBLICACIO
            // AFEGIM PUBLICACIO
            PublicacioModel p = new PublicacioModel();
            p.Titol = TxtBoxTitol.Text;
            p.Contingut = TxtBoxTitol.Text;
            p.Data_p = DateTime.Now;
            p.User_id = usuari.User_id;
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            pNegoci.Publicacio = p;
            

            // AFEGIM TAGS
            string[] tags = TxtBoxEtiqueta.Text.Split(", ");
            List<string> tagsList = new List<string>();
            for (int i = 0; i < tags.Length; i++)
            {
                tagsList.Add(tags[i]);
            }
            pNegoci.Inserir(tagsList);
            this.Close();
        }

        private void TxtBoxTitol_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderTitol)
            {
                TxtBoxTitol.Text = string.Empty;
                TxtBoxTitol.Foreground = Brushes.White;
                placeholderTitol = false;
            }
            ComprovarButton();
        }

        private void TxtBoxTitol_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxTitol.Text == string.Empty)
            {
                TxtBoxTitol.Text = "TÍTOL";
                TxtBoxTitol.Foreground = Brushes.LightGray;
                placeholderTitol = true;
            }
        }

        private void TxtBoxCos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderContingut)
            {
                TxtBoxCos.Text = string.Empty;
                TxtBoxCos.Foreground = Brushes.White;
                placeholderContingut = false;
            }
            ComprovarButton();
        }

        private void TxtBoxCos_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxCos.Text == string.Empty)
            {
                TxtBoxCos.Text = "Escriu la teva publicació aquí";
                TxtBoxCos.Foreground = Brushes.LightGray;
                placeholderContingut = true;
            }
        }

        private void TxtBoxEtiqueta_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderEtiquetes)
            {
                TxtBoxEtiqueta.Text = string.Empty;
                TxtBoxEtiqueta.Foreground = Brushes.White;
                placeholderEtiquetes = false;
            }
            ComprovarButton();
        }

        private void TxtBoxEtiqueta_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxEtiqueta.Text == string.Empty)
            {
                TxtBoxEtiqueta.Text = "etiqueta1, etiqueta2, etiqueta3...";
                TxtBoxEtiqueta.Foreground = Brushes.LightGray;
                placeholderEtiquetes = true;
            }
        }
        private void ComprovarButton()
        {
            if ((!(placeholderContingut || placeholderEtiquetes || placeholderTitol)) && TxtBoxCos.Text != string.Empty && TxtBoxEtiqueta.Text != string.Empty && TxtBoxTitol.Text != string.Empty)
            {
                BtnPublicar.IsEnabled = true;
            }
            else BtnPublicar.IsEnabled = false;
        }

        private void Escriure(object sender, TextChangedEventArgs e)
        {
            if (IsInitialized)
            ComprovarButton();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
