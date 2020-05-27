using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_tutorial11.Entities
{
    public class Medicament
    {
        public int IdMedicament { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public String Type { set; get; }

        public ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }
    }
}
