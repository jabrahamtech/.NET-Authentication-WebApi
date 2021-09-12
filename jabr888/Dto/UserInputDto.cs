﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888.Dto
{
    public class UserInputDto
    {
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
