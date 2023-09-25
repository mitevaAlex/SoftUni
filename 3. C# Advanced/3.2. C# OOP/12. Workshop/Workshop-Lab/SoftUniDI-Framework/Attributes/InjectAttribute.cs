using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI_Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}
