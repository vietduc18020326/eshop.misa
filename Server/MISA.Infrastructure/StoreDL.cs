using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class StoreDL : BaseDL<Store>, IStoreDL
    {
        #region DECLARE
        DbConnector dbConnector = new DbConnector();
        #endregion

        #region Method
        public bool CheckDuplicateStoreCode(Store store)
        {
            var sqlCommand = $"SELECT * FROM Store WHERE StoreCode = @StoreCode";
            var param = new { StoreCode = store.StoreCode };
            List<Store> stores = dbConnector.GetData<Store>(sqlCommand, param) as List<Store>;

            if (stores.Count() > 0)
            {
                return true;
            }

            return false;
        }
        public bool CheckDuplicateStoreId(Store store)
        {
            var sqlCommand = $"SELECT * FROM Store WHERE StoreId = @StoreId";
            var param = new { StoreId = store.StoreId };
            List<Store> stores = dbConnector.GetData<Store>(sqlCommand, param) as List<Store>;

            if (stores.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckDuplicateStoreCodeAndId(Store store)
        {
            var sqlCommand = $"SELECT * FROM Store WHERE StoreCode = @StoreCode && StoreId != @StoreId";
            var param = new
            {
                StoreCode = store.StoreCode,
                StoreId = store.StoreId.ToString()
            };
            List<Store> stores = dbConnector.GetData<Store>(sqlCommand, param) as List<Store>;
            if (stores.Count() > 0)
                return true;
            return false;
        }
        #endregion
    }
}
