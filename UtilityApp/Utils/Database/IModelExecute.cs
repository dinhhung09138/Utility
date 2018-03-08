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
        /// Get all item
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetALL();
        
        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        T GetItemByID(T model);

        /// <summary>
        /// Save item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Save(T model);

        /// <summary>
        /// Publish item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Publish(T model);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseStatusCode Delete(T model);

    }
}
