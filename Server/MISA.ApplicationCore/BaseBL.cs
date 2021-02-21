using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class BaseBL<T>:IBaseBL<T>
    {
        #region DECLARE
        IBaseDL<T> _baseDL;
        #endregion

        #region Contructor
        public BaseBL(IBaseDL<T> BaseDL)
        {
            _baseDL = BaseDL;
        }
        #endregion

        #region Methods
        //Lấy toàn bộ dữ liệu nhân viên
        public ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _baseDL.GetData();
            return serviceResult;
        }
        public ServiceResult GetDatabyId(string id)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _baseDL.GetDataById(id);
            return serviceResult;
        }
        public ServiceResult QuantityData()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _baseDL.QuantityData();
            return serviceResult;
        }
        public ServiceResult GetDataOfPage(int offset,int size)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _baseDL.GetDataOfPage(offset, size);
            return serviceResult;
        }
        #endregion
    }
}
