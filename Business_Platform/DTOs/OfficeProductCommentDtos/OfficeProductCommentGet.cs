namespace Business_Platform.DTOs.OfficeProductCommentDtos
{
    public class OfficeProductCommentGet
    {
        public int Id { get; set; }
        public long AppUserId { get; set; }
        public string? AppUserName { get; set; } 
        public string? Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int OfficeProdBranchProductId { get; set; }
        public string? OfficeProdBranchName { get; set;}
    }
}
