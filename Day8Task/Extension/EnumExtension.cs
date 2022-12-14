
using Day8Task.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace Day8Task.Extension
{
    public static class EnumExtensions
    {
        public static string GetDescriptionAttr(this Enum valuey)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(key);
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }
    }
}
