using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTiPEIS.DB.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateVisit { get; set; }
        public string Type { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public string Сomplaints { get; set; } //жалобы
        public string Diagnosis { get; set; }
        public string Prescribe { get; set; } //назначение лекарств
        public DateTime? DateRecovery { get; set; }
    }
}
