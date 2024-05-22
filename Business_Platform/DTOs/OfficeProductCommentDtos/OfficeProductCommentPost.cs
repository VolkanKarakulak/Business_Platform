using Business_Platform.Model.Office;

namespace Business_Platform.DTOs.OfficeProductCommentDtos
{
    public class OfficeProductCommentPost
    {
        public long AppUserId { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CommentDate { get; set; }
        public int OfficeProdBranchProductId { get; set;}
    }
}
