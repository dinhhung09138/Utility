using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.JqueryDatatable;

namespace Utils.Database
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelExecute<T> where T : class
    {
        /// <summary>
        /// Get list of data using jquery datatable
        /// </summary>
        /// <param name="request">CustomDataTableRequest</param>
        /// <returns>Dictionary</returns>
        Dictionary<string, object> List(CustomDataTableRequest request);

        /// <summary>
        /// Get all item
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<T> GetALL();
        
        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>T</returns>
        T GetItemByID(T model);

        /// <summary>
        /// Save item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>Success/Error</returns>
        ResponseStatusCode Save(T model);

        /// <summary>
        /// Publish item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>Success/Error</returns>
        ResponseStatusCode Publish(T model);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>Success/Error</returns>
        ResponseStatusCode Delete(T model);

        /// <summary>
        /// Check before execute delete item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>OK/NG</returns>
        ResponseStatusCode CheckDeleteItem(T model);
    }
}
