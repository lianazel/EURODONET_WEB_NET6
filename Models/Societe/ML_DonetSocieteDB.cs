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


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés
// #### - - - - - -

namespace EuroDonet.Model.Societe
{
    public class ML_DonetSocieteDB
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string id_Societe { get; set; }
       
        public string raisonSociale { get; set; }
       
        public int numSiren { get; set; }
       
        public decimal CapitalSocial { get; set; }
       
        public decimal ChiffreAffaire { get; set; }
        
        public string numTVAIntra { get; set; }

        [JsonIgnore]
        // > Servira à rendre le n° de facture unique  < 
        public int NumSociete { get; set; }

        // > Non Mappé en Base de données  < 
        //   ( On ne s'en sert que lorsque l'API reçoit les infos )
        [NotMapped]
        public string FK_ID_Adresse { get; set; }
    }

}
