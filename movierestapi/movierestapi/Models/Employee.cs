using System;
using System.Collections.Generic;

#nullable disable

namespace movierestapi.Models
{
    public partial class Employee
    {
        public int Employeid { get; set; }
        public string Name { get; set; }
        public int? Managerid { get; set; }
    }
}
