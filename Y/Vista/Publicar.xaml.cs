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
        public Publicar(UsuariModel u)
        {
            InitializeComponent();
            TxtBoxCos.Focus();
            usuari = u;
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            // Publicar un article modifica les bases de dades PUBLICACIO, TAG i TAGPUBLICACIO
            PublicacioModel p = new PublicacioModel();
            p.Titol = TxtBoxTitol.Text;
            p.Contingut = TxtBoxTitol.Text;
            p.Data_p = DateTime.Now;
            p.User_id = usuari.User_id;
            PublicacioNegoci pNegoci = new PublicacioNegoci();
            pNegoci.Publicacio = p;
            // pNegoci.Inserir();

            string[] tags = TxtBoxEtiqueta.Text.Split(", ");
            for (int i  = 0; i < tags.Length; i++)
            {
                TagModel t = new TagModel();
                t.Nom = tags[i];
                TagNegoci tNegoci = new TagNegoci();
                tNegoci.Tag = t;
                // tNegoci.Inserir();

                TagpublicacioModel tp = new TagpublicacioModel();
                // FER MÈTODE QUE BUSQUI EL STRING TAG I RETORNI ID:
                //tp.Tag_id = tags[i];
                tp.Publicacio_id = p.Publicacio_id;
            }

        }

        private void TxtBoxTitol_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxTitol.Text == "TÍTOL")
            {
                TxtBoxTitol.Text = string.Empty;
                TxtBoxTitol.Foreground = Brushes.Black;
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
            }
        }

        private void TxtBoxCos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCos.Text == "Escriu la teva publicació aquí")
            {
                TxtBoxCos.Text = string.Empty;
                TxtBoxCos.Foreground = Brushes.Black;
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
            }
        }

        private void TxtBoxEtiqueta_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxEtiqueta.Text == "etiqueta1, etiqueta2, etiqueta3...")
            {
                TxtBoxEtiqueta.Text = string.Empty;
                TxtBoxEtiqueta.Foreground = Brushes.Black;
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
            }
        }
        private void ModificarText()
        {
            if (TxtBoxTitol.Text != string.Empty && TxtBoxCos.Text != string.Empty && TxtBoxEtiqueta.Text != string.Empty)
            {
                BtnPublicar.IsEnabled = true;
            }
            else BtnPublicar.IsEnabled = false;
        }
    }
}
