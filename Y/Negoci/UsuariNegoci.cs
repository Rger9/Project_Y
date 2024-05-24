using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Inserir()
        {
            UsuariDB.Inserir(usuari);
        }
        public UsuariModel GetUsuari(int id)
        {
            return UsuariDB.GetUsuari(id);
        }
        public UsuariModel GetUsuari(string username)
        {
            return UsuariDB.GetUsuari(username);
        }
    }
}
