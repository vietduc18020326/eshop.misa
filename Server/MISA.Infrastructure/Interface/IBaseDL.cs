using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Interface
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu có thuộc tính T trong data
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetData();
        /// <summary>
        /// Lấy dữ liệu thông qua id của khóa ngoại
        /// </summary>
        /// <param name="id">Khóa chính của khóa ngoại</param>
        /// <returns></returns>
        IEnumerable<T> GetDataById(string id);
        /// <summary>
        /// Đếm số lượng dữ liệu
        /// </summary>
        /// <returns></returns>
        long QuantityData();
        /// <summary>
        /// lấy dữ liệu cho 1 trang
        /// </summary>
        /// <param name="offset">Vị trí bắt đầu lấy</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns></returns>
        IEnumerable<T> GetDataOfPage(int offset, int size);
        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">thuộc tính chung</param>
        /// <returns>số lượng bản ghi thêm mới thành công</returns>
        int InsertData(T entity);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">thuộc tính chung</param>
        /// <returns>sô bản ghi sửa thành công</returns>
        int UpdateData(T entity);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entity">Thuộc tính chung</param>
        /// <returns>Số bản ghi đã xóa thành công</returns>
        int DeleteData(T entity);
    }
}
