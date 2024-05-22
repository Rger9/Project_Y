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
        public void Inserir()
        {
            PublicacioDB pdb = new PublicacioDB();
            pdb.Inserir(publicacio);
        }
        public bool Validar()
        {
            if (publicacio == null) return false;
            if(this.HasNull()) return false;
            UsuariDB udb = new UsuariDB();
            List<int> llistaId = new List<int>();
            //llistaId = udb.ObtenirTotsId();
            if (llistaId.Contains(publicacio.Publicacio_id)) return true;
            return false;
        }
        public bool HasNull()
        {
            return publicacio.User_id == null || publicacio.Contingut == null || publicacio.Data_p == null || publicacio.Titol == null;
        }
    }
}
