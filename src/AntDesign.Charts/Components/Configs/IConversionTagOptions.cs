using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
   public  interface IConversionTagOptions
    {
        public bool? visible { get; set; }
        public int? size { get; set; }
        public int? spacing { get; set; }
        public int? offset { get; set; }
        public ArrowOptions arrow { get; set; }
        public ValueOptions value { get; set; }
        public object animation { get; set; }//any
        public bool? transpose { get; set; }
    }

    public class ConversionTagOptions : IConversionTagOptions
    {
        public bool? visible { get;set; }
        public int? size { get;set; }
        public int? spacing { get;set; }
        public int? offset { get;set; }
        public ArrowOptions arrow { get;set; }
        public ValueOptions value { get;set; }
        public object animation { get;set; }
        public bool? transpose { get;set; }
    }
}
