using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IStackedBarViewConfig : IBarViewConfig
    {
        public string stackField { get; set; }
    }
}
