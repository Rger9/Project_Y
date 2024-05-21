using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    internal class PublicacioNegoci
    {
        //Atributs
        private PublicacioModel publicacio;
        //Propietats
        public PublicacioModel Publicacio { get; set; }
        //Metodes
        public static PublicacioModel GetPublicacioDB(int id)
        {
            return PublicacioDB.GetPublicacio(id);
        }
        public static void Inserir()
        {
            PublicacioDB pdb = new PublicacioDB();
            pdb.Publicar(publicacio);
        }
        public static bool Validar()
        {
            PublicacioDB pdb = new PublicacioDB();
            UsuariDB udb = new UsuariDB();
            List<UsuariModel> uModel = udb.ObtenirTots();
        }
    }
}
