using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EuroDonet.Model.Adresse;

using EuroDonet.ApiCall;
using System.Text;
using Newtonsoft.Json;

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ###     Remarque : Cette  solution remplace le projet .Net 5 => "EURODONET_MVC_WEB"      ###
// ###     ( J'avais un problème avec les classes Bootstrap sur l'ancienne solution )       ###
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####               --  Lien doc appeler API depui .Net appli --                       ### 
// ####   https://beanyovertech.com/appeler-une-api-externe-grace-a-httpclient-en-net/   ###
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-###
// ####                                -- Validation State --                                    ### 
// ####     Importan : En .Net 6, il faut maintenant indiquer "[ValidateNever]" pour les ...     ### 
// ####     ...propriétés d'un modèle de vue  que l'on ne souhaite pas soumettre...              ### 
// ####     ... au contrôle de validation.                                                       ###                        
// ####  https://docs.microsoft.com/fr-fr/aspnet/core/mvc/models/validation?view=aspnetcore-6.0  ###
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-####

#region controller 

namespace EURODONET_WEB_NET6.Controllers
{
    public class AdresseController : Controller
    {

        #region Public Method

        // GET: SocieteController
        public ActionResult Index()
        {
            return View();
        }

        // > = = = = = = = = = = = = = = = = =<
        //  L I S T E   A D R E S S S E S 
        //  ( Liste des sociétés  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpGet]
        public async Task<ActionResult> AdressesList()
        {
            // > On déclare un objet que l'on va envoyé à la vue <
            var ObjListAdresseVM = new ML_DonetAdresseListVM();

            var ObjListAdresseAPI = new ML_API_Vers_DonetAdressList();

            // > On déclare la chaine contenant l'URL pour appeler l'aPI <
            // string url = "https://donetapi.azurewebsites.net/Api/GetListAdresses";

            string url = "https://localhost:44394/Api/GetListAdresses";

            // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
            var ObjApiCallProcess = new ApicallProcess();

            // > On lance l'appel de l'api pour récupérer la liste des sociétés <
            //    ( on appelle la méthode "GetListSocietes" )
            //    ( La méthode renvoie une liste de sociétés )
            ObjListAdresseAPI = await ObjApiCallProcess.GetListAdressesAsync(url);

            foreach (ML_API_Vers_DonetAdresse item in ObjListAdresseAPI.ListAdresses)
            {
                ObjListAdresseVM.ListAdresses.Add(item);
            }


            // > On affiche la liste des sociétés <
            return View(ObjListAdresseVM);

        }


        // > = = = = = = = = = = = = = = = = =<
        //  A f f i c h e      A d r e s s e  
        //  ( Récupérer  une adresse  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpGet]
        public async Task<ActionResult> AdresseGet(string _IDAdresse)
        {
            // > On déclare un objet que l'on va envoyé à la vue <
            var Adr = new ML_API_Vers_DonetAdresse();

            // *** On teste l'ID différent de null *** 
            // -> En effet, lorsque l'utilisateur clique sur le bouton...
            //    ..."Ajouter une adresse", on affiche une page vide ....
            //    ...via l'action 'AdresseGet".
            if (_IDAdresse != null)
            {

                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API --DEBUT-- #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // > On déclare la chaine contenant l'URL pour appeler l'API AZURE  <
                // Uri u = new Uri("https://donetapi.azurewebsites.net/Api/PostAdress/DonetAdresse");

                // > Pour debug : onindique l'adresse LOCALE d'exécution du service web <
                Uri u = new Uri("https://localhost:44394/Api/GetAdress/Values/?_IDAdress=" + _IDAdresse);


                // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
                var ObjApiCallProcess = new ApicallProcess();

                // > Lance la tâche d'appel de l'API <
                // var t = Task.Run(() => ObjApiCallProcess.GetAdresseAsync(u.ToString()));
                //  t.Wait();

                Adr =  await Task.Run(() => ObjApiCallProcess.GetAdresseAsync(u.ToString()));

                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API --FIN - #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


            }


            // > On affiche une société <
            return View(Adr);
        }


        // > = = = = = = = = = = = = = = = = =<
        //  A j o u t e       A d r e s s e 
        //  ( Ajouter une adresse  )
        // > = = = = = = = = = = = = = = = = =<
        [HttpPost]
        public ActionResult AdressePost(ML_API_Vers_DonetAdresse AdrVM)
        {

            // > Si les contrôles de validation sont correctes<
            //   ( Contrôles effectués par les DataAnnotations )
            if (ModelState.IsValid)
            {
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####  Préparation de l'objet pour serialisation  #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                // > Crée un objet pour insertion en bese de données <
                //    ( Reçoit les informations de la vue )
                var ObjDonetAdresseeDB = new ML_DonetAdresseDB();

                // > Libellé adresse <
                ObjDonetAdresseeDB.LibelleAdresse = AdrVM.LibelleAdresse;

                // > Adresse 1 <
                ObjDonetAdresseeDB.Adresse_1 = AdrVM.Adresse_1;

                // > Adresse 2 <
                ObjDonetAdresseeDB.Adresse_2 = AdrVM.Adresse_2;

                // > Type de voie  <
                ObjDonetAdresseeDB.TypVoie = AdrVM.TypVoie;

                // > Numéro de Voie  <
                ObjDonetAdresseeDB.NumVoie = AdrVM.NumVoie;

                // > Code postal <
                ObjDonetAdresseeDB.CodePostal = AdrVM.CodePostal;

                // > Région <
                ObjDonetAdresseeDB.Region = AdrVM.Region;

                // > Pays <
                ObjDonetAdresseeDB.Pays = AdrVM.Pays;

                // > ID adresse  <
                ObjDonetAdresseeDB.Id_Adresse = AdrVM.Id_Adresse;


                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // #####       Préparation appel de l'API     #####
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                // > On déclare la chaine contenant l'URL pour appeler l'API AZURE  <
                // Uri u = new Uri("https://donetapi.azurewebsites.net/Api/PostAdress/DonetAdresse");

                // > Pour debug : onindique l'adresse LOCALE d'exécution du service web <
                Uri u = new Uri("https://localhost:44394/Api/PostAdress/DonetAdresse");

                // > On effectue la conversion JSon de l'objet contenant les données saisies <
                var json = JsonConvert.SerializeObject(ObjDonetAdresseeDB);

                // > Prépare le contenu de la requête HTPP <
                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");

                // > ON instancie un nouvek objet pour  accéder aux méthodes des procces API <
                var ObjApiCallProcess = new ApicallProcess();

                // > Lance la tâche d'appel de l'API <
                var t = Task.Run(() => ObjApiCallProcess.PostActionAPIAsync(u, c));

                t.Wait();


                // > On affiche la liste des adresses <
                return RedirectToAction("AdressesList");


            }

            // > Erreur détectée : On Affiche de nouveau la veu en cours avec les DATA's <
            return View(AdrVM);
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