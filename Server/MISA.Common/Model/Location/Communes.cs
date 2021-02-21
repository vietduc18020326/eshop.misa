using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model.Location
{
    /// <summary>
    /// Xã, phường
    /// </summary>
    public class Communes
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int CommunesId { get; set; }
        /// <summary>
        /// Tên xã, phường
        /// </summary>
        public string CommunesName { get; set; }
        /// <summary>
        /// Mã quận, huyện
        /// </summary>
        public int DistrictId { get; set; }
        #endregion
    }
}
