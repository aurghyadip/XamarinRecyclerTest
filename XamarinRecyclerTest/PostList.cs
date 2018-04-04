using System.Collections.Generic;

namespace XamarinRecyclerTest
{
    class PostList
    {
        public List<Post> posts { get; set; }
        public PostList(List<Post> posts)
        {
            this.posts = posts;
        }
    }
}