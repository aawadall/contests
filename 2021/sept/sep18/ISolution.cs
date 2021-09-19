using System.Collections.Generic;

namespace sep18
{
    public interface ISolution
    {
        bool EnableDebug { get; set; }
        IList<string> AddOperators(string num, int target);
    }
}