using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Interface
{
    public interface IStoreDL: IBaseDL<Store>
    {
        /// <summary>
        /// kiểm tra trùng mã cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns>trả về true nếu không trùng</returns>
        bool CheckDuplicateStoreCode(Store store);
        /// <summary>
        /// Kiểm tra của hàng có tồn tại trong dữ liệu
        /// </summary>
        /// <param name="store">Thuộc tính cửa hàng</param>
        /// <returns></returns>
        bool CheckDuplicateStoreId(Store store);
        /// <summary>
        /// kiểm tra trùng mà cửa hàng khi cập nhật dữ liêuh
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        bool CheckDuplicateStoreCodeAndId(Store store);
    }
}
