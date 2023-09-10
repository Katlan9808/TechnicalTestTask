using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Models
{
    public  class RequestResultModel<T>
    {
        public bool isSuccessful { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
        public T result { get; set; }
    }
}
