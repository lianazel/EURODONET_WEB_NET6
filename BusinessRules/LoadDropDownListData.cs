using EuroDonet.ApiCall;
using EuroDonet.Model.Adresse;
using EuroDonet.Model.Societe;
using EURODONET_WEB_NET6.Models.Adresse;
using Microsoft.AspNetCore.Mvc;

namespace EURODONET_WEB_NET6.BusinessRules
{
    public class LoadDropDownListData
    {

        // > Constructeur <
        public LoadDropDownListData()
        {

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        //     - - - - - Liste des Adresses - - - - -
        //     > On alimente la liste du modèle envoyé à la vue <
        //         ( Cette liste va remplir la dropdownlist ) 
        //              "DDL ==> DropDownList "   
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ( On renvoie un envoie de classe " DonetSocieteAjouteVM " )
        public async Task<ML_API_Vers_DonetAdresseDDList>  LoadAdressDDL()
        {
                       
            var ObjListAdressAPI = new ML_API_Vers_DonetAdresseDDList();

            // > On déclare la chaine contenant l'URL pour appeler l'aPI <
            // string url = "https://donetapi.azurewebsites.net/Api/GetDropDownListAdresse";

            string url = "https://localhost:44394/Api/GetDropDownListAdresse";

            // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
            var ObjApiCallProcess = new ApicallProcess();
                      

            // > On lance l'appel de l'api pour récupérer la liste des sociétés <
            //    ( on appelle la méthode "GetListAdresses" )
            //    ( La méthode renvoie une liste de adressess )
            ObjListAdressAPI = await ObjApiCallProcess.GetListAdressesDDLAsync(url);
                        

            return ObjListAdressAPI;
        }
    }
}