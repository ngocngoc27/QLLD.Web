using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly IFacultyService _FacultyService;
        public ClassController(IClassService classService, IFacultyService facultyService)
        {
            _classService = classService;
            _FacultyService = facultyService; 
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            var data = _classService.Get();
            return View(data);
        }
        private void FacultyList(object selectFaculty = null)
        {
            ViewBag.FacultyId = new SelectList(_FacultyService.Get(), "Id", "FacultyName", selectFaculty);
        }
        private bool ClassExists(long id)
        {
            return _classService.ClassExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            FacultyList();
            if (id == 0)
            {
                return View(new Class());
            }
            else
            {
                var data = _classService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Class model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _classService.Create(model);
                }
                else
                {
                    try
                    {
                        _classService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClassExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _classService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Class model)
        {
            _classService.Delete(model);
            return Json(new {html = Helper.RenderRazorViewToString(this, "_ViewAll", _classService.Get())});
        }
        public IActionResult Export()
        {
            var data = _classService.GetClass();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("Sinh viên");
                sheet.Cells["A1"].Value = "TRƯỜNG ĐẠI HỌC ĐỒNG THÁP";
                sheet.Cells["A2"].Value = "Trung tâm Quản lý dịch vụ";
                sheet.Cells["D3"].Value = "DANH SÁCH LỚP ĐẠT ĐỦ NGÀY LAO ĐỘNG";
                sheet.Cells[5, 3].Value = "Mã lớp";
                sheet.Cells[5, 4].Value = "Tên lớp";
                sheet.Cells[5, 5].Value = "Loại hình đào tạo";
                sheet.Cells[5, 6].Value = "Khoa";
                // định dạng
                sheet.Cells["A1"].Style.Font.Bold = true;
                sheet.Cells["A2"].Style.Font.UnderLine=true;
                sheet.Cells["D3"].Style.Font.Bold = true;
                sheet.Cells[5, 3].Style.Font.Bold = true; ;
                sheet.Cells[5, 4].Style.Font.Bold = true;
                sheet.Cells[5, 5].Style.Font.Bold = true;
                sheet.Cells[5, 6].Style.Font.Bold = true;
                sheet.Cells["D3"].AutoFitColumns();
                sheet.Cells[5, 5].AutoFitColumns();
                sheet.Cells[5, 4].AutoFitColumns();
                sheet.Cells[5, 3].AutoFitColumns();
                sheet.Cells[5, 6].AutoFitColumns();
                // dổ dữ liệu vào sheet
                int rowIdx = 6;
                foreach(var lo in data)
                {
                    sheet.Cells[rowIdx, 3].Value = lo.ClassCode;
                    sheet.Cells[rowIdx, 4].Value = lo.ClassName;
                    sheet.Cells[rowIdx, 5].Value = lo.TypeOfEducation;
                    sheet.Cells[rowIdx, 6].Value = lo.FacultyName;
                }
                //sheet.Cells.LoadFromCollection(data, true);

                package.Save();
            }
            stream.Position = 0;
            var fileName = $"Danhsachhoanthanh_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
        }
    }
}
