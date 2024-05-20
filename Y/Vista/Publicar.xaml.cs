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

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para Publicar.xaml
    /// </summary>
    public partial class Publicar : Window
    {
        public Publicar()
        {
            InitializeComponent();
            TxtBoxCos.Focus();
        }

        private void BtnPublicar_Click(object sender, RoutedEventArgs e)
        {
            Publicacio a = new Publicacio();
            string comanda = "INSERT INTO Publicacio(user_id, data_p, titol, contingut)" +
                                $"VALUES({a.user_id}, {a.data_p}, {a.titol}, {a.contingut})";
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
