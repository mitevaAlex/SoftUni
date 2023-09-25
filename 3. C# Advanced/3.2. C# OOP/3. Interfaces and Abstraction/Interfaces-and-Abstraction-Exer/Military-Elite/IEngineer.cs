using System.Collections.Generic;

namespace Military_Elite
{
    public interface IEngineer
    {
        List<Repair> Repairs { get; }
    }
}