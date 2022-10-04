using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EuroDonet.Model.Societe;

using EuroDonet.ApiCall;
using System.Text;
using Newtonsoft.Json;
using EuroDonet.Model.Adresse;
using EURODONET_WEB_NET6.BusinessRules;
using Microsoft.AspNetCore.Mvc.Rendering;
using EuroDonet.Model.Societe;




// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-###
// ####                                -- Validation State --                                    ### 
// ####     Important: En .Net 6, il faut maintenant indiquer "[ValidateNever]" pour les ...     ### 
// ####     ...propriétés d'un modèle de vue  que l'on ne souhaite pas soumettre...              ### 
// ####     ... au contrôle de validation.                                                       ###                        
// ####  https://docs.microsoft.com/fr-fr/aspnet/core/mvc/models/validation?view=aspnetcore-6.0  ###
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-####

#region controller 

namespace EURODONET_WEB_NET6.Controllers
{
    public class SocieteController : Controller
    {

        #region Public Method

        // GET: SocieteController
        public ActionResult Index()
        {
            return View();
        }

        // > = = = = = = = = = = = = = = = = =<
        //  L I S T E    S O C I E T E S 
        //  ( Liste des sociétés  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpGet]
        public async Task<ActionResult> SocietesList()
        {
            // > On déclare un objet que l'on va envoyé à la vue <
            var ObjListSocieteVM = new ML_DonetSocieteListVM();

            var ObjListSocieteAPI = new ML_API_Vers_DonetSocieteList();


            // > On déclare la chaine contenant l'URL pour appeler l'aPI <
            // string url = ""xxxxxxxxxxxxxxxx/Api/GetListSocietes";

            string url = "https://localhost:44394/Api/GetListSocietes";

            // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
            var ObjApiCallProcess = new ApicallProcess();




            // > On lance l'appel de l'api pour récupérer la liste des sociétés <
            //    ( on appelle la méthode "GetListSocietes" )
            //    ( La méthode renvoie une liste de sociétés )
            ObjListSocieteAPI = await ObjApiCallProcess.GetListSocietesAsync(url);

            foreach (ML_API_Vers_DonetSociete item in ObjListSocieteAPI.ListSocietes)
            {
                ObjListSocieteVM.ListSocietes.Add(item);
            }


            // > On affiche la liste des sociétés <
            return View(ObjListSocieteVM);

        }


        // > = = = = = = = = = = = = = = = = =<
        //  A f f i c h e      S O C I E T E 
        //  ( Afficher une société  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpGet]
        public async Task<ActionResult> SocieteGet(string _IDSociete)
        {

            // > On déclare un objet que l'on va envoyé à la vue <
            var Soc = new ML_API_Vers_DonetSociete();

            // *** On teste l'ID différent de null *** 
            // -> En effet, lorsque l'utilisateur clique sur le bouton...
            //    ..."Ajouter unesociété", on affiche une page vide ....
            //    ...via l'action 'SocieteGet".
            if (_IDSociete != null)
            {

                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API --DEBUT-- #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // > On déclare la chaine contenant l'URL pour appeler l'API AZURE  <
                // Uri u = new Uri(""xxxxxxxxxxxxxxxx/Api/PostAdress/DonetAdresse");

                // > Pour debug : onindique l'adresse LOCALE d'exécution du service web <
                Uri u = new Uri("https://localhost:44394/Api/GetSociete/Values/?_IDSociete=" + _IDSociete);


                // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
                var ObjApiCallProcess = new ApicallProcess();

                // > Lance la tâche d'appel de l'API <
                // var t = Task.Run(() => ObjApiCallProcess.GetAdresseAsync(u.ToString()));
                //  t.Wait();

                Soc = await Task.Run(() => ObjApiCallProcess.GetSocieteAsync(u.ToString()));

                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API --FIN - #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                // > On déclare un objet que l'on va envoyé à la vue <
                //var ObjSocieteAjouteVM = new ML_DonetSocieteAjouteVM_INUTILE();

            }
            // > On déclare la chaine contenant l'URL pour appeler l'aPI <
            // string url = "xxxxxxxxxxxxxxxx/Api/GetDropDownListAdresse";

            string url = "https://localhost:44394/Api/GetDropDownListAdresse";

            // > Instancie un objet modèle qui va recevoir le résultat de l'appel <
            var Api_ddl = new ML_API_Vers_DonetAdresseDDList();

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-====
            // ###      Chargement liste Adresses D E B U T       ##  
            // ###   **** Chargement DrpDownList Société  ****    ##    
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-
            var v = new ApicallProcess();

            Api_ddl = await v.GetListAdressesDDLAsync(url);

            // > Chargement de la DropDownList <
            Soc.AdressList = new SelectList(Api_ddl.ListAdresseDropDownElement.ToList(),
         "Id_Adresse", "LibelleAdresse");
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===
            // ###   Chargement liste Adresses FIN         ##  
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===


            // > On affiche le détail de la fiche Société  <
            return View(Soc);

        }

