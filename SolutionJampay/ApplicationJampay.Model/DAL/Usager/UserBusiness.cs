using ApplicationJampay.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    public class UserBusiness
    {
        private IUserDataAccessLayer _userDAL;

        public UserBusiness()
        {
            _userDAL = new UserDataAccessLayer();
        }

        public Entity.Utilisateur GetUser(string matricule, string password)
        {
            return _userDAL.GetUser(matricule, password);
        }
    }
}
