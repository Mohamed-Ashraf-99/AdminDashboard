using AdminDashboardBLL.Feature.Interface;
using AdminDashboardBLL.ViewModels;
using AdminDashboardDAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly IDepartment _departmentRepository;
        readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, IDepartment departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _departmentRepository = departmentRepository;

        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllAsync(e => e.IsDeleted == false);
            var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(employeeViewModels);
        }


        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(e => e.Id == id  && e.IsDeleted);
            var employeeVm = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeVm);
        }

  
        public async Task<IActionResult> Create()
        {
            var employeeVM = new EmployeeViewModel()
            {
                DepartmentsList = await _departmentRepository.GetAllAsync()          
            };
            return View(employeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);   
                    await _employeeRepository.CreateAsync(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                employeeViewModel.DepartmentsList = await _departmentRepository.GetAllAsync();
                return View(employeeViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(e => e.Id == id  && e.IsDeleted);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);
                    await _employeeRepository.UpdateAsync(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employeeViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(e => e.Id == id && e.IsActive == true && e.IsDeleted);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);
                    await _employeeRepository.DeleteById(employee.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employeeViewModel);
            }
        }
    }
}
