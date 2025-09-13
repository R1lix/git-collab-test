﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAcces.Entities
{
    public class BookEntity
    {
        public Guid id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal price { get; set; }

        public BookEntity() 
        {

        }
    }
}
