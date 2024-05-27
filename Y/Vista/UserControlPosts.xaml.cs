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

namespace Y.Vista
{
    /// <summary>
    /// Lógica de interacción para UserControlPosts.xaml
    /// </summary>
    public partial class UserControlPosts : UserControl
    {
        public UserControlPosts()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Titol { get; set; }
        public string Missatge { get; set; }
        public string URL { get; set; }
    }
}
