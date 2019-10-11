using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Context.Models
{
    public class Vaccine
    {
        public int VaccineID { get; set; }
        public string VaccineName { get; set; }
        public List<Dose> Doses { get; set; }
    }
}
