using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;
using System;
using System.Collections.Generic;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();
        
        [HttpGet]
        public IActionResult GetAll()
        {

           return Ok(hanghoas);
        }

        [HttpGet ("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hanghoa = hanghoas.Find(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy hàng hóa"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = hanghoa
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                success = true,
                data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hanhHoaEdit)
        {
            try
            {
                var hanghoa = hanghoas.Find(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy hàng hóa"
                    });
                }
                if(id != hanhHoaEdit.MaHangHoa.ToString())
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Id không khớp"
                    });
                }
                hanghoa.TenHangHoa = hanhHoaEdit.TenHangHoa;
                hanghoa.DonGia = hanhHoaEdit.DonGia;
                return Ok(new
                {
                    success = true,
                    data = hanghoa
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try 
            {
                var hanghoa = hanghoas.Find(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy hàng hóa"
                    });
                }
                hanghoas.Remove(hanghoa);
                return Ok(new
                {
                    success = true,
                    data = hanghoa
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
