namespace DrakeShop.Comment.Entities
{
    public class UserComment
    {
        public int UserCommentId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
