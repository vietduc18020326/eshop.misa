using MISA.ApplicationCore.Interface.ILocationBL;
using MISA.Common.Model.Location;
using MISA.Infrastructure.Interface.LocationDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.LocationBL
{
    public class CityBL: BaseBL<City>, ICityBL
    {
        #region DECLARE
        ICityDL _cityDL;
        #endregion
        #region Contructor
        public CityBL(ICityDL cityDL): base(cityDL)
        {
            _cityDL = cityDL;
        }
        #endregion
    }
}
