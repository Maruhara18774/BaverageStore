using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.DesignPatterns.IteratorPattern
{
    public abstract class IteratorAggregate: IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
