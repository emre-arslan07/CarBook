﻿using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public ICollection<RentACarProcess> RentACarProcesses { get; set; }
    }
}
