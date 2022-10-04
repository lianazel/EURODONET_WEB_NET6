using EURODONET_WEB_NET6.Interfaces;

// > Pour le tableau Json "JArray" <
using Newtonsoft.Json.Linq;
using EuroDonet.Model.Societe;

// > Pour [NotNullAttribute] <
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using EuroDonet.Model.Adresse;

//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//####        *****  Json Vers Liste d'adresses ******   ####
//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


namespace EURODONET_WEB_NET6.ApiCall
{
    public class API_JsonToAdressList : IjsonVersList
    {

        private readonly JArray _jsonArrayResponse;

        // > Constructeur <
        public API_JsonToAdressList([NotNullAttribute] JArray jsonArrayResponse)
        {
            _jsonArrayResponse = jsonArrayResponse;
        }

        public ML_API_Vers_DonetAdressList JsonVersList()
        {

            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjAdressList = new ML_API_Vers_DonetAdressList();

            if (_jsonArrayResponse != null)
            {

                // > Déserialise les déonnées renvoyées pour générer une liste de d'ADRESSES <
                foreach (var item in _jsonArrayResponse)
                {
                    ML_API_Vers_DonetAdresse ObjAdressElement = JsonConvert.DeserializeObject<ML_API_Vers_DonetAdresse>(item.ToString());

                    ObjAdressList.ListAdresses.Add(ObjAdressElement);
                }

            }

            // > Retourne un objet de type "API_Vers_DonetSocieteList" <
            return ObjAdressList;

        }

    }
}
