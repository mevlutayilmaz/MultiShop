﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }

    }
}
