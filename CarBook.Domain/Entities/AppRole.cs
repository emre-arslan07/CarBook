﻿using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class AppRole:BaseEntity
	{
        public string AppRoleName { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
