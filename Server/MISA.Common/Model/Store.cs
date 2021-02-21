using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// Thuộc tính cửa hàng
    /// </summary>
    public class Store
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid StoreId { get; set; }
        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        public string StoreCode { get; set; }
        /// <summary>
        /// Địa chỉ cửa hàng
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// số điện thoại cửa hàng
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã số thuế của cửa hàng
        /// </summary>
        public string StoreTaxCode { get; set; }
        /// <summary>
        /// Mã quốc gia 
        /// </summary>
        public int? CountryId { get; set; }
        /// <summary>
        /// Mã thành phố 
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// Mã huyện, quận của cửa hàng
        /// </summary>
        public int? DistrictId { get; set; }
        /// <summary>
        /// Mã phường, xã của cửa hàng
        /// </summary>
        public int? CommunesId { get; set; }
        /// <summary>
        /// Đường phố đặt cửa hàng
        /// </summary>
        public string Streets { get; set; }
        /// <summary>
        /// Tình trạng hoạt động của cửa hàng
        /// </summary>
        public int? Status { get; set; }
        #endregion
    }
}
