﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.TokenDTO
{
    public class ResultJwtReponseDTO
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
