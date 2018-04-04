using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System;
using System.IO;

namespace XamarinRecyclerTest
{
    [Activity(Label = "Xamarin Application", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager mlayoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            JsonValue jsonValue;
            mlayoutManager = new LinearLayoutManager(this);

            Button button = FindViewById<Button>(Resource.Id.fetch_json);

            button.Click += async (sender, e) => {

                // Get the latitude and longitude entered by the user and create a query.
                string url = "http://jsonplaceholder.typicode.com/posts";

                // Fetch the weather information asynchronously, 
                // parse the results, then update the screen:
                JsonValue json = await FetchPostsAsync(url);
                // ParseAndDisplay (json);
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
                    Console.Out.WriteLine(jsonValue.ToString());

                    return jsonValue;
                }
            }
        } 
    }
}

