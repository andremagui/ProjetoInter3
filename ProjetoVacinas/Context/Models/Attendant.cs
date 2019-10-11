using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVacinas.Context.Models
{
    public class Attendant
    {
        public int AttendantID { get; set; }
        public string AttendantName { get; set; }
        public string AttendantCPF { get; set; }
        public string AttendantEmail { get; set; }
        public string AttendantPass { get; set; }
        public int UbsID { get; set; }

    }
}
