﻿namespace MultiShop.Comment.DTOs
{
    public class CreateCommentDTO
    {
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public string ProductId { get; set; }
    }
}
