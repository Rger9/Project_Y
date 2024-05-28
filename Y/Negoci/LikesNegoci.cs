using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;
using Y.AccesADades;
using System.Windows;

namespace Y.Negoci
{
    internal class LikesNegoci
    {
        //Atributs
        private LikesModel likes;
        //Propietats
        public LikesModel Likes { get { return likes; } set { likes = value; ;} }
        //Metodes
        public static List<int> GetUsersDB(int publicacio_id)
        {
            return LikesDB.GetUsers(publicacio_id);
        }
        public static LikesModel GetLikesCopy(LikesModel l)
        {
            LikesModel likesModel = new LikesModel();
            likesModel.Publicacio_id = l.Publicacio_id;
            likesModel.User_id = l.User_id;
            return likesModel;
        }
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                LikesDB.Inserir(likes);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR LIKE A LA BASE DE DADES");
            }
        }
        public bool Validar()
        {
            if (likes is null) return false;
            if(likes.Publicacio_id == 0) return false;
            if(likes.User_id == 0) return false;
            if(!PublicacioDB.ObtenirTotsId().Contains(likes.Publicacio_id)) return false;
            if(!UsuariDB.ObtenirTotsId().Contains(likes.User_id)) return false;
            if(LikesDB.GetUsers(likes.Publicacio_id).Contains(likes.User_id)) return false;
            return true;
        }
    }
}
