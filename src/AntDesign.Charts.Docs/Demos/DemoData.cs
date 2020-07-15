using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntDesign.Charts.Docs.Demos
{
    public static class DemoData
    {
        public static async Task<FireworksSalesItem[]> FireworksSalesAsync(NavigationManager NavigationManager, HttpClient HttpClient)
        {
            var baseUrl = NavigationManager.ToAbsoluteUri(NavigationManager.BaseUri);
            return await HttpClient.GetFromJsonAsync<FireworksSalesItem[]>(new Uri(baseUrl, "_content/AntDesign.Charts.Docs/data/fireworks-sales.json").ToString());
        }

        public static async Task<SalesItem[]> SalesAsync(NavigationManager NavigationManager, HttpClient HttpClient)
        {
            var baseUrl = NavigationManager.ToAbsoluteUri(NavigationManager.BaseUri);
            return await HttpClient.GetFromJsonAsync<SalesItem[]>(new Uri(baseUrl, "_content/AntDesign.Charts.Docs/data/sales.json").ToString());
        }
    }

    public class FireworksSalesItem
    {
        [JsonPropertyName("Date")]
        public string Date { get; set; }
        public int scales { get; set; }
    }

    public class SalesItem
    {

        public string 城市 { get; set; }
        public decimal 销售额 { get; set; }
    }

}
