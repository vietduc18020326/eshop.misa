using MISA.ApplicationCore.Interface.ILocationBL;
using MISA.Common.Model.Location;
using MISA.Infrastructure.Interface.LocationDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.LocationBL
{
    public class CountryBL: BaseBL<Country>, ICountryBL
    {
        #region DECLARE
        ICountryDL _countryDL;
        #endregion

        #region Contructor
        public CountryBL(ICountryDL countryDL): base(countryDL)
        {
            _countryDL = countryDL;
        }
        #endregion
    }
}
