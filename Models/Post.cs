using Dapper.Contrib.Extensions;

namespace blog.models
{
    [Table("[Post]")]

    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}