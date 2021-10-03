using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.DesignPatterns.IteratorPattern
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        public abstract int Key();
        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }
}
