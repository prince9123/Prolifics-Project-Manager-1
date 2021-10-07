using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Model
{


    public interface IOperations<T>
    {
        Result Add(T t);
        //Add 
        Data_Result<T> ListAll();
        //List All
        //ListById
        Result Remove(int id);
    }
    
}
