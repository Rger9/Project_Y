using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
                ComentariDB.Inserir(Comentari);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR COMENTARI A LA BASE DE DADES");
            }
            
        }
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
        public bool HasNull()
        {
            return Comentari.User_id == 0 || Comentari.Publicacio_id == 0 || Comentari.Contingut == null || Comentari.Contingut == "" || Comentari.Data_c == DateTime.MinValue;
        }
        public List<ComentariModel> GetComentarisPost(int postId)
        {
            return ComentariDB.GetComentarisPost(postId);
        }
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
        public static string GetTimeAgo(ComentariModel cm)
        {
            DateTime ara = DateTime.Now;
            TimeSpan diferencia = ara - cm.Data_c;
            //DateTime diferencia = Convert.ToDateTime(ara.Subtract(cm.Data_c));
            if(diferencia.Days > 365) return "Fa " + Math.Truncate((double)diferencia.Days/365).ToString() + " a";
            if (diferencia.Month > 0) return "Fa " + diferencia.Month.ToString() + " m";
            if (diferencia.Day > 0) return "Fa " + diferencia.Day.ToString() + " d";
            if (diferencia.Hour > 0) return "Fa " + diferencia.Hour.ToString() + " h";
            if (diferencia.Minute > 0) return "Fa " + diferencia.Minute.ToString() + " min";
            else return "Fa " + diferencia.Second.ToString() + " sec";
        }
    }
}
