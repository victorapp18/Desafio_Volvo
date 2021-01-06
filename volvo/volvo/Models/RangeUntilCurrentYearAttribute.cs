using System;
using System.ComponentModel.DataAnnotations;

namespace volvo.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
