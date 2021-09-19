using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.Common
{
    public class TFResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public TFResult() { }
        public TFResult(T data)
        {
            Data = data;
        }
    }
}
