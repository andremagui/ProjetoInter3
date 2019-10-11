using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Models
{
    public class CreateViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserCpf { get; set; }
        public string UserEmail { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}
