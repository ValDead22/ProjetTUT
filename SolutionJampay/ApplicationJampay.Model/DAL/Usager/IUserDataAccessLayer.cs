using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    interface IUserDataAccessLayer
    {
        string GetUser(string matricule, string password);
    }
}
