using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Models
{
    public class Vaccine
    {
        public string VaccineName { get; set; }
        public int DependentID { get; set; }
        public int AttendantID { get; set; }
        public DateTime VaccineDate { get; set; }
    }
}
