using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Context.Models
{
    public class Dependent
    {
        public int DependentID { get; set; }
        public string DependentName { get; set; }
        public DateTime DependentBirth { get; set; }
        public string DependentBlood { get; set; }
        public string DependentAllergy { get; set; }
        public string DependentSusNo { get; set; }
        public List<Vaccine> Vaccines { get; set; }
    }
}
