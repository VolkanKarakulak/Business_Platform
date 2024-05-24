namespace Business_Platform.DTOs.RestaurantBranchComment
{
    public class RestaurantBranchCommentGet
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = "";
        public string Comment { get; set; } = "";
        public DateTime CommentDate { get; set; }
        public int RestaurantBranchId { get; set; }
        public string RestaurantBranchName { get; set; } = "";   
    }
}
