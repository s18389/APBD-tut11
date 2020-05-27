using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_tutorial11.Entities
{
    public class Prescription_Medicament
    {
        public int IdMedicament { set; get; }
        public virtual Medicament Medicament { get; set; }
        public int IdPrescription { set; get; }
        public virtual Prescription Prescription { get; set; }
        public int Dose { set; get; }
        public String Details { set; get; }

    }
}
