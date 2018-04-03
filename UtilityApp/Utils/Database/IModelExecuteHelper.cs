using System.Collections.Generic;
using Utils.JqueryDatatable;
namespace Utils.Database
{
    /// <summary>
    /// IModelExecute Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelExecute<T> where T : class
    {
        /// <summary>
        /// Get list of data using jquery datatable
        /// </summary>
        /// <param name="request">CustomDataTableRequest</param>
        /// <returns>Dictionary</returns>
        Dictionary<string, object> List(CustomDataTableRequestHelper request);

        /// <summary>
        /// Get all item
        /// </summary>
        /// <returns>IEnumerable</returns>
        List<T> GetALL();
        
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
        ResponseStatusCodeHelper Save(T model);

        /// <summary>
        /// Publish item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>Success/Error</returns>
        ResponseStatusCodeHelper Publish(T model);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>Success/Error</returns>
        ResponseStatusCodeHelper Delete(T model);

        /// <summary>
        /// Check before execute delete item
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>OK/NG</returns>
        ResponseStatusCodeHelper CheckDeleteItem(T model);
    }
}
