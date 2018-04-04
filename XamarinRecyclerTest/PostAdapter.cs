using System;
using System.Collections.Generic;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace XamarinRecyclerTest
{
    class PostAdapter : RecyclerView.Adapter
    {
        private List<Post> posts;

        public PostAdapter(List<Post> posts)
        {
            this.posts = posts;
        }

        public override int ItemCount { get => posts.Count; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PostViewHolder viewHolder = holder as PostViewHolder;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView, parent, false);
            PostViewHolder viewHolder = new PostViewHolder(itemView);
            return viewHolder;
        }


        public class PostViewHolder : RecyclerView.ViewHolder
        {

            private TextView userIdView;
            private TextView postIdView;
            private TextView postTitleView;
            private TextView postBodyView;

            public PostViewHolder(View itemView) : base(itemView)
            {
                userIdView = itemView.FindViewById<TextView>(Resource.Id.user_id_field);
                postIdView = itemView.FindViewById<TextView>(Resource.Id.post_id_field);
                postTitleView = itemView.FindViewById<TextView>(Resource.Id.post_title_field);
                postBodyView = itemView.FindViewById<TextView>(Resource.Id.post_body_field);
            }

            public void SetUserIdView(int userId)
            {
                userIdView.Text = userId.ToString();
            }

            public void SetPostIdView(int postId)
            {
                postIdView.Text = postId.ToString();
            }

            public void SetPostTitleView(string postTitle)
            {
                postTitleView.Text = postTitle;
            }

            public void SetPostBodyView(string postBody)
            {
                postBodyView.Text = postBody;
            }
        }
    }
}