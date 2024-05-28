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
    /// Finestra de publicar, la qual permetrà a l'usuari realitzar publicacions
    /// </summary>
    public partial class Publicar : Window
    {
        private UsuariModel usuari;
        private bool placeholderTitol;
        private bool placeholderContingut;
        private bool placeholderEtiquetes;
        /// <summary>
        /// Finestra de publicar, amb l'usuari loguejat
        /// </summary>
        /// <param name="u">usuari</param>
        public Publicar(UsuariModel u)
        {
            InitializeComponent();
            usuari = u;
            placeholderContingut = true;
            placeholderEtiquetes = true;
            placeholderTitol = true;
            BtnPublicar.IsEnabled = false;
        }
        /// <summary>
        /// Al fer click al botó BtnPublicar, construïrà l'objecte PublicacioModel a partir dels camps de text i l'enviarà a la capa negoci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                string formatat = TagNegoci.FormatarString(tags[i]);
                if(!tagsList.Contains(formatat)) tagsList.Add(formatat);
            }
            pNegoci.Inserir(tagsList);

            // NOTIFIQUEM A L'USUARI I OBRIR LA MAIN WINDOW
            MessageBox.Show("El teu post s'ha publicat correctament!");
            MainWindow main = new MainWindow(usuari);
            main.Show();
            this.Close();
        }
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Mentre els camps necessaris no s'hagin emplenat, el botó no estarà disponible
        /// </summary>
        private void ComprovarButton()
        {
            if ((!(placeholderContingut || placeholderEtiquetes || placeholderTitol)) && TxtBoxCos.Text != string.Empty && TxtBoxEtiqueta.Text != string.Empty && TxtBoxTitol.Text != string.Empty)
            {
                BtnPublicar.IsEnabled = true;
            }
            else BtnPublicar.IsEnabled = false;
        }
        /// <summary>
        /// Comprovarà si el botó ha d'estar dispobible o no mentre s'escrigui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Escriure(object sender, TextChangedEventArgs e)
        {
            if (IsInitialized)
            ComprovarButton();
        }
        /// <summary>
        /// Tanca la finestra publicació i obre la principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(usuari);
            main.Show();
            this.Close();
        }
    }
}
