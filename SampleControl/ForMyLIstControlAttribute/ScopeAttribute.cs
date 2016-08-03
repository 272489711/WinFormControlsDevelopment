using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleControl
{
    /// <summary>
    /// 该属性类作为演示复杂控件属性
    /// </summary>
    public class ScopeAttribute
    {
        private Int32 _min;
        private Int32 _max;

        public ScopeAttribute()
        { }
        public ScopeAttribute(Int32 min,Int32 max)
        {
            _min = min;
            _max = max;
        }
        public Int32 Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;

            }
        }
        public Int32 Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
        


    }
}
