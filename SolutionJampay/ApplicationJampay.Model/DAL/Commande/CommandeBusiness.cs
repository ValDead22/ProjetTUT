using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Commande
{
    public class CommandeBusiness
    {
        private ICommandeDataAccessLayer _commandeDAL;

        public CommandeBusiness()
        {
            _commandeDAL = new CommandeDataAccessLayer();
        }

        public void AddCommande(Entity.Commande commande)
        {
            try
            {
                _commandeDAL.AddCommande(commande);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Commande> GetAllCommandes()
        {
            try
            {
                return _commandeDAL.GetAllCommandes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entity.Commande GetTheLastInsertedCommande()
        {
            try
            {
                return _commandeDAL.GetTheLastInsertedCommande();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddPlatToCommande(Entity.Plat plat, Entity.Commande commande)
        {
            try
            {
                _commandeDAL.AddPlatToCommande(plat, commande);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetMontantCommande(Entity.Commande commande, float montant)
        {
            try
            {
                _commandeDAL.SetMontantCommande(commande, montant);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
