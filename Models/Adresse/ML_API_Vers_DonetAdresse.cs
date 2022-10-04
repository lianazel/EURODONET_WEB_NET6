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

// > Pour les annotations <
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés ( Enregistrement ) 
// #### - - - - - - - - - - - - - - -

namespace EuroDonet.Model.Adresse
{
    public class ML_API_Vers_DonetAdresse
    {
        [JsonIgnore]
        [ValidateNever]
        public long Id { get; set; }

        [ValidateNever]
        public string Id_Adresse { get; set; }

        [Display(Name = "Numéro de voie")]
        public Nullable<int> NumVoie { get; set; }

        [Required(ErrorMessage = "Type de voie obligatoire")]
        [Display(Name = "Type de voie")]
        public string TypVoie { get; set; }

        [Required(ErrorMessage = "L'adresse 1 est obligatoire")]
        [Display(Name = "Adresse 1")]
        public string Adresse_1 { get; set; }

        [ValidateNever]
        public string Adresse_2 { get; set; }

        // > Code postal   <
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [Range(1, 99999, ErrorMessage = "Le code postal doit être différent de 0")]
        [Display(Name = "Code postal")]
        public int CodePostal { get; set; }

        [Required(ErrorMessage = "La région est obligatoire")]
        [Display(Name = "Région")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Le pays est obligatoire")]
        [Display(Name = "Pays")]
        public string Pays { get; set; }

        // > Libellé adresse     <
        [Required(ErrorMessage = "Le libellé de desciption est obligatoire")]
        [Display(Name = "Libellé descriptif")]
        public string LibelleAdresse { get; set; }

        [ValidateNever]
        public string MsgeErrorException { get; set; }
    }

}
