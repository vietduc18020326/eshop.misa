using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class StoreBL : BaseBL<Store>, IStoreBL
    {
        #region DECLARE
        IStoreDL _storeDL;
        #endregion

        #region Contructor
        public StoreBL(IStoreDL storeDL) : base(storeDL)
        {
            _storeDL = storeDL;
        }
        #endregion

        #region Method
        public ServiceResult CheckDuplicateInsert(Store store)
        {
            var serviceResult = new ServiceResult();
            var errMsg = new ErrorMsg();
            if (_storeDL.CheckDuplicateStoreCode(store))
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicateCode);
                serviceResult.Data = errMsg;
            }
            return serviceResult;
        }

        public ServiceResult InsertStore(Store store)
        {
            var serviceResult = this.CheckDuplicateInsert(store);
            if (!serviceResult.Success)
            {
                return serviceResult;
            }
            serviceResult = this.CheckEmpty(store);
            if (serviceResult.Success)
            {
                serviceResult.Data = _storeDL.InsertData(store);
                return serviceResult;
            }
            return serviceResult;
        }
        public ServiceResult CheckEmpty(Store store)
        {
            var serviceResult = new ServiceResult();
            var errMsg = new ErrorMsg();
            if(store.StoreCode.Trim() == string.Empty)
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyCode);
                serviceResult.Data = errMsg;
            }
            if (store.StoreName.Trim() == string.Empty)
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyFullName);
                serviceResult.Data = errMsg;
            }
            if (store.Address.Trim() == string.Empty)
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyAddress);
                serviceResult.Data = errMsg;
            }
            return serviceResult;
        }
        public ServiceResult DeleteStore(Store store)
        {
            var serviceResult = new ServiceResult();
            var errMsg = new ErrorMsg();
            if (_storeDL.CheckDuplicateStoreId(store))
            {
                serviceResult.Data = _storeDL.DeleteData(store);
            }
            else
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyId);
                serviceResult.Data = errMsg;
            }
            return serviceResult;
        }
        public ServiceResult UpdateStore(Store store)
        {
            var serviceResult = this.CheckDuplicateUpdate(store);
            if (!serviceResult.Success)
            {
                return serviceResult;
            }
            serviceResult = this.CheckEmpty(store);
            if (serviceResult.Success)
            {
                serviceResult.Data = _storeDL.UpdateData(store);
            }
            return serviceResult;
        }
        public ServiceResult CheckDuplicateUpdate(Store store)
        {
            var serviceResult = new ServiceResult();
            var errMsg = new ErrorMsg();
            if (_storeDL.CheckDuplicateStoreCodeAndId(store))
            {
                serviceResult.Success = false;
                errMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicateCode);
                serviceResult.Data = errMsg;
            }
            return serviceResult;
        }
        #endregion
    }
}
