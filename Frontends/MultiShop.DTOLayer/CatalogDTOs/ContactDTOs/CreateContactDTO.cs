﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
    }
}
