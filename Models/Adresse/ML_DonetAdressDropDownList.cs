using EuroDonet.Model.Adresse;

namespace EURODONET_WEB_NET6.Models.Adresse
{
    // > Cett classe contient les adresses renvoyée par l'API pour remplir la DropDownList "Adress" <
    //   ( Il y a une Drop DownList des adresses dans la fiche "Société". <

    public class ML_DonetAdressDropDownList
    {

        #region properties 

        //####-----------------------------------
        //####  ---  Déclaration des membres ----
        //####-----------------------------------
        // > Réception de la liste des Adresses  <
        public List<ML_API_Vers_DonetAdresse> DropDownListAdress { get; set; }


        #endregion


        #region public methods
        public ML_DonetAdressDropDownList()
        {
            DropDownListAdress = new List<ML_API_Vers_DonetAdresse>();

        }

        #endregion


    }
}
