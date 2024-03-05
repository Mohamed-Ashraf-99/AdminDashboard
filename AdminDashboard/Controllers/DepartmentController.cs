using AdminDashboardBLL.Feature.Interface;
using AdminDashboardBLL.ViewModels;
using AdminDashboardDAL.Entities;
using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard.Controllers
{
    public class DepartmentController : Controller
    {
        readonly IDepartment _department;

        //Inject IMapper
        readonly IMapper _mapper;
        public DepartmentController(IDepartment department, IMapper mapper)
        {
            _department = department;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _department.GetAllAsync();
            var departmentsVM = _mapper.Map<IEnumerable<DepartmentVM>>(departments);
            return View(departmentsVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var department = await _department.GetByIdAsync(id);
            var departmentVM = _mapper?.Map<DepartmentVM>(department);
            return View(departmentVM);
        }

        public IActionResult Create()
        {
            var departmentVM = new DepartmentVM();
            return View(departmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Mapping
                    var department = _mapper.Map<Department>(departmentVM);
                    //
                    await _department.CreateAsync(department);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the department.");

            }
            ModelState.Clear();
            return View(departmentVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var department = await _department.GetByIdAsync(id);
            var departmentVM = _mapper.Map<DepartmentVM>(department);
            return View(departmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Mapping
                    var department = _mapper.Map<Department>(departmentVM);
                    await _department.UpdateAsync(department);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the department.");
                return View(departmentVM);
            }  
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _department.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the department.");
                return View();
            }

        }

    }
}
