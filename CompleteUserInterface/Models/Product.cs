﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteUserInterface.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public float Price { get; set; }

    }
}
