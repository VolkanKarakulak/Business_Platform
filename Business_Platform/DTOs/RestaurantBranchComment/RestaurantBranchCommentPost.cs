namespace Business_Platform.DTOs.RestaurantBranchComment
{
    public class RestaurantBranchCommentPost
    {
        public long UserId { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CommentDate { get; set; }
        public int RestaurantBranchId { get; set; }
    }
}
