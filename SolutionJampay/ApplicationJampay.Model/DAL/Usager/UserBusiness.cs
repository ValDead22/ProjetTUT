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

        public UserBusiness(IUserDataAccessLayer accessLayer)
        {
            _userDAL = accessLayer;
        }

        public Entity.Utilisateur GetUser(string matricule, string password)
        {
            return _userDAL.GetUser(matricule, password);
        }
    }
}
