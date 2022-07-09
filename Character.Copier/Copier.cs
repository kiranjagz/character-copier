using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Copier
{
    public interface ICopier
    {
        void Copy();
    }

    public class Copier : ICopier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Copy()
        {
            var c = _source.ReadChar();

            if (c != '\n')
                _destination.WriteChar(c);
        }
    }
}
