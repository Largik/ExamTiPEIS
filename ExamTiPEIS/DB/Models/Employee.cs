﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTiPEIS.DB.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public string Category { get; set; }
    }
}
