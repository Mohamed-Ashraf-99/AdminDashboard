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
        readonly IUnitOfWork _genericRepository;
        readonly IMapper _mapper;
        public DepartmentController(IMapper mapper, IUnitOfWork genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;

        }

        public async Task<IActionResult> Index()
        {
            var departments = await _genericRepository.Department.GetAll();
            var departmentsVM = _mapper.Map<IEnumerable<DepartmentVM>>(departments);
            return View(departmentsVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var department = await _genericRepository.Department.GetById(id);
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
                    await _genericRepository.Department.Add(department);
                    await _genericRepository.Commit();

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
            var department = await _genericRepository.Department.GetById(id);
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
                    await _genericRepository.Department.Update(department);
                    await _genericRepository.Commit();

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
                var department = await _genericRepository.Department.GetById(id);
                await _genericRepository.Department.Delete(department);
                await _genericRepository.Commit();

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
