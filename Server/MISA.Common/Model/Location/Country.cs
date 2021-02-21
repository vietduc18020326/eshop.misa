using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model.Location
{
    /// <summary>
    /// Quốc gia
    /// </summary>
    public class Country
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// Tên quốc gia
        /// </summary>
        public string CountryName { get; set; }
        #endregion
    }
}
