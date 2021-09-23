using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Model
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
    }
    public class Data_Result<T>: Result
    {
        public IEnumerable<T> results;
        public IEnumerable<Role> Result { get; set; }

    }
}
