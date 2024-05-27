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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Y.Negoci;

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaPost.xaml
    /// </summary>
    public partial class VistaPost : Page
    {
        private PublicacioModel publicacio;
        private List<ComentariModel> llistaComentaris;
        private bool placeholderComentari;
        public VistaPost(UsuariModel u, PublicacioModel p)
        {
            InitializeComponent();
            placeholderComentari = true;
            publicacio = p;
            ComentariNegoci cNegoci = new ComentariNegoci();
            UsuariNegoci uNegoci = new UsuariNegoci();
            llistaComentaris = cNegoci.GetComentarisPost(p.Publicacio_id);
            ListBoxComentaris.ItemsSource = llistaComentaris;
            BlockUsername.Text = uNegoci.GetUsuari(p.User_id).Username + " :";
            BlockTitol.Text = p.Titol;
            BlockContingut.Text = p.Contingut;
            //BlockEtiquetes.Text = ACA TOTES LES ETIQUETES
        }

        private void TxtBoxComentari_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderComentari)
            {
                TxtBoxComentari.Text = string.Empty;
                TxtBoxComentari.Foreground = Brushes.White;
                placeholderComentari = false;
            }
        }

        private void TxtBoxComentari_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxComentari.Text == string.Empty)
            {
                TxtBoxComentari.Text = "Comenta aqui";
                TxtBoxComentari.Foreground = Brushes.LightGray;
                placeholderComentari = false;
            }
        }

        private void BtnComentar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TxtBoxComentari_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsInitialized && placeholderComentari == false && TxtBoxComentari.Text != string.Empty)
            {
                BtnComentar.IsEnabled = true;
            }
            else if (IsInitialized)BtnComentar.IsEnabled = false;
        }
    }
}
