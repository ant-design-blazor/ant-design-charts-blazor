using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ICatAxis: IBaseAxis
    {
        public string type { get; set; }// 'cat'
    }

    public class CatAxis : ICatAxis
    {
        public string type { get;set; }
        public bool visible { get;set; }
        public string tickMethod { get;set; }
        public BaseAxisLine line { get;set; }
        public BaseAxisGrid grid { get;set; }
        public BaseAxisLabel label { get;set; }
        public BaseAxisTitle title { get;set; }
        public BaseAxisTickLine tickLine { get;set; }
    }
}
