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

namespace  EuroDonet.Model.Adresse
{
    public class ML_DonetAdresseDB
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Id_Adresse { get; set; }

        public Nullable<int> NumVoie { get; set; }

        public string TypVoie { get; set; }

        public string Adresse_1 { get; set; }

        public string Adresse_2 { get; set; }

        public int CodePostal { get; set; }

        public string Region { get; set; }

        public string Pays { get; set; }

        public string LibelleAdresse { get; set; }
    }

}
