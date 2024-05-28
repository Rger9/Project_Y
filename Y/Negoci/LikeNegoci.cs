using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;
using Y.AccesADades;
using System.Windows;

namespace Y.Negoci
{/// <summary>
 /// La classe "LikesNegoci" serà la que validarà els objectes "LikeModel" i la que la vista cridarà per accedir als mètodes d'Accés a dades
 /// </summary>
    internal class LikeNegoci
    {
        //Atributs
        private LikeModel like;
        //Propietats
        public LikeModel Like { get { return like; } set { like = value; ;} }
        //Metodes
        /// <summary>
        /// Donara una llista dels usuaris que ha donat like a una publicacio
        /// </summary>
        /// <param name="publicacio_id">publicacio_id</param>
        /// <returns>llista d'usuari_ids</returns>
        public static List<int> GetUsersDB(int publicacio_id)
        {
            return LikeDB.GetUsers(publicacio_id);
        }
        /// <summary>
        /// Copia l'objecte LikeModel paràmetre
        /// </summary>
        /// <param name="l">Like original</param>
        /// <returns>like còpia</returns>
        public static LikeModel GetLikesCopy(LikeModel l)
        {
            LikeModel like = new LikeModel();
            like.Publicacio_id = l.Publicacio_id;
            like.User_id = l.User_id;
            return like;
        }
        /// <summary>
        /// Insereix un like a la base de dades
        /// </summary>
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                LikeDB.Inserir(Like);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR LIKE A LA BASE DE DADES");
            }
        }
        /// <summary>
        /// Elimina un like de la base de dades
        /// </summary>
        public void Delete()
        {
            try
            {
                if (!Validar()) throw new Exception();
                LikeDB.Delete(Like);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/BORRAR LIKE A LA BASE DE DADES");
            }
        }
        /// <summary>
        /// Comprova si existeix un like a la base de dades
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            return LikeDB.Exists(Like);
        }
        /// <summary>
        /// Valida si les dades del like son correctes
        /// </summary>
        /// <returns>True si son correctes, false si no</returns>
        public bool Validar()
        {
            if (Like is null) return false;
            if(Like.Publicacio_id == 0) return false;
            if(Like.User_id == 0) return false;
            if(!PublicacioDB.ObtenirTotsId().Contains(Like.Publicacio_id)) return false;
            if(!UsuariDB.ObtenirTotsId().Contains(Like.User_id)) return false;
            if(LikeDB.GetUsers(Like.Publicacio_id).Contains(Like.User_id)) return false;
            return true;
        }
    }
}
