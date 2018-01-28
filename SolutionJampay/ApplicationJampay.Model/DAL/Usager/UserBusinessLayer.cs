using ApplicationJampay.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    public class UserBusinessLayer
    {
        private UserDataAccessLayer _userDAL;

        public UserBusinessLayer()
        {
            _userDAL = new UserDataAccessLayer();
        }

        public string GetUser(string matricule, string password)
        {
            return _userDAL.GetUser(matricule, password);
        }
    }
}
