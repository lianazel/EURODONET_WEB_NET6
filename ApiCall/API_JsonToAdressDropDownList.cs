using EURODONET_WEB_NET6.Interfaces;

// > Pour le tableau Json "JArray" <
using Newtonsoft.Json.Linq;
using EuroDonet.Model.Societe;

// > Pour [NotNullAttribute] <
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using EuroDonet.Model.Adresse;

//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=
//####        *****  Json Vers Liste d'adresses ******            ####
//####        ( Pour alimenter une DropDwnList  ou Combo )        ####
//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=


namespace EURODONET_WEB_NET6.ApiCall
{
    public class API_JsonToAdressDropDownList : IjsonVersList
    {

        private readonly JArray _jsonArrayResponse;

        // > Constructeur <
        public API_JsonToAdressDropDownList([NotNullAttribute] JArray jsonArrayResponse)
        {
            _jsonArrayResponse = jsonArrayResponse;
        }

        public ML_API_Vers_DonetAdresseDDList JsonVersList()
        {

            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjAdressDDList = new ML_API_Vers_DonetAdresseDDList();

            if (_jsonArrayResponse != null)
            {

                // > Déserialise les déonnées renvoyées pour générer une liste de d'ADRESSES <
                foreach (var item in _jsonArrayResponse)
                {
                    ML_API_Vers_DonetAdresseDDElement ObjAdressDDElement = JsonConvert.DeserializeObject<ML_API_Vers_DonetAdresseDDElement>(item.ToString());

                    ObjAdressDDList.ListAdresseDropDownElement.Add(ObjAdressDDElement);
                }

            }

            // > Retourne un objet de type "API_Vers_DonetAdresseDropDownList" <
            return ObjAdressDDList;

        }

    }
}