using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinRecyclerTest
{
    [Activity(Label = "Xamarin Application", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private RecyclerView recyclerView;
        private Button button;

        private RecyclerView.LayoutManager mlayoutManager;
        private PostAdapter postAdapter;

        JsonValue json;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.posts_view);
            mlayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mlayoutManager);
            button = FindViewById<Button>(Resource.Id.fetch_json);



            button.Click += async (sender, e) => {

                string url = "http://jsonplaceholder.typicode.com/posts";
                
                json = await FetchPostsAsync(url);
                PostList postList;
                postList = new PostList(JsonConvert.DeserializeObject<List<Post>>(json.ToString()));
                postAdapter = new PostAdapter(postList);
                recyclerView.SetAdapter(postAdapter);

            };


        }

        private async Task<JsonValue> FetchPostsAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonValue = await Task.Run(() => JsonValue.Load(stream));
                    return jsonValue;
                }
            }
        } 
    }
}

