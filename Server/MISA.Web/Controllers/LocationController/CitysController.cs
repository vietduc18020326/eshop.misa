using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface.ILocationBL;
using MISA.Common.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers.LocationController
{
    [Route("api/v1/cities")]
    public class CitysController : BaseController<City>
    {
        #region DECLARE
        ICityBL _cityBL;
        #endregion

        #region Contructor
        public CitysController(ICityBL cityBL): base(cityBL)
        {
            _cityBL = cityBL;
        }
        #endregion

    }
}
