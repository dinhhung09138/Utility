using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Database
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelExecute<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetALL();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T GetItemByID(T model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Save(T model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Publish(T model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Delete(T model);

    }
}
