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
            pNegoci.Inserir();

            // AFEGIM TAGS
            string[] tags = TxtBoxEtiqueta.Text.Split(", ");
            List<string> tagsList = new List<string>();
            for (int i = 0; i < tags.Length; i++)
            {
                tagsList.Add(tags[i]);
            }
            // pNegoci.Inserir(tagsList);
        }

        private void TxtBoxTitol_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderTitol)
            {
                TxtBoxTitol.Text = string.Empty;
                TxtBoxTitol.Foreground = Brushes.Black;
                placeholderTitol = false;
            }
            ModificarText();
        }

        private void TxtBoxTitol_LostFocus(object sender, RoutedEventArgs e)
        {
            ModificarText();
            if (TxtBoxTitol.Text == string.Empty)
            {
                TxtBoxTitol.Text = "TÍTOL";
                TxtBoxTitol.Foreground = Brushes.Gray;
                placeholderTitol = true;
            }
        }

        private void TxtBoxCos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderContingut)
            {
                TxtBoxCos.Text = string.Empty;
                TxtBoxCos.Foreground = Brushes.Black;
                placeholderContingut = false;
            }
            ModificarText();
        }

        private void TxtBoxCos_LostFocus(object sender, RoutedEventArgs e)
        {
            ModificarText();
            if (TxtBoxCos.Text == string.Empty)
            {
                TxtBoxCos.Text = "Escriu la teva publicació aquí";
                TxtBoxCos.Foreground = Brushes.Gray;
                placeholderContingut = true;
            }
        }

        private void TxtBoxEtiqueta_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderEtiquetes)
            {
                TxtBoxEtiqueta.Text = string.Empty;
                TxtBoxEtiqueta.Foreground = Brushes.Black;
                placeholderEtiquetes = false;
            }
            ModificarText();
        }

        private void TxtBoxEtiqueta_LostFocus(object sender, RoutedEventArgs e)
        {
            ModificarText();
            if (TxtBoxEtiqueta.Text == string.Empty)
            {
                TxtBoxEtiqueta.Text = "etiqueta1, etiqueta2, etiqueta3...";
                TxtBoxEtiqueta.Foreground = Brushes.Gray;
                placeholderEtiquetes = true;
            }
        }
        private void ModificarText()
        {
            if (!(placeholderContingut || placeholderEtiquetes || placeholderTitol))
            {
                BtnPublicar.IsEnabled = true;
            }
            else BtnPublicar.IsEnabled = false;
        }
    }
}
