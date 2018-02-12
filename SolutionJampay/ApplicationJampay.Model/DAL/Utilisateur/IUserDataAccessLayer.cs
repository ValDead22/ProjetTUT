using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Utilisateur
{
    public interface IUserDataAccessLayer
    {
        Entity.Utilisateur GetUser(string matricule, string password);

        List<Entity.Utilisateur> GetAllUser();
    }
}
