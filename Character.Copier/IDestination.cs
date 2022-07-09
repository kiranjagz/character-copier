using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Copier
{
    public interface IDestination
    {
        void WriteChar(char c);
    }
}
