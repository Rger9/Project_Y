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
        public void Inserir(List<string> tags)
        {
            try
            {
                PublicacioDB.Inserir(Publicacio);
                List<int> t = PublicacioDB.ObtenirTotsId();
                Publicacio.Publicacio_id = t.Max();
                InserirTags(tags, Publicacio.Publicacio_id);
            }
            catch
            {
                MessageBox.Show("Error al inserir la publicacio");
            }
            
        }
        public PublicacioModel GetPublicacio(int id)
        {
            return PublicacioDB.GetPublicacio(id);
        }
        public void InserirTags(List<string> tags, int id_publi)
        {
            try
            {
                //if (!Validar()) throw new Exception();
                foreach (string tag in tags)
                {
                    if(!TagNegoci.Existeix(tag))
                    {
                        TagNegoci tagNegoci = new TagNegoci();
                        tagNegoci.Tag = new TagModel();
                        tagNegoci.Tag.Nom = TagNegoci.FormatarString(tag);
                        tagNegoci.Inserir();
                    }
                    int id_tag = TagDB.GetTag_Id(tag);
                    TagpublicacioModel tpm = new TagpublicacioModel();
                    tpm.Publicacio_id = id_publi;
                    tpm.Tag_id = id_tag;
                    TagpublicacioNegoci tpn = new TagpublicacioNegoci(tpm);
                    tpn.Inserir();
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR PUBLICACIO A LA BASE DE DADES");
            }
            
        }
        public bool Validar()
        {
            if (Publicacio == null) return false;
            if(this.HasNull()) return false;
            List<int> llistaId = new List<int>();
            llistaId = UsuariDB.ObtenirTotsId();
            if (llistaId.Contains(Publicacio.Publicacio_id)) return true;
            return false;
        }
        public bool HasNull()
        {
            return Publicacio.User_id == 0 || Publicacio.Contingut == null || Publicacio.Contingut == "" || Publicacio.Data_p == DateTime.MinValue || Publicacio.Titol == null || Publicacio.Titol == "";
        }
        public List<int> ObtenirTotsId()
        {
            return PublicacioDB.ObtenirTotsId();
        }
    }
}
