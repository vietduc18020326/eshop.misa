using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Tầng dl dùng chung
    /// </summary>
    /// CreatedBy: PNVĐ(08/02/2021)
    public class BaseDL<T>:DbConnector, IBaseDL<T>
    {
        #region DECLARE
        DbConnector dbConnector = new DbConnector();
        #endregion

        #region Methods
        public IEnumerable<T> GetData()
        {
            return dbConnector.GetData<T>();
        }
        public IEnumerable<T> GetDataById(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_GetData{tableName}ById";
            var param = new
            {
                id = id
            };
            return dbConnector.GetData<T>(storeName, param, System.Data.CommandType.StoredProcedure);
        }
        public long QuantityData()
        {
            return dbConnector.GetCountData<T>();
        }
        public IEnumerable<T> GetDataOfPage(int offset,int size)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_Get{tableName}OfPage";
            var param = new
            {
                offset = offset,
                size = size
            };
            return dbConnector.GetData<T>(storeName, param, System.Data.CommandType.StoredProcedure);
        }

        public int InsertData(T entity)
        {
            return dbConnector.Insert<T>(entity);
        }

        public int UpdateData(T entity)
        {
            return dbConnector.Update<T>(entity);
        }
        public int DeleteData(T entity)
        {
            return dbConnector.delete<T>(entity);
        }
        #endregion
    }
}
