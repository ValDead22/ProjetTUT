using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Usager
{
    public interface IUsagerDataAccessLayer
    {
        List<Entity.Usager> GetAllUsagers();

        List<Entity.Usager> GetAllUsagersNonUtilisateur();

        Entity.Usager GetUsager(string matricule, string nom);

        List<string> GetAllMoyenDePaiements();

        void ModifyMoyenDePaiement(int matricule, string moyenDePaiement);
        

        Entity.Usager GetUsagerByMatriculeCarte(int matricule);

        float GetCardCredit(Entity.Usager usager);

        void SetCardCredit(Entity.Usager usager, float newCredit);
    }
}
