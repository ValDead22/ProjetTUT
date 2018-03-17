using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Commande
{
    public interface ICommandeDataAccessLayer
    {
        List<Entity.Commande> GetAllCommandes();

        void AddCommande(Entity.Commande commande);

        Entity.Commande GetTheLastInsertedCommande();

        void AddPlatToCommande(Entity.Plat plat, Entity.Commande commande);

    }
}
