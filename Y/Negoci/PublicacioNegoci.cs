using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                if (!Validar()) throw new Exception();
                PublicacioDB.Inserir(publicacio);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR A LA BASE DE DADES");
            }
            
        }
        public bool Validar()
        {
            if (publicacio == null) return false;
            if(this.HasNull()) return false;
            List<int> llistaId = new List<int>();
            llistaId = UsuariDB.ObtenirTotsId();
            if (llistaId.Contains(publicacio.Publicacio_id)) return true;
            return false;
        }
        public bool HasNull()
        {
            return publicacio.User_id == 0 || publicacio.Contingut == null || publicacio.Contingut == "" || publicacio.Data_p == DateTime.MinValue || publicacio.Titol == null || publicacio.Titol == "";
        }
    }
}
