using MISA.ApplicationCore.Interface.ILocationBL;
using MISA.Common.Model.Location;
using MISA.Infrastructure.Interface.LocationDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.LocationBL
{
    public class DistrictBL: BaseBL<District>, IDistrictBL
    {
        #region DECLARE
        IDistrictDL _districtDL;
        #endregion

        #region Contructor
        public DistrictBL(IDistrictDL districtDL): base(districtDL)
        {
            _districtDL = districtDL;
        }
        #endregion
    }
}
