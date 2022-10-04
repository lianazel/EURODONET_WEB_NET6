using System;
using System.Collections.Generic;

using System.Linq;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// > Pour "[NotMapped]" <
using System.ComponentModel.DataAnnotations.Schema;

// > Gestion des data annotations <
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données l'affichage dans la VUE  ----
// ####                  Vue Detail ( Ajout / affichage / suppression )  
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés
// #### - - - - - - - - - - - - - - -
namespace  EuroDonet.Model.Adresse
{
    public class ML_DonetAdresseeAjouteVM_INUTILE
    {
        // > Exclu de la validation <
        [ValidateNever]
        public long Id { get; set; }

        // > Exclu de la validation <
        [ValidateNever]
        public string Id_Adresse { get; set; }

        // > Numéro de voie     <
        [Display(Name = "Numéro de voie")]
        public int NumVoie { get; set; }

        // > Type de voie   <
         [Required(ErrorMessage = "Type de voie obligatoire")]
         [Display(Name = "Type de voie")]
         public string TypVoie { get; set; }

        // > Adresse 1    <
        [Required(ErrorMessage = "L'adresse 1 est obligatoire")]
        [Display(Name = "Adresse 1")]
        public string Adresse_1 { get; set; }

        // > Adresse 2    <
        // > Exclu de la validation <
        [ValidateNever]
        [Display(Name = "Adresse 2")]
        public string Adresse_2 { get; set; }

        // > Code postal   <
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [Range(1, 99999, ErrorMessage = "Le code postal doit être différent de 0")]
        [Display(Name = "Code postal")]
        public int CodePostal { get; set; }


        // > code région   <
        [Required(ErrorMessage = "La région est obligatoire")]
        [Display(Name = "Région")]
        public string Region { get; set; }


        // > code pays    <
        [Required(ErrorMessage = "Le pays est obligatoire")]
        [Display(Name = "Pays")]
        public string Pays { get; set; }


        // > Libellé adresse     <
        [Required(ErrorMessage = "Le libellé de desciption est obligatoire")]
        [Display(Name = "Libellé descriptif")]
        public string LibelleAdresse { get; set; }


        // > Exclu de la validation <
        [ValidateNever]
        public string MsgeErrorException { get; set; }
    }

}
