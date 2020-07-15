using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IAnimation
    {
        public AnimationCfg appear { get; set; }
        public AnimationCfg enter { get; set; }
        public AnimationCfg update { get; set; }
        public AnimationCfg leave { get; set; }
        //  [field: string]: any;
    }

    public class AnimationCfg
    {
        /// <summary>
        ///  动画模式，延伸or缩放 
        /// </summary>
        public string type { get; set; }
        public int? duration { get; set; }
        public string easing { get; set; }
        public int? delay { get; set; }
        //callback?: (...args: any[]) => void;
        //[field: string]: any;


        public string animation { get; set; }//补充
    }

    public class Animation : IAnimation
    {
        public AnimationCfg appear { get; set; }
        public AnimationCfg enter { get; set; }
        public AnimationCfg update { get; set; }
        public AnimationCfg leave { get; set; }
    }
}
