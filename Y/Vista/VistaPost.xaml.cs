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
        private UsuariModel usuari;
        private PublicacioModel publicacio;
        private List<ComentariModel> llistaComentaris;
        private bool placeholderComentari;
        private List<string> contingutComentaris;
        public VistaPost(UsuariModel u, PublicacioModel p)
        {
            InitializeComponent();
            usuari = u;
            BtnComentar.IsEnabled = false;
            placeholderComentari = true;
            publicacio = p;
            ComentariNegoci cNegoci = new ComentariNegoci();
            UsuariNegoci uNegoci = new UsuariNegoci();
            llistaComentaris = cNegoci.GetComentarisPost(p.Publicacio_id);
            CarregarComentaris();
            BlockUsername.Text = uNegoci.GetUsuari(p.User_id).Username + " : ";
            BlockTitol.Text = p.Titol;
            BlockContingut.Text = p.Contingut;
            
            //BlockEtiquetes.Text = ACA TOTES LES ETIQUETES
        }
        private void CarregarComentaris()
        {
            UsuariNegoci uNegoci = new UsuariNegoci();
            contingutComentaris = new List<string>();
            foreach (ComentariModel comentari in llistaComentaris)
            {
                contingutComentaris.Add(uNegoci.GetUsuari(comentari.User_id).Username + ": " + comentari.Contingut);
            }
            ListBoxComentaris.ItemsSource = contingutComentaris;
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
            try
            {
                if (usuari.User_id == 0)
                {
                    throw new Exception();
                }
                else
                {
                    // Construïr el objecte "comentari"
                    ComentariModel comentari = new ComentariModel();
                    comentari.User_id = usuari.User_id;
                    comentari.Publicacio_id = publicacio.Publicacio_id;
                    comentari.Data_c = DateTime.Now;
                    comentari.Contingut = TxtBoxComentari.Text;

                    // Construïr "comentariNegoci", i igualem el seu atribut al comentari
                    ComentariNegoci comentariNegoci = new ComentariNegoci();
                    comentariNegoci.Comentari = comentari;
                    comentariNegoci.Inserir();

                    // Afegir a la llista de comentaris i recarregar-los
                    llistaComentaris.Add(comentari);
                    CarregarComentaris();

                    // Buidar la caixa per comentari i deshabilitar el botó
                    TxtBoxComentari.Text = string.Empty;
                    BtnComentar.IsEnabled = false;
                }
            }
            catch
            {
                MessageBox.Show("ERROR: Has d'iniciar sessió");
            }
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
