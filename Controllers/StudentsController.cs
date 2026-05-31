using Microsoft.AspNetCore.Mvc;
using GoMath.Models;

namespace GoMath.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index(string? searchName, string? searchClass)
        {
            var students = StudentStore.Search(searchName, searchClass);
            ViewBag.SearchName = searchName;
            ViewBag.SearchClass = searchClass;
            ViewBag.AllClasses = StudentStore.GetAllClasses();
            return View(students);
        }

        public IActionResult Create()
        {
            return View(new Student { DateOfBirth = DateTime.Today.AddYears(-17) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentStore.Add(student);
                TempData["Success"] = $"Đã thêm học sinh {student.FullName} thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = StudentStore.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentStore.Update(student);
                TempData["Success"] = $"Đã cập nhật thông tin học sinh {student.FullName}!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = StudentStore.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = StudentStore.GetById(id);
            StudentStore.Delete(id);
            TempData["Success"] = $"Đã xóa học sinh {student?.FullName}!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var student = StudentStore.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
