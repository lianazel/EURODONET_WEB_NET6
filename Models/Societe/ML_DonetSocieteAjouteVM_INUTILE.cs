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

// > Pour "SelectList" <
using Microsoft.AspNetCore.Mvc.Rendering;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données l'affichage dans la VUE  ----
// ####                  Vue Detail ( Ajout / affichage / suppression )  
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés
// #### - - - - - - - - - - - - - - -
namespace EuroDonet.Model.Societe
{
    public class ML_DonetSocieteAjouteVM_INUTILE
    {
        // > Exclu de la validation <
        [ValidateNever]
        public long Id { get; set; }

        // > Exclu de la validation <
        [ValidateNever]
        public string Id_Societe { get; set; }

        // > Raison sociale    <
        [Required(ErrorMessage = "La raison sociale est obligatoire")]
        [Display(Name = "Raison sociale")]
        public string RaisonSociale { get; set; }

        // > Numéro SIREN    <
        [Required(ErrorMessage = "Le SIREN est obligatoire")]
        [Range(1, 999999.00, ErrorMessage = "Le SIREN doit contenir 6 chiffres. ")]
        [Display(Name = "Numéro siren")]
         public int NumSiren { get; set; }

        // > Capital social    <
        [Required(ErrorMessage = "Le capital social est obligatoire")]
        [Display(Name = "Capital social")]
        public decimal CapitalSocial { get; set; }

        // > Chiffre affaire   <
        [Required(ErrorMessage = "Le chiffre d'affaire est obligatoire")]
        [Display(Name = "Chiffre d'affaire")]
         public decimal ChiffreAffaire { get; set; }

        // > Numéro TVA Intra Communautaire   <
        [Required(ErrorMessage = "Le NUMRO TVA intra communautaire est obligatoire")]
        [Display(Name = "Numéro TVA intra communautaire")]
        public string NumTVAIntra { get; set; }

        // > Exclu de la validation <
        [ValidateNever]
        // > Servira à rendre le n° de facture unique  < 
        public int NumSociete { get; set; }

        // > [NotMapped] ==> On dit que cette colonne n'est mappée...
        //   ...à aucune colonne de table.
        //   > Ici ne sert pas à grand chose étant donné qu'il s'agit...
        //     ...d'un modèle de vue <
        [ValidateNever]
        [NotMapped]
        public SelectList AdressList { get; set; }

        [Display(Name = "Choisir une adresse pour la société")]
        // > Récupération de la valeur sélectionnée dans la DropDownList <
        //   ( Approche via model ) 
        [Required(ErrorMessage = "L'adresse de la société est obligatoire")]
        public string AdressSelected { get; set; }

        // > Exclu de la validation <
        [ValidateNever]
        public string MsgeErrorException { get; set; }
    }

}
