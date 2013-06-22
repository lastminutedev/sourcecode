using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    public enum SecurityState
    {
        ErrorMode = -1,
        NotDefinedMode = 0, 
        ReadOnlyMode = 1,
        EditMode = 2
    }
}
