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
    /// La classe "ComentariNegoci" serà la que validarà els objectes "ComentariModel" i la que la vista cridarà per accedir als mètodes d'Accés a dades
    /// </summary>
    internal class ComentariNegoci
    {
        //Atributs
        private ComentariModel comentari;
        //Propietats
        public ComentariModel Comentari { get; set; }
        //Metodes
        /// <summary>
        /// Obté el comentari a partir del seu id
        /// </summary>
        /// <param name="id">comentari_id</param>
        /// <returns>comentari</returns>
        public static ComentariModel GetComentariDB(int id)
        {
            return ComentariDB.GetComentari(id);
        }
        /// <summary>
        /// Si el comentari és vàlid, l'inserirà a la base de dades
        /// </summary>
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                ComentariDB.Inserir(Comentari);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR COMENTARI A LA BASE DE DADES");
            }
            
        }
        /// <summary>
        /// Comprova que els comentaris siguin vàlids.
        /// </summary>
        /// <returns>true si són vàlids, false si no</returns>
        public bool Validar()
        {
            if(Comentari == null) return false;
            if(this.HasNull() ) return false;
            PublicacioDB pdb = new PublicacioDB();
            List<int> llistaId = PublicacioDB.ObtenirTotsId();
            if (llistaId.Contains(Comentari.Publicacio_id)) 
            {
                llistaId = UsuariDB.ObtenirTotsId();
                if (llistaId.Contains(Comentari.User_id)) return true;
            }
            return false;
        }
        /// <summary>
        /// Comprova si alguna de les Propietats dels comentaris és errònea o nula
        /// </summary>
        /// <returns>true si té una propietat errònea o nula, false si no</returns>
        public bool HasNull()
        {
            return Comentari.User_id == 0 || Comentari.Publicacio_id == 0 || Comentari.Contingut == null || Comentari.Contingut == "" || Comentari.Data_c == DateTime.MinValue;
        }
        /// <summary>
        /// Aconsegueix una llista amb tots els comentaris d'una certa publicació
        /// </summary>
        /// <param name="postId">id de la publicacio</param>
        /// <returns>Una llista amb els comentaris</returns>
        public List<ComentariModel> GetComentarisPost(int postId)
        {
            return ComentariDB.GetComentarisPost(postId);
        }
        /// <summary>
        /// Fa una còpia d'un comentari paràmetre
        /// </summary>
        /// <param name="comentariModel">Comentari</param>
        /// <returns>La còpia del paràmetre</returns>
        public static ComentariModel GetComentariCopy(ComentariModel comentariModel)
        {
            ComentariModel cm = new ComentariModel();
            cm.Comentari_id = comentariModel.Comentari_id;
            cm.User_id = comentariModel.User_id;
            cm.Publicacio_id = comentariModel.Publicacio_id;
            cm.Data_c = comentariModel.Data_c;
            cm.Contingut = comentariModel.Contingut;
            return cm;
        }
    }
}
