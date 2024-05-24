using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.Model;

namespace Y.Negoci
{
    internal class ComentariNegoci
    {
        //Atributs
        private ComentariModel comentari;
        //Propietats
        public ComentariModel Comentari { get; set; }
        //Metodes
        public static ComentariModel GetComentariDB(int id)
        {
            return ComentariDB.GetComentari(id);
        }
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                ComentariDB.Inserir(comentari);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR COMENTARI A LA BASE DE DADES");
            }
            
        }
        public bool Validar()
        {
            if(comentari == null) return false;
            if(this.HasNull() ) return false;
            PublicacioDB pdb = new PublicacioDB();
            List<int> llistaId = PublicacioDB.ObtenirTotsId();
            if (llistaId.Contains(comentari.Publicacio_id)) 
            {
                llistaId = UsuariDB.ObtenirTotsId();
                if (llistaId.Contains(comentari.User_id)) return true;
            }
            return false;
        }
        public bool HasNull()
        {
            return comentari.User_id == 0 || comentari.Publicacio_id == 0 || comentari.Contingut == null || comentari.Contingut == "" || comentari.Data_c == DateTime.MinValue;
        }
        public List<ComentariModel> GetComentarisPost(int postId)
        {
            return ComentariDB.GetComentarisPost(postId);
        }
    }
}
