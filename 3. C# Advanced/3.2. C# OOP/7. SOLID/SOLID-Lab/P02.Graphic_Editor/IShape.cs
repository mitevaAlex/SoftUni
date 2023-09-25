using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public interface IShape
    {
        string Draw() => $"I'm {this.GetType().Name}";
    }
}
