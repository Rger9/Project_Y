using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.Model;

namespace Y.Negoci
{
    public class UsuariNegoci
    {
        //Atributs
        private UsuariModel usuari;
        //Propietats
        public UsuariModel Usuari { get; set; }
        //Metodes
        public UsuariModel GetUsuari(int id)
        {
            return UsuariDB.GetUsuari(id);
        }
        public UsuariModel GetUsuari(string username)
        {
            return UsuariDB.GetUsuari(username);
        }
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                UsuariDB.Inserir(usuari);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR USUARI A LA BASE DE DADES");
            }
        }
        public bool Validar()
        {
            if(usuari == null) return false;
            if(this.HasNull()) return false;
            return true;
        }
        public bool HasNull()
        {
            return usuari.Username == null || usuari.Username == "" || usuari.Contrasenya == null || usuari.Contrasenya == "" || usuari.Description == null || usuari.Description == "" || usuari.Nom == null || usuari.Nom == "" || usuari.Correu == null || usuari.Correu == "";
        }
    }
}
