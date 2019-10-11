using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Models
{
    public class Dependent
    {
        public string DependentName { get; set; }
        public DateTime DependentBirth { get; set; }
        public string DependentBlood { get; set; }
        public string DependentAllergy { get; set; }
        public string DependentSusNo { get; set; }
    }
}