        // > = = = = = = = = = = = = = = = = =<
        //  A j o u t e       S O C I E T E 
        //  ( Ajouter une société  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpPost]
        public async Task<ActionResult> SocietePost(ML_API_Vers_DonetSociete SocVM)
        {

            // > On reCharge "DropDownList" via le modèle de vue <
            //   ( Attention : Il faut renvoyer à la vue une autre instance....
            //     ...de "ImpProdAjouteVM" pour garder les données utilisateur <
            var NewObjMV = SocVM;


            // > On déclare la chaine contenant l'URL pour appeler l'aPI <
            // string url = ""xxxxxxxxxxxxxxxx/Api/GetDropDownListAdresse";

            string url = "https://localhost:44394/Api/GetDropDownListAdresse";

            // > Instancie un objet modèle qui va recevoir le résultat de l'appel <
            var Api_ddl = new ML_API_Vers_DonetAdresseDDList();

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===
            // ###   Chargement liste Adresses D E B U T   ##  
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===
            var v = new ApicallProcess();

            Api_ddl = await v.GetListAdressesDDLAsync(url);

            // > Chargement de la DropDownList dans la vue image de  "ObjVMVM" <
            NewObjMV.AdressList = new SelectList(Api_ddl.ListAdresseDropDownElement.ToList(),
             "Id_Adresse", "LibelleAdresse");
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===
            // ###   Chargement liste Adresses FIN    ##  
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-===



            // > Si les contrôles de validation sont correctes<
            //   ( Contrôles effectués par les DataAnnotations )
            if (ModelState.IsValid)
            {
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####  Préparation de l'objet pour serialisation  #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                // > Crée un objet pour insertion en bese de données <
                //    ( Reçoit les informations de la vue )
                var ObjDonetSocieteDB = new ML_DonetSocieteDB();

                // > Raison sociale <
                ObjDonetSocieteDB.raisonSociale = SocVM.RaisonSociale;

                // > TVA Intra communautaire  <
                ObjDonetSocieteDB.numTVAIntra = SocVM.NumTVAIntra;

                // > N° SIREN  <
                ObjDonetSocieteDB.numSiren = SocVM.NumSiren;

                // > ID Société   <
                // ( Si enregistrement en modification <
                ObjDonetSocieteDB.id_Societe = SocVM.Id_Societe;

                // > Capital Social   <
                ObjDonetSocieteDB.CapitalSocial = SocVM.CapitalSocial;

                // > Chiffre affaire  <
                ObjDonetSocieteDB.ChiffreAffaire = SocVM.ChiffreAffaire;

                // > ID adresse sélectionnée de la société   <
                ObjDonetSocieteDB.FK_ID_Adresse = SocVM.FK_ID_Adresse;


                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API     #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // > On déclare la chaine contenant l'URL pour appeler l'API AZURE  <
                // Uri u = new Uri(""xxxxxxxxxxxxxxxx/Api/PostSociete/DonetSociete");

                // > Pour debug : onindique l'adresse LOCALE d'exécution du service web <
                Uri u = new Uri("https://localhost:44394/Api/PostSociete/Donet");

                // > On effectue la conversion JSon de l'objet contenant les données saisies <
                var json = JsonConvert.SerializeObject(ObjDonetSocieteDB);

                // > Prépare le contenu de la requête HTPP <
                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");

                // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
                var ObjApiCallProcess = new ApicallProcess();

                // > Lance la tâche d'appel de l'API <
                //   ( Rappel : il s'agit d'une méthode générique )
                var t = Task.Run(() => ObjApiCallProcess.PostActionAPIAsync(u, c));

                t.Wait();


                // > L'ajout de l'enregistrement est fait. <
                // > On appelle maintenant la liste des sociétes <
                return RedirectToAction("SocietesList");

            }

            // > Si echec du contrôle de validatioins ( par les annotations, on réaffiche la vue en cours )  < 
            // !!!!! Remarque : Pour le fonctionnement des annotations, il faut renvoyer la vue EN COURS !!!!!!
            return View(NewObjMV);
        }




        // GET: SocieteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocieteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocieteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocieteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocieteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocieteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocieteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    #endregion
}
#endregion