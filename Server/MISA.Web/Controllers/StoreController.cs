using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers
{
    [Route("api/v1/stores")]
    public class StoreController : BaseController<Store>
    {
        #region DECLARE
        IStoreBL _storeBL;
        #endregion

        #region Contructor
        public StoreController(IStoreBL storeBL) : base(storeBL)
        {
            _storeBL = storeBL;
        }
        #endregion

        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        [HttpPost]
        public IActionResult Post(Store store)
        {
            var serviceResult = _storeBL.InsertStore(store);
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }

        /// <summary>
        /// Cập nhật dữ liệu cửa hàng
        /// </summary>
        /// <param name="store">thuộc tính cửa hàng</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Store store)
        {
            var serviceResult = _storeBL.UpdateStore(store);
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }

        /// <summary>
        /// Xóa dữ liệu cửa hàng
        /// </summary>
        /// <param name="id">khóa chính cửa hàng</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var store = new Store();
            store.StoreId = Guid.Parse(id);
            var serviceResult = _storeBL.DeleteStore(store);
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }
    }
}
