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
        public UsuariModel Usuari
        {
            get { return usuari; }
            set { usuari = value; }
        }
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
                UsuariDB.Inserir(Usuari);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR USUARI A LA BASE DE DADES");
            }
        }
        public bool Validar()
        {
            if (usuari.Username == "" ||  usuari.Contrasenya == ""  || usuari.Nom == ""  || usuari.Correu == "") return false;
            else return true;
        }
        //public bool HasNull()
        //{
        //    return (usuari.Username == null || usuari.Username == "" || usuari.Contrasenya == null || usuari.Contrasenya == "" || usuari.Nom == null || usuari.Nom == "" || usuari.Correu == null || usuari.Correu == "");
        //}
        //public static bool operator == (string propietat, string valor)
        //{

        //}
    }
}
