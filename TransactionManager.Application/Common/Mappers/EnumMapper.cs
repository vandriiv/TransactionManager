using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionManager.Application.Common.Mappers
{
    public class EnumMapper
    {
        public T MapEnum<T,P>(P from) 
            where T:Enum 
            where P:Enum
        {
            return (T)Enum.Parse(typeof(T), from.ToString());
        }
    }
}
