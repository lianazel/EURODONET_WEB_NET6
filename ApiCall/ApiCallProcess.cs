using System;
using System.Collections.Generic;
using System.Linq;


// > Pour "Encoding<
using System.Text;
using System.Threading.Tasks;
using EuroDonet.Model.Adresse;
using EuroDonet.Model.Societe;
using Newtonsoft.Json;

// > Pour le tableau Json "JArray" <
using Newtonsoft.Json.Linq;
using RestSharp;

using EURODONET_WEB_NET6.ApiCall;
using EuroDonet.Model.Societe;


// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####               --  Lien doc appeler API depui .Net appli --                       ### 
// ####   https://beanyovertech.com/appeler-une-api-externe-grace-a-httpclient-en-net/   ###
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=



namespace EuroDonet.ApiCall
{
    public class  ApicallProcess
    {
        #region properties 

        // ### =-=-=-=-=-=-=-=-=-=-=-= ###
        // ###    Déclaration membres  ###
        // ### =-=-=-=-=-=-=-=-=-=-=-= ###
        // > Membre de type "HttpClient" 
        HttpClient client = new HttpClient();

        // > Chaine Json pour sérialisation/déserialisation <
        string json;

        #endregion

        #region Public Methods 

        // ### =-=-=-=-=-=-=-=-=-=-=-= ###
        // ###    Constructeur         ###
        // ### =-=-=-=-=-=-=-=-=-=-=-= ###
        public ApicallProcess()
        {

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
        // ### Appelle l'API et retourne une adresse  ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
        public async Task<ML_API_Vers_DonetAdresse> GetAdresseAsync(string url)
        {
            // > Réception au format Json <
            string json = null;

            // > Objet contenant la liste à alimenter <
            //var ObjAdresseListVM = new DonetAdresseListVM();
                       
            try
            {

                // > === Appel de l'API pour récupérer UNE ADRESSE === <
                HttpResponseMessage response = client.GetAsync(url).Result;

                //  >  [ Si erreur détectée => génère une exception ] <
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                // > === On récupère le flot Json renvoyé par L'API  === <
                json = response.Content.ReadAsStringAsync().Result;

            }

            catch (Exception E)
            {
                string error = E.Message;
            }

            finally
            {

            }

            // > Deserialisation <           
            ML_API_Vers_DonetAdresse Adr = JsonConvert.DeserializeObject<ML_API_Vers_DonetAdresse>(json);
                      

            // > On retourne à l'appelant L'enregistrement Adresse <
            // return ObjAdresseListVM;
            return Adr;
        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        // ### Appelle l'API et retourne la liste des adresses  ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public async Task<ML_API_Vers_DonetAdressList> GetListAdressesAsync(string url)
        {

            // > Réception au format Json <
            string json = null;

            // > Objet contenant la liste à alimenter <
            //var ObjAdresseListVM = new DonetAdresseListVM();

            // > Déclare un tableau Json "Jarray"
            JArray jsonArrayResponse;
            jsonArrayResponse = null;

            try
            {

                // > === Appel de l'API pour récupérer la liste des ADRESSES === <
                HttpResponseMessage response = client.GetAsync(url).Result;

                //  >  [ Si erreur détectée => génère une exception ] <
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                // > === On récupère le flot Json renvoyé par L'API  === <
                json = response.Content.ReadAsStringAsync().Result;

            }

            catch (Exception E)
            {
                string error = E.Message;
            }

            finally
            {

            }

            try
            {
                // > Découpe le flot Json dans le tableau  "jsonArrayResponse" <
                jsonArrayResponse = JArray.Parse(json);
            }

            catch (Exception A)
            {
                string Error;
                Error = A.Message;
            }


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // ###              Déserialisation de la liste des Adresses          ####
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjAdressList = new ML_API_Vers_DonetAdressList();
            var OApiToJson = new API_JsonToAdressList(jsonArrayResponse);
            ObjAdressList = OApiToJson.JsonVersList();


            // > On retourne à l'appelant la liste des adresses <
            // return ObjAdresseListVM;
            return ObjAdressList;

        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-= 
        // ###                 ****  DropDownList (DDL) *****                 ###
        // ###  l'API retourne la liste des adresses pour alimenter une DDL   ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public async Task<ML_API_Vers_DonetAdresseDDList> GetListAdressesDDLAsync(string url)

        {
            // > Réception au format Json <
            string json = null;


            // > Déclare un tableau Json "Jarray"
            JArray jsonArrayResponse;
            jsonArrayResponse = null;

            try
            {
                // > === Appel de l'API pour récupérer la liste des ADRESSES === <
                HttpResponseMessage response = client.GetAsync(url).Result;

                //  >  [ Si erreur détectée => génère une exception ] <
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                // > === On récupère le flot Json renvoyé par L'API  === <
                json = response.Content.ReadAsStringAsync().Result;

            }

            catch (Exception E)
            {
                string error = E.Message;
            }

            finally
            {

            }

            try
            {
                // > Découpe le flot Json dans le tableau  "jsonArrayResponse" <
                jsonArrayResponse = JArray.Parse(json);
            }

            catch (Exception A)
            {
                string Error;
                Error = A.Message;
            }


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // ###              Déserialisation de la liste (DDL)                  ####
            // ### Contient liste Adresses avec deux colonnes : ID & LibelleAdress ####
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjAdressListDDL = new ML_API_Vers_DonetAdresseDDList();
            var OApiToJson = new API_JsonToAdressDropDownList(jsonArrayResponse);
            ObjAdressListDDL = OApiToJson.JsonVersList();


            // > On retourne à l'appelant la liste des adresses <
            // return ObjAdresseListVM;
            return ObjAdressListDDL;

        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
        // ### Appelle l'API et retourne une societe  ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
        public async Task<ML_API_Vers_DonetSociete> GetSocieteAsync(string url)
        {
            // > Réception au format Json <
            //   ( Force à Null par défaut => si on a reçu, sera toujours...
            //     ... à null )
            string json = null;
            
            try
            {

                // > === Appel de l'API pour récupérer UNE SOCIETE === <
                HttpResponseMessage response = client.GetAsync(url).Result;

                //  >  [ Si erreur détectée => génère une exception ] <
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                // > === On récupère le flot Json renvoyé par L'API  === <
                json = response.Content.ReadAsStringAsync().Result;

            }

            catch (Exception E)
            {
                string error = E.Message;
            }

            finally
            {

            }

            // > Deserialisation <           
            ML_API_Vers_DonetSociete Soc = JsonConvert.DeserializeObject<ML_API_Vers_DonetSociete>(json);


            // > On retourne à l'appelant L'enregistrement Societe <
            // return ObjAdresseListVM;
            return Soc;
        }



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        // ### Appelle l'API et retourne la liste des sociétés ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public async Task<ML_API_Vers_DonetSocieteList> GetListSocietesAsync(string url)
        {

            // > Réception au format Json <
            string json = null;


            // > Déclare un tableau Json "Jarray"
            JArray jsonArrayResponse;
            jsonArrayResponse = null;

            try
            {

                // > === Appel de l'API pour récupérer la liste des SOCIETES  === <
                HttpResponseMessage response = client.GetAsync(url).Result;

                //  >  [ Si erreur détectée => génère une exception ] <
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                // > === On récupère le flot Json renvoyé par L'API  === <
                json = response.Content.ReadAsStringAsync().Result;

            }

            catch (Exception E)
            {
                string error = E.Message;
            }

            finally
            {

            }

            try
            {
                // > Découpe le flot Json dans le tableau  "jsonArrayResponse" <
                jsonArrayResponse = JArray.Parse(json);
            }

            catch (Exception A)
            {
                string Error;
                Error = A.Message;
            }


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // ###              Déserialisation de la liste des Societes          ####
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // > On instncie un objet pour récuoérer les objets désérialises <
            var ObjSocieteList = new ML_API_Vers_DonetSocieteList();
            var OApiToJson = new API_JsonToSocieteList(jsonArrayResponse);
            ObjSocieteList = OApiToJson.JsonVersList();
            

            // > On retourne à l'appelant la liste des sociétées <
            return ObjSocieteList;

        }



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        // ###     Appelle l'API et crée/met à jourun enregistrement  ###
        // ###                ( Méthode générique )                   ###
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public async Task<string> PostActionAPIAsync(Uri u, HttpContent c)
        {

            // > Voir lien  : 
            // https://www.codegrepper.com/code-examples/csharp/httpclient+post+request+with+parameters+c%23
            // https://www.c-sharpcorner.com/UploadFile/dacca2/http-request-methods-get-post-put-and-delete/
            // https://stackoverflow.com/questions/50458507/c-sharp-web-api-sending-body-data-in-http-post-rest-client

            // https://carldesouza.com/httpclient-getasync-postasync-sendasync-c/

            {

                // > Initialise la variable "response" avec des "" <
                var response = string.Empty;
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        // > Adresse  Action API <
                        RequestUri = u,
                        // > Données au format Json à insérer/Mettre à jour 
                        Content = c
                    };

                    // > Envoie de la demande <
                    HttpResponseMessage result = await client.SendAsync(request);
                    // > Si réponse OK ==> on récupère la réponse <
                    //   ( sinon, on renvoie une réponse avec du "" ) 
                    if (result.IsSuccessStatusCode)
                    {
                        response = result.StatusCode.ToString();

                    }
                }
                return response;

            }

        }


    }
    #endregion 

}