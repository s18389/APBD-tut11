using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_tutorial11.Entities
{
    public class Patient
    {

        public int IdPatient { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public DateTime Birthdate { set; get; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
