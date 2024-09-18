using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CommentDTOs
{
    public class CreateCommentDTO
    {
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; } = "https://cdn-icons-png.flaticon.com/128/456/456212.png";
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public string ProductId { get; set; }
    }
}
