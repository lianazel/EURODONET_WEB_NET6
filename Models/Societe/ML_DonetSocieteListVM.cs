using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Gestion des data annotations <
using System.ComponentModel.DataAnnotations;

// > Pour accéder au modèle de données <
using EuroDonet.Model.Societe;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données l'affichage dans la VUE  ----
// ####                  Vue Liste des socxiétés  
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

namespace EuroDonet.Model.Societe
{
    public class ML_DonetSocieteListVM
    {

        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la listedes sociétés  <
        public List<ML_API_Vers_DonetSociete> ListSocietes { get; set; }


        #endregion


        #region public methods
        public ML_DonetSocieteListVM()
        {
            ListSocietes = new List<ML_API_Vers_DonetSociete>();

        }

        #endregion
    }

}

