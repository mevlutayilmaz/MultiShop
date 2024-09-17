namespace MultiShop.Comment.DTOs
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
