﻿using Library.Domain.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.InputModels.Books
{
    public class UpdateBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
