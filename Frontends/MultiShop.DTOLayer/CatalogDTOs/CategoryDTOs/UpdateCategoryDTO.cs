using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? File { get; set; }

    }
}
