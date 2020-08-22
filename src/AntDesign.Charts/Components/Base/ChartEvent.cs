using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ChartEvent
    {
        public ChartEvent(IChartComponent sender, System.Text.Json.JsonElement data)
        {
            Sender = sender;
            Data = data;
        }

        public IChartComponent Sender { get; set; }

        public System.Text.Json.JsonElement Data { get; set; }
    }
}
