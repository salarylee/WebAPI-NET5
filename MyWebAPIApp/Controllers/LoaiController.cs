﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebAPIApp.Data;
using MyWebAPIApp.Migrations;
using MyWebAPIApp.Models;
using System.Linq;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound(new
                {
                    success = false,
                    message = "Không tìm thấy loại"
                });
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
         {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound(new
                {
                    success = false,
                    message = "Không tìm thấy loại"
                });
            }
        }
    }
}
