using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.ViewModels;
using System;
using System.IO;
using System.Linq;
using TaskDAL.Context;

namespace TaskAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizationController : ControllerBase
    {
        private DatabaseContext _db;
        private IWebHostEnvironment _env;

        public UtilizationController(DatabaseContext db, IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }

        [HttpGet("Provinces")]
        public IActionResult Provinces()
        {
            return Ok(_db.Provinces.ToList());
        }

        [HttpGet("Districts/{provinceId}")]
        public IActionResult Districts(int provinceId)
        {
            return Ok(_db.Districts.Where(a=>a.provinceId == provinceId).Select(x=>
            new DistrictVM{
                districtId = x.districtId,
                districtName = x.districtName,
                provinceId = x.provinceId
            }).ToList());
        }

        [HttpGet("Industries")]
        public IActionResult Industries()
        {
            return Ok(_db.Industries.ToList());
        }

        [HttpGet("Companies")]
        public IActionResult Companies()
        {
            return Ok(_db.Company.ToList());
        }

        [HttpPost("FilterEducations")]
        public IActionResult FilterEducations(FilterModel filterModel)
        {
            return Ok(_db.Educations.Where(a => a.educationName.Contains(filterModel.keyWord)).ToList());
        }

        [HttpPost("FilterCompanies")]
        public IActionResult FilterCompanies(FilterModel filterModel)
        {
            return Ok(_db.Company.Where(a => a.companyName.Contains(filterModel.keyWord)).ToList());
        }

        [HttpPost("FilterLicenses")]
        public IActionResult FilterLicenses(FilterModel filterModel)
        {
            return Ok(_db.Licenses.Where(a => a.licenseName.Contains(filterModel.keyWord) || a.Company.companyName.Contains(filterModel.keyWord)).ToList()); ;
        }

        [HttpGet("GetCompanyImage/{companyId}")]
        public IActionResult GetCompanyImage(int companyId)
        {
            var companyPath = Path.Combine(_env.ContentRootPath, "img", "company");

            var filePath = Path.Combine(companyPath, companyId.ToString()+".png");
            FileStream file;
            try
            {
                file = System.IO.File.OpenRead(filePath);
            }
            catch (Exception)
            {
                file = null;
            }

            if (file == null)
            {
                return NotFound();
            }
            return File(file, "image/png");
        }

        [HttpGet("GetEducationImage/{educationId}")]
        public IActionResult GetEducationImage(int educationId)
        {
            var educationPath = Path.Combine(_env.ContentRootPath, "img", "education");

            var filePath = Path.Combine(educationPath, educationId.ToString() + ".png");
            FileStream file;
            try
            {
                file = System.IO.File.OpenRead(filePath);
            }
            catch (Exception)
            {
                file = null;
            }

            if (file == null)
            {
                return NotFound();
            }
            return File(file, "image/png");
        }


    }
}
