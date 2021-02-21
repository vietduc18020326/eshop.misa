using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của thuộc tính
        /// </summary>
        /// <typeparam name="T">Thuộc tính chung</typeparam>
        /// <returns></returns>
        ServiceResult GetData();
        /// <summary>
        /// lấy dữ liệu thông qua khóa ngoại và khóa chính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult GetDatabyId(string id);
        /// <summary>
        /// Đếm số lượng của thuộc tính cần đếm
        /// </summary>
        /// <returns></returns>
        ServiceResult QuantityData();
        /// <summary>
        /// Lấy dữ liệu cho 1 trang
        /// </summary>
        /// <param name="offset">Vị trí bắt  dầu lấy</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns></returns>
        ServiceResult GetDataOfPage(int offset,int size);
    }
}
