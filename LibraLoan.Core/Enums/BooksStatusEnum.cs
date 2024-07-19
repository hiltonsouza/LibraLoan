using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Core.Enums
{
    public enum BooksStatusEnum : byte
    {
        Available = 0,
        CheckedOut = 1,
        Unavailable = 2,  
    }
}
