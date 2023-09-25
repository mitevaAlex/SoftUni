using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            return (int)obj > this.minValue && (int)obj < this.maxValue ? true : false;
        }
    }
}
