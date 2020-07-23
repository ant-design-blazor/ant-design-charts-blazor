using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IStackedBarViewConfig : IBarViewConfig
    {
[JsonPropertyName("stackField")]
public string StackField { get; set; }
    }
}


