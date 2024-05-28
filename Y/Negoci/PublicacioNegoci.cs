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
    /// La classe "PublicacioNegoci" serà la que validarà els objectes "PublicacioModel", associarà tags a certes publicacions, i la que la vista cridarà per accedir als mètodes d'Accés a dades
    /// </summary>
    internal class PublicacioNegoci
    {
        //Atributs
        private PublicacioModel publicacio;
        //Propietats
        public PublicacioModel Publicacio { get; set; }
        //Metodes
        /// <summary>
        /// Insereix publicacio, associada a llista de Tags
        /// </summary>
        /// <param name="tags">Llista de tags</param>
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
        /// <summary>
        /// Obté una publicació donada l'Id d'aquesta
        /// </summary>
        /// <param name="id">publicacio_id</param>
        /// <returns>La publicació</returns>
        public PublicacioModel GetPublicacio(int id)
        {
            return PublicacioDB.GetPublicacio(id);
        }
        /// <summary>
        /// Insereix una llista de tags les quals prèviament comprova si ja existeixen, a les taules Tag i Tagpublicacio de la base de dades
        /// </summary>
        /// <param name="tags">Llista de tags</param>
        /// <param name="id_publi">Id de la publicacio</param>
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
        /// <summary>
        /// Comprova que la publicació sigui vàlida
        /// </summary>
        /// <returns>true si és vàlida, false si no</returns>
        public bool Validar()
        {
            if (Publicacio == null) return false;
            if(this.HasNull()) return false;
            List<int> llistaId = new List<int>();
            llistaId = UsuariDB.ObtenirTotsId();
            if (llistaId.Contains(Publicacio.Publicacio_id)) return true;
            return false;
        }
        /// <summary>
        /// Comprova que les propietats de la publicació no tinguin valos incorrectes o nuls
        /// </summary>
        /// <returns>True si alguna propietat té un valor erroni, false en cas contrari</returns>
        public bool HasNull()
        {
            return Publicacio.User_id == 0 || Publicacio.Contingut == null || Publicacio.Contingut == "" || Publicacio.Data_p == DateTime.MinValue || Publicacio.Titol == null || Publicacio.Titol == "";
        }
        /// <summary>
        /// Obté totes les publicacio_id de la base de dades
        /// </summary>
        /// <returns>Llista amb totes les publicacio_id</returns>
        public List<int> ObtenirTotsId()
        {
            return PublicacioDB.ObtenirTotsId();
        }
    }
}
