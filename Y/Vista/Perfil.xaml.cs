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
using Y.Negoci;

namespace Y.Vista
{
    /// <summary>
    /// Finestra de perfil, la qual permetrà a l'usuari modificar les seves dades
    /// </summary>
    public partial class Perfil : Window
    {
        private UsuariModel usuari;
        private bool placeholderUsername;
        private bool placeholderNom;
        private bool placeholderCognom;
        private bool placeholderCorreu;
        private bool placeholderTelefon;
        /// <summary>
        /// Finestra perfil, amb les dades de l'usuari loguejat
        /// </summary>
        /// <param name="u">usuari</param>
        public Perfil(UsuariModel u)
        {
            InitializeComponent();
            TxtBoxUsername.Text = u.Username;
            TxtBoxNom.Text = u.Nom;
            TxtBoxCognom.Text = u.Cognom;
            TxtBoxCorreu.Text = u.Correu;
            TxtBoxTelefon.Text = u.Telefon;
            placeholderUsername = false;
            placeholderNom = false;
            placeholderCorreu = false;
            if (TxtBoxCognom.Text == string.Empty)
            {
                placeholderCognom = false;
            }
            if (TxtBoxTelefon.Text == string.Empty)
            {
                placeholderTelefon = false;
            }
            usuari = u;
        }
        /// <summary>
        /// Si l'aplicacio està inicialitzada, mentre s'escrigui comprovarà si el botó ha d'estar disponible o no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Escriure(object sender, TextChangedEventArgs e)
        {
            if (IsInitialized)
            {
                ComprovarButton();
            }
        }
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderUsername)
            {
                TxtBoxUsername.Text = string.Empty;
                TxtBoxUsername.Foreground = Brushes.White;
                placeholderUsername = false;
            }
            ComprovarButton();
        }
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBoxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            ComprovarButton();
            if (TxtBoxUsername.Text == string.Empty)
            {
                TxtBoxUsername.Text = "Nom d'usuari";
                TxtBoxUsername.Foreground = Brushes.LightGray;
                placeholderUsername = true;
            }
        }
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a la caixa de text mentre mostra el seu text "placeholder", aquest es borrarà i permetrà escriure a l'usuari 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Si l'usuari fa click a qualsevol altre caixa o botó mentre no hi ha escrit res a la caixa de text, aquest mostrarà el seu text "placeholder" amb un color gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Permetrà a l'usuari fer click al botó BtnUpdate si els camps necessaris no estan buits
        /// </summary>
        private void ComprovarButton()
        {
            if (!(placeholderUsername || placeholderNom || placeholderCorreu) &&
                TxtBoxUsername.Text != string.Empty && TxtBoxNom.Text != string.Empty && TxtBoxCorreu.Text != string.Empty)
            {
                BtnUpdate.IsEnabled = true;
            }
            else BtnUpdate.IsEnabled = false;
        }
        /// <summary>
        /// Construeix l'usuari a partir dels camps de text, el porta a la capa negoci per actualitzar-lo a la base de dades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            usuari.Username = TxtBoxUsername.Text;
            usuari.Nom = TxtBoxNom.Text;
            usuari.Cognom = TxtBoxCognom.Text;
            usuari.Correu = TxtBoxCorreu.Text;
            usuari.Telefon = TxtBoxTelefon.Text;
            UsuariNegoci uNegoci = new UsuariNegoci();
            uNegoci.Usuari = usuari;
            uNegoci.Update();
            MessageBox.Show("S'han actualitzat les teves dades correctament!");
            this.Close();
            MainWindow main = new MainWindow(usuari);
            main.Show();
        }
        /// <summary>
        /// Cancela la modificació de perfil, torna a la finestra principal
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
