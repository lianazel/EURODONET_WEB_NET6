using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Gestion des data annotations <
using System.ComponentModel.DataAnnotations;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données l'affichage dans la VUE  ----
// ####                  Vue Liste des socxiétés  
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

namespace  EuroDonet.Model.Adresse
{
    public class ML_DonetAdresseListVM
    {

        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la liste des Adresses  <
        public List<ML_API_Vers_DonetAdresse> ListAdresses { get; set; }


        #endregion


        #region public methods
        public ML_DonetAdresseListVM()
        {
            ListAdresses = new List<ML_API_Vers_DonetAdresse>();

        }

        #endregion
    }

}

