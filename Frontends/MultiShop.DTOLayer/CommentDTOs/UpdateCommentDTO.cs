﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CommentDTOs
{
    public class UpdateCommentDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
