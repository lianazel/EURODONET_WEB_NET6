// #####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=
// #####      ---  Reception Liste des sociétes      ----                                ####
// #####  Remarque : cette classe est identique à "DonetSocieteListVM"                   ####
// #####  L'objectif est d'identifier les données renvoyées par les API (cohérence)      #### 
// #####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=

using EuroDonet.Model.Societe;

namespace EuroDonet.Model.Societe
{
    public class ML_API_Vers_DonetSocieteList
    {

        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la listedes sociétés  <
        public List<ML_API_Vers_DonetSociete> ListSocietes { get; set; }


        #endregion


        #region public methods
        public ML_API_Vers_DonetSocieteList()
        {
            ListSocietes = new List<ML_API_Vers_DonetSociete>();

        }

        #endregion


    }
}
