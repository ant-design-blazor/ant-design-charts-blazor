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
        
        public static async Task<GDPItem[]> GDPAsync(NavigationManager NavigationManager, HttpClient HttpClient)
        {
            var baseUrl = NavigationManager.ToAbsoluteUri(NavigationManager.BaseUri);
            return await HttpClient.GetFromJsonAsync<GDPItem[]>(new Uri(baseUrl, "_content/AntDesign.Charts.Docs/data/GDP.json").ToString());
        }

        public static async Task<GDPItem[]> EmissionsAsync(NavigationManager NavigationManager, HttpClient HttpClient)
        {
            var baseUrl = NavigationManager.ToAbsoluteUri(NavigationManager.BaseUri);
            return await HttpClient.GetFromJsonAsync<GDPItem[]>(new Uri(baseUrl, "_content/AntDesign.Charts.Docs/data/emissions.json").ToString());
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

    public class GDPItem
    {
        public string name { get; set; }
        public string year { get; set; }
        public decimal gdp { get; set; }
    }

    public class EmissionsItem
    {
        public string year { get; set; }
        public int value { get; set; }
        public string category { get; set; }
    }

}
