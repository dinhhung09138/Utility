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
    public class TestPattern : IDatabaseExecute<DataModel>
    {
        public ResponseStatusCode Delete(DataModel model)
        {
            throw new NotImplementedException();
        }

        public DataModel GetItem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataModel> GetList()
        {
            throw new NotImplementedException();
        }

        public ResponseStatusCode Save(DataModel model)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}
