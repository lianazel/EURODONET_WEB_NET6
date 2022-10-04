using EuroDonet.Model.Adresse;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour Récupéré une liste de ligne de DropDownList ----
// ####                  Rappel : DropDownList est une combo 
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Adresses  ( lignes de dropdownlist ) 
// #### - - - - - - - - - - - - - - -

// ***** ML_API_Vers_DonetAdresseDDList : ML pour "Modèle de données" ******

namespace EuroDonet.Model.Adresse
{
    public class ML_API_Vers_DonetAdresseDDList
    {
        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la liste des lignes de la combo   <
        public List<ML_API_Vers_DonetAdresseDDElement> ListAdresseDropDownElement { get; set; }


        #endregion


        #region public methods
        public ML_API_Vers_DonetAdresseDDList()
        {
            ListAdresseDropDownElement = new List<ML_API_Vers_DonetAdresseDDElement>();

        }

        #endregion

    }
}
