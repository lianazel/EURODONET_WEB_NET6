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


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour Lecture/Ecriture depuis/vers  en Base de données  ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés
// #### - - - - - - - - - - - - - -

namespace EuroDonet.Model.Societe
{
    public class ML_API_Vers_DonetSociete_SAV
    {
        public string id_Societe { get; set; }
       
        public string raisonSociale { get; set; }
       
        public int numSiren { get; set; }
       
        public decimal CapitalSocial { get; set; }
       
        public decimal ChiffreAffaire { get; set; }
        
        public string numTVAIntra { get; set; }

       public string fK_ID_Adresse { get; set; }
    }

}
