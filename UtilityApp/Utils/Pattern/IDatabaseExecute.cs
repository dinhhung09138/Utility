using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Pattern
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDatabaseExecute<T> where T : class
    {
        IEnumerable<T> GetList();

        T GetItem();

        ResponseStatusCode Save(T model);

        ResponseStatusCode Delete(T model);
    }
}
