using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// La classe "UsuariNegoci" serà la que validarà els objectes "UsuariModel" i la que la vista cridarà per accedir als mètodes d'Accés a dades
    /// </summary>
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
        /// <summary>
        /// Obté un usuari a partir del seu user_id
        /// </summary>
        /// <param name="id">user_id</param>
        /// <returns>usuari</returns>
        public UsuariModel GetUsuari(int id)
        {
            return UsuariDB.GetUsuari(id);
        }
        /// <summary>
        /// Obté un usuari a partir del seu nom d'usuari
        /// </summary>
        /// <param name="username">nom d'usuari</param>
        /// <returns>usuari</returns>
        public UsuariModel GetUsuari(string username)
        {
            return UsuariDB.GetUsuari(username);
        }
        /// <summary>
        /// Afegeix un usuari a la base de dades
        /// </summary>
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
        /// <summary>
        /// Modifica un usuari de la base de dades
        /// </summary>
        public void Update()
        {
            UsuariDB.UpdatePerfil(Usuari);
        }
        /// <summary>
        /// Valida si els camps de l'usuari que són obligatoris no siguin nuls
        /// </summary>
        /// <returns>true si els camps son valids, false si no</returns>
        public bool Validar()
        {
            if (Usuari.Username == "" ||  Usuari.Contrasenya == ""  || Usuari.Nom == ""  || Usuari.Correu == "") return false;
            else return true;
        }
    }
}
