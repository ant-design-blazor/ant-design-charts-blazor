﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Calendar<TItem> : ChartComponentBase<TItem, CalendarConfig>
    {
        public Calendar() : base("Calendar")
        {

        }
    }
}
