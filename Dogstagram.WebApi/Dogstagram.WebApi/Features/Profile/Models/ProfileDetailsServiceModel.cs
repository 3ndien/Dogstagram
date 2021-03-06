namespace Dogstagram.WebApi.Features.Profile.Models
{
    public class ProfileDetailsServiceModel
    {
        public ProfileDetailsServiceModel()
        {
            this.Posts = new HashSet<Data.Models.Post>();
        }

        public int FollowerCount { get; set; }

        public int FollowingCount { get; set; }

        public string? ShortName { get; set; }

        public string? PhotoUrl { get; set; }

        public ICollection<Data.Models.Post> Posts { get; set; }
    }
}
