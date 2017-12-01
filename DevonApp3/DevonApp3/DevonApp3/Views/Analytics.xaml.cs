using DevonApp3.ViewModels;
using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DevonApp3.Views
{
    public partial class Analytics : ContentPage
    {
        public Analytics()
        {
            InitializeComponent();

        }



        public class Point
        {
            [JsonProperty("Value")]
            public List<string> Value { get; set; }
            [JsonProperty("Timestamp")]
            public List<string> Timestamp { get; set; }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
            var service = new PIWebApiService();

            var results = await service.DownloadWebData("https://pi.dvnhackathon.com/piwebapi/streams/P0jyMYLmgLIU6nZDex9wsupAunECAAT1NJU09GVFBJLTAwMVxGUkFDLlVGTDo6U0tJRCAjNzcuR0VMX0JSRUFLRVJfQUNUSVZF/recorded?starttime=*-30d&endtime=*");
            Point result = JsonConvert.DeserializeObject<Point>(results);

            //strvaluepoint.Text = result.Value;
            //strtimestamp.Text = result.Timestamp;

            //BindingContext = result.Value;

        }


    }
}