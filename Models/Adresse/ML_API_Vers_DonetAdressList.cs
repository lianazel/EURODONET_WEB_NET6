// #####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=
// #####      ---  Reception Liste des Adresses      ----                                ####
// #####  Remarque : cette classe est identique à "DonetAdresseListVM"                   ####
// #####  L'objectif est d'identifier les données renvoyées par les API (cohérence)      #### 
// #####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=

using EuroDonet.Model.Adresse;

namespace EuroDonet.Model.Adresse
{
    public class ML_API_Vers_DonetAdressList
    {

        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la liste des Adresses  <
        public List<ML_API_Vers_DonetAdresse> ListAdresses { get; set; }


        #endregion


        #region public methods
        // > Constructeur 
        public ML_API_Vers_DonetAdressList()
        {
            ListAdresses = new List<ML_API_Vers_DonetAdresse>();

        }

        #endregion

    }
}
