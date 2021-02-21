using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model.Location
{
    /// <summary>
    /// Thành phố
    /// </summary>
    public class City
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// Tên thành phố
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// Mã quốc gia
        /// </summary>
        public int CountryId { get; set; }
        #endregion
    }
}
