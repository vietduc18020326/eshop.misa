using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IStoreBL: IBaseBL<Store>
    {
        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns>Trả về số lượng bản ghi thành công</returns>
        ServiceResult InsertStore(Store store);
        /// <summary>
        /// Cập nhật dữ liệu cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        ServiceResult UpdateStore(Store store);
        /// <summary>
        /// kiểm tra trùng mã cửa hàng khi thêm mới
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns>Trả về kiểu ServiceResult</returns>
        ServiceResult CheckDuplicateInsert(Store store);
        /// <summary>
        /// Kiểm tra thuộc tính không được phép trùng khi cập nhật dữ liệu
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        ServiceResult CheckDuplicateUpdate(Store store);
        /// <summary>
        /// kiểm tra những trường bắt buộc nhập
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        ServiceResult CheckEmpty(Store store);
        /// <summary>
        /// Xóa dữ liệu cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        ServiceResult DeleteStore(Store store);
    }
}
