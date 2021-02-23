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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region DECLARE
        IBaseBL<T> _baseBL;
        #endregion
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu của thuộc tính T
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = new ServiceResult();
            serviceResult = _baseBL.GetData();
            var entity = serviceResult.Data as List<T>;

            if (entity.Count() == 0)
            {
                return StatusCode(204, serviceResult.Data);
            }
            return StatusCode(200, serviceResult.Data);
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu theo khóa chính
        /// </summary>
        /// <param name="id">khóa chính</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get1(string id)
        {
            var serviceResult = _baseBL.GetDatabyId(id);
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }
        /// <summary>
        /// Đếm số lượng dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet("quantity")]
        public IActionResult QuantityData()
        {
            var serviceResult = _baseBL.QuantityData();
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }
        /// <summary>
        /// Lấy dữ liệu cho 1 trang
        /// </summary>
        /// <param name="offset">Vị trí cần lấy</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns></returns>
        [HttpGet("page/{offset}&{size}")]
        public IActionResult GetPage(int offset, int size)
        {
            var serviceResult = _baseBL.GetDataOfPage(offset, size);
            if (serviceResult.Success)
            {
                return StatusCode(201, serviceResult.Data);
            }
            return StatusCode(400, serviceResult.Data);
        }

    }
}
