using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.JqueryDatatable
{
    /// <summary>
    /// Datatable collection helper
    /// </summary>
    public static class DataTableCollectionHelper
    {
        /// <summary>
        /// Order list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items"></param>
        /// <param name="dir"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> items, SortingDirection dir, Func<TSource, TKey> keySelector)
        {
            if (dir == SortingDirection.Asc)
            {
                return items.OrderBy(keySelector);
            }
            return items.OrderByDescending(keySelector);
        }

        /// <summary>
        /// Based on order on query string. Check and set name for columns are ordering
        /// Use for check sorting.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static DataTableRequest SetOrderingColumnName(this DataTableRequest item)
        {
            for (int i = 0; i < item.order.Count; i++)
            {
                item.order[i].ColumnName = item.columns[item.order[i].Column].Data;
            }
            return item;
        }

        /// <summary>
        /// Based on order on query string. Check and set name for columns are ordering
        /// Use for check sorting.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static CustomDataTableRequest SetOrderingColumnName(this CustomDataTableRequest item)
        {
            for (int i = 0; i < item.order.Count; i++)
            {
                item.order[i].ColumnName = item.columns[item.order[i].Column].Data;
            }
            return item;
        }
    }
}
