using EURODONET_WEB_NET6.Interfaces;

using EuroDonet.Model.Societe;
using Newtonsoft.Json;

// > Pour le tableau Json "JArray" <
using Newtonsoft.Json.Linq;
using EuroDonet.Model.Societe;

// > Pour [NotNullAttribute] <
using System.Diagnostics.CodeAnalysis;

//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//####        *****  Json Vers Liste de sociétés  ******   ####
//####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


namespace EURODONET_WEB_NET6.ApiCall
{
    public class API_JsonToSocieteList : IjsonVersList
    {

        private readonly JArray _jsonArrayResponse;

        // > Constructeur <
        public API_JsonToSocieteList([NotNullAttribute] JArray jsonArrayResponse)
        {
            _jsonArrayResponse = jsonArrayResponse;
        }

        public ML_API_Vers_DonetSocieteList JsonVersList()
        {


            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjSocieteList = new ML_API_Vers_DonetSocieteList();

            if (_jsonArrayResponse != null)
            {

                // > Déserialise les déonnées renvoyées pour générer une liste de d'ADRESSES <
                foreach (var item in _jsonArrayResponse)
                {
                    ML_API_Vers_DonetSociete ObjSocieteElement = JsonConvert.DeserializeObject<ML_API_Vers_DonetSociete>(item.ToString());

                    ObjSocieteList.ListSocietes.Add(ObjSocieteElement);
                }

            }

            // > Retourne un objet de type "API_Vers_DonetSocieteList" <
            return ObjSocieteList;

        }

    }
}

