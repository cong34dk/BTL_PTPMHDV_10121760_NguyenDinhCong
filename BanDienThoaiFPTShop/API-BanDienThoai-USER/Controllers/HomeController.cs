﻿using BLL;
using BLL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanDienThoai_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeBL _homeBL;

        public HomeController(IHomeBL homeBL)
        {
            _homeBL = homeBL;
        }

        [Route("GetChuyenMucByID")]
        [HttpGet]
        public ActionResult<ChuyenMucModel> GetChuyenMucByID(int id)
        {
            try
            {
                var chuyenmuc = _homeBL.GetChuyenMucByID(id);
                if (chuyenmuc != null)
                {
                    return Ok(chuyenmuc);
                }
                return NotFound(new { message = "Chuyên mục không tìm thấy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        [Route("GetAllChuyenMuc")]
        [HttpGet]
        public ActionResult<IEnumerable<ChuyenMuc>> GetAllChuyenMuc()
        {
            return _homeBL.GetAllChuyenMuc();
        }

        [Route("GetSlideByID")]
        [HttpGet]
        public ActionResult<SlideModel> GetSlideByID(int id)
        {
            try
            {
                var slide = _homeBL.GetSlideByID(id);
                if (slide != null)
                {
                    return Ok(slide);
                }
                return NotFound(new { message = "Slide không tìm thấy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        [Route("GetAllSlide")]
        [HttpGet]
        public ActionResult<IEnumerable<Slide>> GetAllSlide()
        {
            return _homeBL.GetAllSlide();
        }

        [Route("GetSanPhamById")]
        [HttpGet]
        public ActionResult<SanPhamModel> GetSanPhamById(int id)
        {
            try
            {
                var sanPham = _homeBL.GetSanPhamByID(id);
                if (sanPham != null)
                {
                    return Ok(sanPham);
                }
                return NotFound(new { message = "Sản phẩm không tìm thấy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        [Route("GetAllSanPhams")]
        [HttpGet]
        public ActionResult<IEnumerable<SanPhamModel>> GetAllSanPhams()
        {
            try
            {
                var sanPhams = _homeBL.GetAllSanPhams();
                return Ok(sanPhams);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        [Route("GetAllQuangCaos")]
        [HttpGet]
        public IActionResult GetAllQuangCaos()
        {
            try
            {
                var quangCaos = _homeBL.GetAllQuangCaos();
                return Ok(quangCaos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi khi lấy danh sách quảng cáo: " + ex.Message);
            }
        }

        //Phân trang
        [Route("phan-trang")]
        [HttpGet]
        public ActionResult<IEnumerable<SanPhamModel>> GetPagedProducts(int pageNumber = 1, int pageSize = 12)
        {
            try
            {
                int totalPages;
                List<SanPhamModel> products = _homeBL.GetPagedProducts(pageNumber, pageSize, out totalPages);

                var result = new
                {
                    Products = products,
                    TotalPages = totalPages
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }
    }
}
