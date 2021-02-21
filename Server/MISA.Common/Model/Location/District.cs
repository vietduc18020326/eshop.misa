using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model.Location
{
    /// <summary>
    /// Huyện, quận
    /// </summary>
    public class District
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int DistrictId { get; set; }
        /// <summary>
        /// Tên huyện, quận
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Mã thành phố
        /// </summary>
        public int CityId { get; set; }
        #endregion
    }
}
