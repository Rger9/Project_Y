using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// L''objecte UsuariModel, format pel seu id d'usuari, el nom d'usuari, la contrasenya, el nom i cognom de la persona, el seu correu i el seu telefon
    /// </summary>
    public class UsuariModel
    {
        //Atributs
        private int user_id;
        private string username;
        private string contrasenya;
        private string nom;
        private string cognom;
        private string correu;
        private string telefon;
        //Propietats
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Contrasenya { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string Correu { get; set; }
        public string Telefon { get; set; }
    }
}
