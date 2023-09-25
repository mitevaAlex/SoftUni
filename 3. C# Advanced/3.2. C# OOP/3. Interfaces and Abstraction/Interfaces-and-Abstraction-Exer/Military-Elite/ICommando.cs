using System.Collections.Generic;

namespace Military_Elite
{
    public interface ICommando
    {
        List<Mission> Missions { get; }
    }
}