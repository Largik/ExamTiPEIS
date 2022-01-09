using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTiPEIS.DB.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime DateBorn { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
    }
}
