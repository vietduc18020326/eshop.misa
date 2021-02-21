using MISA.ApplicationCore.Interface.ILocationBL;
using MISA.Common.Model.Location;
using MISA.Infrastructure.Interface.LocationDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.LocationBL
{
    public class CommunesBL: BaseBL<Communes>, ICommunesBL
    {
        #region DECLARE
        ICommunesDL _communesDL;
        #endregion

        #region Contructor
        public CommunesBL(ICommunesDL communesDL): base(communesDL)
        {
            _communesDL = communesDL;
        }
        #endregion
    }
}
