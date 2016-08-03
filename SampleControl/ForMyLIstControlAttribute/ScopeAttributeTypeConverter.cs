using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace SampleControl
{
    /// <summary>
    /// 作为控件mylistControl中Scope属性的转换器，使该属性能够在属性浏览器中编辑
    /// </summary>
    public class ScopeAttributeTypeConverter:TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String)) return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String)) return true;

            if(destinationType==typeof(InstanceDescriptor)) return true;

            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            String result = "";
            if(destinationType==typeof(String))
            {
                ScopeAttribute scope = value as ScopeAttribute;
                result = scope.Min.ToString() + "," + scope.Max.ToString();
                return result;
            }
            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(ScopeAttribute).GetConstructor(new Type[] { typeof(Int32), typeof(Int32) });
                ScopeAttribute scope = value as ScopeAttribute;
                return new InstanceDescriptor(ci, new object[] { scope.Min, scope.Max });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                String[] v = ((String)value).Split(',');
                if (v.GetLength(0) != 2)
                {
                    throw new ArgumentException("非法的参数格式");
                }
                ScopeAttribute csf = new ScopeAttribute();
                csf.Min = Convert.ToInt32(v[0]);
                csf.Max = Convert.ToInt32(v[1]);
                return csf;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {

            return TypeDescriptor.GetProperties(typeof(ScopeAttribute), attributes);
        }

    }
}
