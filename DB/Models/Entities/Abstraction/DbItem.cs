using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.Entities.Abstarction
{
    public abstract class DbItem<T> : IDbItem<T>
    {
        public T Id { get; set; }
    }

    public interface IDbItem<T>
    {
        T Id { get; set; }
    }
}
