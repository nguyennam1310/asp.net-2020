﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class Faculty
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool isEdit { get; set; }
    }
}
